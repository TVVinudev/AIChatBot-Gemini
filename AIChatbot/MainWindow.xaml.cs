using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIChatbot;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const string apiKey = "your api";  
    private const string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;
    private static readonly HttpClient client = new HttpClient();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void SendMessage(object sender, RoutedEventArgs e)
    {
        string userMessage = txtUserInput.Text.Trim();
        if (string.IsNullOrEmpty(userMessage)) return;

        AddMessageToChat( userMessage, true);
        txtUserInput.Clear();

        string botResponse = await GetGeminiResponse(userMessage);
        AddMessageToChat( botResponse, false);
    }

    private async Task<string> GetGeminiResponse(string message)
    {
        var requestBody = new
        {
            contents = new object[]
            {
                    new
                    {
                        parts = new object[]
                        {
                            new { text = message }
                        }
                    }
            }
        };

        var requestJson = JsonConvert.SerializeObject(requestBody);
        var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);
        if (!response.IsSuccessStatusCode)
            return "Error: " + response.ReasonPhrase;

        string responseJson = await response.Content.ReadAsStringAsync();
        JObject jsonResponse = JObject.Parse(responseJson);

        return jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString().Trim() ?? "No response";
    }

    private void AddMessageToChat(string message, bool isUser)
    {
        Border chatBubble = new Border
        {
            Background = isUser ? new SolidColorBrush(Color.FromRgb(0, 191, 165)) : new SolidColorBrush(Color.FromRgb(68, 68, 68)),
            CornerRadius = new CornerRadius(15),
            Padding = new Thickness(10),
            Margin = new Thickness(5, 2, 5, 2),
            MaxWidth = 280,
            HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left
        };

        TextBlock textBlock = new TextBlock
        {
            Text = message,
            Foreground = Brushes.White,
            FontSize = 14,
            TextWrapping = TextWrapping.Wrap,
        };

        chatBubble.Child = textBlock;
        ChatPanel.Children.Add(chatBubble);

        // Auto-scroll to latest message
        ChatScroll.ScrollToEnd();
    }

    private void CloseApp(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

}