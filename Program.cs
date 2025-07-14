using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("YouTube URL: ");
        string url = Console.ReadLine();

        Console.Write("Clip start time (format HH:MM:SS): ");
        string start = Console.ReadLine();

        Console.Write("Clip end time (format HH:MM:SS): ");
        string end = Console.ReadLine();

        Directory.CreateDirectory("Downloads");

        string baseOutputName = "clip";
        string extension = "mp4";
        string downloadsDir = "Downloads";

        // Update output template for yt-dlp (must use %(ext)s even if you know it's .mp4)
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string outputPath = Path.Combine(downloadsDir, $"{baseOutputName}_{timestamp}.%(ext)s");

        string ytDlpPath = "yt-dlp.exe";
        string ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "ffmpeg", "ffmpeg.exe");

        string section = $"*{start}-{end}";
        //string arguments = $"--download-sections \"{section}\" --recode-video mp4 -o \"{outputPath}\" \"{url}\"";
        string arguments = $"--download-sections \"{section}\" --recode-video mp4 --force-keyframes-at-cuts -o \"{outputPath}\" \"{url}\"";

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

        // Set PATH env var to include local ffmpeg directory
        process.StartInfo.Environment["PATH"] =
            $"{Path.GetDirectoryName(ffmpegPath)};{Environment.GetEnvironmentVariable("PATH")}";

        process.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
        process.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        string outputFile = Directory.GetFiles(downloadsDir, $"clip_{timestamp}.*").FirstOrDefault();

        if (!string.IsNullOrEmpty(outputFile))
            Console.WriteLine($"Download complete. Saved to: {outputFile}");
        else
            Console.WriteLine("Download complete, but file not found.");

    }
}
