# 🎬 YouTubeToMp4Console

A simple C# console app that downloads specific clips from YouTube videos or livestreams using [`yt-dlp`](https://github.com/yt-dlp/yt-dlp) and [`ffmpeg`](https://ffmpeg.org/).  

You provide a URL, a start time, and an end time — the app downloads that exact section as an `.mp4` video. Useful for saving highlights, funny moments, or educational segments.

---

## ✨ Features

- Download a clip from any YouTube video or livestream replay
- Specify precise start and end time (`HH:MM:SS`)
- Automatically names downloaded clips using timestamp
- Outputs `.mp4` using `ffmpeg`
- Lightweight and offline-ready (no GUI dependencies)

---

## 🛠 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [`yt-dlp.exe`](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
- [`ffmpeg.exe & ffprobe.exe`](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z) 

## 📦 Setup Instructions

1. **📥 Download the latest release of ffmpeg.exe & ffprobe.exe** from ['ffmpeg.exe & ffprobe.exe'](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z) 
2. **📁 Create `Tools\ffmpeg\` folder (if not yet created) inside `YoutubeToMp4Console\` where .csproj is located.**
3. **📁 Place ffmpeg.exe and ffprobe.exe inside `Tools\ffmpeg\` folder.**


