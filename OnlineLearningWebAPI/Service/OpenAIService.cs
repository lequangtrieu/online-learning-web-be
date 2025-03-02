using OnlineLearningWebAPI.Service.IService;
using OpenAI.Chat;
using System.ClientModel;

namespace OnlineLearningWebAPI.Service
{
    public class OpenAIService : IOpenAIService
    {
        public readonly string _apiKey;

        public OpenAIService(IConfiguration configuration)
        {
            _apiKey = configuration["ChatGPT:Key"];
        }

        public async Task<string> GetAnswer(string question)
        {
            string prompt = question;

            ChatClient client = new(model: "gpt-4-1106-preview", new ApiKeyCredential(_apiKey));
            ChatCompletion completion = client.CompleteChat(prompt);
            string completions = completion.Content.FirstOrDefault().Text ?? "No valid answer";

            return completions;
        }
    }
}
