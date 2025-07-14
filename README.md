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

- yt-dlp.exe
- ffmpeg (embedded, no system install required)
    
🗂 How to Download

1. Click the latest release in the [Releases](https://github.com/potuta/YoutubeToMp4Console/releases) section
2. Download and Extract the YoutubeToMp4Console.zip
3. Run the YoutubeToMp4Console.exe
    
🧠 How to Use

1. Run YoutubeToMp4Console.exe
2. Enter the YouTube URL (including Live VODs)
3. Enter the start time (e.g. 00:09:56)
4. Enter the end time (e.g. 00:10:35)
5. The clip will be saved in the Downloads folder inside the app directory.

---

## Developers

🛠 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [`yt-dlp.exe`](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
- [`ffmpeg.exe & ffprobe.exe`](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z) 

📦 Setup Instructions

1. **📥 Download the latest release of ffmpeg.exe & ffprobe.exe** from ['ffmpeg.exe & ffprobe.exe'](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z) 
2. **📁 Create `Tools\ffmpeg\` folder (if not yet created) inside `YoutubeToMp4Console\` where .csproj is located.**
3. **📁 Place ffmpeg.exe and ffprobe.exe inside `Tools\ffmpeg\` folder.**


