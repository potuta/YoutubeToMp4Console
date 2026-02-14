using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

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
            return;
        }

        if (endTime <= startTime)
        {
            Console.WriteLine("End time must be after start time.");
            return;
        }

        Console.Write("Download audio only? (y/n): ");
        string audioChoice = Console.ReadLine()?.Trim().ToLower();
        bool audioOnly = audioChoice == "y" || audioChoice == "yes";

        ConvertYoutubeToMp4(url, start, end, audioOnly);
    }

    static bool TryParseTime(string input, out TimeSpan result)
    {
        return TimeSpan.TryParseExact(input, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out result);
    }

    static void ConvertYoutubeToMp4(string url, string start, string end, bool audioOnly = false)
    {
        try
        {
            Directory.CreateDirectory("Downloads");

            string baseOutputName = audioOnly ? "audio" : "clip";
            string downloadsDir = "Downloads";

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputPath = Path.Combine(downloadsDir, $"{baseOutputName}_{timestamp}.%(ext)s");

            string ytDlpPath = "yt-dlp.exe";
            string ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "ffmpeg", "ffmpeg.exe");
            string jsRuntimePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "deno", "deno.exe");

            if (!File.Exists(ffmpegPath))
            {
                Console.WriteLine($"ffmpeg.exe not found at: {ffmpegPath}");
                return;
            }

            if (!File.Exists(jsRuntimePath))
            {
                Console.WriteLine($"deno.exe not found at: {jsRuntimePath}");
                return;
            }

            string section = $"*{start}-{end}";
            string arguments;

            if (audioOnly)
            {
                arguments = $"--download-sections \"{section}\" " +
                            "-x --audio-format mp3 " +
                            "--force-keyframes-at-cuts " +
                            $"--js-runtimes deno:\"{jsRuntimePath}\" " +
                            $"-o \"{outputPath}\" \"{url}\"";
            }
            else
            {
                arguments = $"--download-sections \"{section}\" " +
                            "-f \"bv[ext=mp4]+ba[ext=m4a]/b[ext=mp4]\" " +
                            "--recode-video mp4 --force-keyframes-at-cuts " +
                            $"--js-runtimes deno:\"{jsRuntimePath}\" " +
                            $"-o \"{outputPath}\" \"{url}\"";
            }

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
                .GetFiles(downloadsDir, $"{baseOutputName}_{timestamp}.*")
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(outputFile))
            {
                Console.WriteLine($"Download complete. Saved to: {outputFile}");
            }
            else
            {
                Console.WriteLine("Download unsuccessful.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred:\n{ex}");
        }
        
    }
}
