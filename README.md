
# 🌟 WPF AI Chatbot (Gemini AI)

This is a **modern WPF chatbot** powered by **Google Gemini AI**. It includes a clean **Material Design UI**, **rounded chat bubbles**, and a **close button** for convenience.

## 🚀 Features
- **AI-Powered**: Uses Google Gemini AI for responses.
- **Modern UI**: Dark mode with rounded chat bubbles.
- **Smooth Animations**: Auto-scroll and hover effects.
- **Close Button**: Easily exit the chatbot.

## 📌 Requirements
- **Windows OS**
- **Visual Studio** (latest version recommended)
- **.NET 6 or later**
- **NuGet Packages:**
  - `MaterialDesignThemes`
  - `MaterialDesignColors`
  - `Newtonsoft.Json`
  - `System.Net.Http.Json`

## 🔧 Setup Instructions
### 1️⃣ **Get Google Gemini API Key**
1. Go to [Google AI Studio](https://ai.google.dev/)
2. Click **"Get API Key"** and sign in.
3. Copy the API Key.

### 2️⃣ **Clone the Repository**
```sh
 git clone https://github.com/TVVinudev/AIChatBot-Gemini.git
 cd AIChatBot-Gemini
```

### 3️⃣ **Update API Key in Code**
Open `MainWindow.xaml.cs` and replace `your_gemini_api_key` with your API Key:
```csharp
private const string apiKey = "your_gemini_api_key";
```

### 4️⃣ **Run the Project**
1. Open the project in **Visual Studio**.
2. Press `F5` to run the chatbot.
3. Start chatting with AI!

## 📜 Code Overview
### **UI (MainWindow.xaml)**
- **Modern Chat Interface** (Dark mode, rounded chat bubbles).
- **Text Input and Send Button**.
- **Close Button** in the header.

### **Logic (MainWindow.xaml.cs)**
- **Handles user messages** and calls Gemini API.
- **Parses AI responses** and displays them in the chat.
- **Auto-scrolls** when new messages arrive.

## 🛠 Future Enhancements
✅ **Typing Indicator** – Show "Bot is typing..."
✅ **Speech Recognition** – Voice input for chatbot.
✅ **Save Chat History** – Store and retrieve past conversations.

## 💡 Need Help?
If you face any issues, feel free to open an **issue** or **pull request**! 😊

---
**🎉 Happy Coding! 🚀**

