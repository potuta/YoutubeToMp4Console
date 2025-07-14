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
- [`ffmpeg.exe`] & [`ffprobe.exe`](https://www.gyan.dev/ffmpeg/builds/) 

## 📁 Folder Structure

YoutubeToMp4Console/
├── Downloads/                 # Output folder
├── Tools/
│   └── ffmpeg/
│       ├── ffmpeg.exe
│       └── ffprobe.exe
├── yt-dlp.exe
├── Program.cs
└── YoutubeToMp4Console.csproj
