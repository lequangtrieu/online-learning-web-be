namespace OnlineLearningWebAPI.Service.IService
{
    public interface IOpenAIService
    {
        Task<string> GetAnswer(string question);
    }
}
