using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("YouTube URL: ");
        string url = Console.ReadLine();

        Console.Write("Clip start time (format HH:MM:SS): ");
        string start = Console.ReadLine();

        Console.Write("Clip end time (format HH:MM:SS): ");
        string end = Console.ReadLine();

        if (!TryParseTime(start, out TimeSpan startTime) || !TryParseTime(end, out TimeSpan endTime))
        {
            Console.WriteLine("Invalid time format. Please use HH:MM:SS.");
            enterToExit();
            return;
        }

        if (endTime <= startTime)
        {
            Console.WriteLine("End time must be after start time.");
            enterToExit();
            return;
        }

        CovertYoutubeToMp4(url, start, end);
    }

    static bool TryParseTime(string input, out TimeSpan result)
    {
        return TimeSpan.TryParseExact(input, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out result);
    }

    static void CovertYoutubeToMp4(string url, string start, string end)
    {
        try
        {
            Directory.CreateDirectory("Downloads");

            string baseOutputName = "clip";
            string downloadsDir = "Downloads";

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputPath = Path.Combine(downloadsDir, $"{baseOutputName}_{timestamp}.%(ext)s");

            string ytDlpPath = string.Empty;
            string ffmpegFile = string.Empty;
            string jsRuntimeFile = string.Empty;

            if (OperatingSystem.IsWindows())
            {
                ytDlpPath = "yt-dlp.exe";
                ffmpegFile = "ffmpeg.exe";
                jsRuntimeFile = "deno.exe";
            }
            else if (OperatingSystem.IsMacOS())
            {
                ytDlpPath = "yt-dlp";
                ffmpegFile = "ffmpeg";
                jsRuntimeFile = "deno";
            }
            else
            {
                Console.WriteLine("Unsupported operating system.");
                enterToExit();
                return;
            }

            if (string.IsNullOrEmpty(ytDlpPath) || string.IsNullOrEmpty(ffmpegFile) || string.IsNullOrEmpty(jsRuntimeFile))
            {
                Console.WriteLine("Could not determine tool paths for the current operating system.");
                enterToExit();
                return;
            }

            string ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "ffmpeg", ffmpegFile);
            string jsRuntimePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "deno", jsRuntimeFile);

            if (!File.Exists(ffmpegPath))
            {
                Console.WriteLine($"{ffmpegFile} not found at: {ffmpegPath}");
                enterToExit();
                return;
            }

            if (!File.Exists(jsRuntimePath))
            {
                Console.WriteLine($"{jsRuntimeFile} not found at: {jsRuntimePath}");
                enterToExit();
                return;
            }

            string section = $"*{start}-{end}";
            string arguments = $"--download-sections \"{section}\" " +
                            "-f \"bv[ext=mp4]+ba[ext=m4a]/b[ext=mp4]\" " +
                            "--recode-video mp4 --force-keyframes-at-cuts " +
                            $"--js-runtimes deno:\"{jsRuntimePath}\" " +
                            $"-o \"{outputPath}\" \"{url}\"";

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ytDlpPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            // Include ffmpeg & deno in PATH
            string ffmpegDir = Path.GetDirectoryName(ffmpegPath);
            string denoDir = Path.GetDirectoryName(jsRuntimePath);

            string systemPath = Environment.GetEnvironmentVariable("PATH");

            process.StartInfo.Environment["PATH"] =
                $"{ffmpegDir};{denoDir};{systemPath}";

            process.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            string outputFile = Directory
                .GetFiles(downloadsDir, $"clip_{timestamp}.*")
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(outputFile))
            {
                Console.WriteLine($"Download complete. Saved to: YoutubeToMp4Console\\{outputFile}");
                enterToExit();
            }
            else
            {
                Console.WriteLine("Download unsuccessful.");
                enterToExit(); 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred:\n{ex}");
            enterToExit();
        }
        
    }

    static void enterToExit()
    {
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}
