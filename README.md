# 🎬 YouTubeToMp4Console

A lightweight C# console app that downloads specific clips from YouTube videos or livestreams using [`yt-dlp`](https://github.com/yt-dlp/yt-dlp) and [`ffmpeg`](https://ffmpeg.org/).  

Just provide a URL, a start time, and an end time — the app will download that exact section as an `.mp4` video. Great for highlights, YouTube Shorts, and more.

<p align="center">
    <img alt="GitHub Release" src="https://img.shields.io/github/v/release/potuta/YouTubeToMp4Console?include_prereleases&sort=date&display_name=release&style=for-the-badge">
    <img alt="GitHub Downloads (all assets, all releases)" src="https://img.shields.io/github/downloads/potuta/YoutubeToMp4Console/total?style=for-the-badge">
    <img alt="GitHub Repo stars" src="https://img.shields.io/github/stars/potuta/YouTubeToMp4Console?style=for-the-badge">
    <img alt="GitHub License" src="https://img.shields.io/github/license/potuta/YouTubeToMp4Console?style=for-the-badge">
</p>

## ✨ Features

- 🎯 Download precise segments from YouTube videos and livestreams  
- 🕒 Specify start and end time in `HH:MM:SS` format  
- 🧠 Automatic file naming with timestamps  
- 🎥 Outputs `.mp4` using `ffmpeg`  
- 💡 Lightweight and runs fully offline (no GUI required)

## 📷 App Screenshots

### Specify Url, Start & End Times

![1](https://github.com/user-attachments/assets/77816028-3896-419b-9ce7-318b640c0af2)

### Downloading Phase

![2](https://github.com/user-attachments/assets/da8b2245-8e56-443c-b0cd-a7bc575640a2)

### Download Complete
![3](https://github.com/user-attachments/assets/7265ad6a-e782-4f55-aad6-173f3236bfac)


---

# Releases

### 📦 Download & Setup

1. Go to the [Releases](https://github.com/potuta/YoutubeToMp4Console/releases) section and download the latest release version
2. Extract `YoutubeToMp4Console.zip`
3. Run `YoutubeToMp4Console.exe`

### ▶️ How to Use

1. Launch the app (`YoutubeToMp4Console.exe`)
2. Enter the YouTube video or livestream URL  
3. Input start and end time in `HH:MM:SS` format  
4. Your trimmed clip will be saved in the `YoutubeToMp4Console/Downloads/` folder

---

## ⚠️ Windows Antivirus Warning?

If you see:

    "Windows protected your PC"
    "This app might put your PC at risk"

Don’t worry — this is **expected behavior** for new, unsigned `.exe` files.

### Why?

Windows flags unsigned apps to protect users from unknown sources. Digitally signing software requires a paid certificate — something most open-source developers don’t use. This app is **100% open-source**, so you're free to read and verify the code yourself.

### ✅ Recommendations

#### 🔹 Option 1: Run Anyway

1. Click **"More info"**
2. Click **"Run anyway"**

#### 🔹 Option 2: Unblock the File

Before opening the `YoutubeToMp4Console.exe`:

1. Right-click the file  
2. Select **"Properties"**  
3. Check **"Unblock"** at the bottom  
4. Click **OK**

#### 🔹 Option 3: Clone This Repo & Build It Yourself (Recommended for Devs)
- See [Developers Setup Instructions](https://github.com/potuta/YoutubeToMp4Console?tab=readme-ov-file#developers)

---

# Developers

### 🛠 Requirements/Dependencies

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [yt-dlp.exe](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
- [ffmpeg.exe](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z) 
- [deno.exe](https://deno.com/) 

### 📦 Setup Instructions

1. 📥 Download the latest release of `yt-dlp.exe` from [yt-dlp.exe](https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe)
2. 📥 Download the latest release of `ffmpeg.exe` from [ffmpeg.exe](https://www.gyan.dev/ffmpeg/builds/packages/ffmpeg-7.0.2-full_build.7z)
3. 📥 Download the latest release of `deno.exe` from [deno.exe](https://deno.com/)
4. 📁 Create `Tools\ffmpeg` folder inside the **root folder** where `.csproj` is located.
5. 📁 Create `Tools\deno` folder inside the **root folder** where `.csproj` is located.
6. 📁 Place `yt-dlp.exe` inside the **root folder** where `.csproj` is located.
7. 📁 Place `ffmpeg.exe` inside the **Tools\ffmpeg**\ folder you just created.
8. 📁 Place `deno.exe` inside the **Tools\deno**\ folder you just created.

