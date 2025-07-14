# 🎬 YouTubeToMp4Console

A simple C# console app that downloads specific clips from YouTube videos or livestreams using [`yt-dlp`](https://github.com/yt-dlp/yt-dlp) and [`ffmpeg`](https://ffmpeg.org/).  

You provide a URL, a start time, and an end time. The app downloads that exact section as an `.mp4` video. Useful for saving highlights, yt shorts, and tiktok clips.

## ✨ Features

- Download a clip from any YouTube video or livestream replay
- Specify precise start and end time (`HH:MM:SS`)
- Automatically names downloaded clips using timestamp
- Outputs `.mp4` using `ffmpeg`
- Lightweight and offline-ready (no GUI dependencies)

---

## Releases

📦 Included

To reduce antivirus/SmartScreen warnings, required tools like `yt-dlp.exe` and `ffmpeg.exe` are not bundled within the YoutubeToMp4Console.zip file. You can choose to download the `yt-dlp.exe` and `ffmpeg.exe` directly from the included Assets when downloading a Release version, or from the publishers source links below 👇.

Source links:
- **yt-dlp.exe: https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe**
- **ffmpeg.exe: https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z**

🗂 How to Download

1. **Click the latest release in the [Releases](https://github.com/potuta/YoutubeToMp4Console/releases) section**
2. **📥 Download and Extract the YoutubeToMp4Console.zip**
3. **📥 Download the required `yt-dlp.exe` and `ffmpeg.exe`.**
4. **📁 Place `yt-dlp.exe` inside `YoutubeToMp4Console\` where .csproj is located.**
5. **📁 Place `ffmpeg.exe` inside `Tools\ffmpeg\` folder.**
6. **Run the YoutubeToMp4Console.exe**
    
🧠 How to Use

1. **Run YoutubeToMp4Console.exe**
2. **Enter the YouTube URL (including Live VODs)**
3. **Enter the start time (e.g. 00:09:56)**
4. **Enter the end time (e.g. 00:10:35)**
5. **The clip will be saved in the Downloads folder inside the app directory.**

---

## Developers

🛠 Requirements/Dependencies

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [yt-dlp.exe](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
- [ffmpeg.exe](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z) 

📦 Setup Instructions

1. **📥 Download the latest release of `yt-dlp.exe`** from [yt-dlp.exe](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
2. **📥 Download the latest release of `ffmpeg.exe`** from [ffmpeg.exe](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z)
3. **📁 Create `Tools\ffmpeg\` folder (if not yet created) inside `YoutubeToMp4Console\` where .csproj is located.**
4. **📁 Place `yt-dlp.exe` inside `YoutubeToMp4Console\` where .csproj is located.**
5. **📁 Place `ffmpeg.exe` inside `Tools\ffmpeg\` folder.**


