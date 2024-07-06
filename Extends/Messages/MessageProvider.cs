using Newtonsoft.Json.Linq;

namespace Task_Management_Backend.Extends.Messages;

public class MessageProvider
{
    private readonly JObject _errorMessage;
    public MessageProvider()
    {
        var json = File.ReadAllText("Extends/Messages/messages.json");
        _errorMessage = JObject.Parse(json);
    }
    /// <summary>Get error message</summary>
    /// <param name="key">The key of the error message</param>
    /// <returns>Error message</returns>
    public string GetMessage(string key)
    {
        return _errorMessage.TryGetValue(key, out var message) ? message.ToString() : "Unknown error";
    }
}