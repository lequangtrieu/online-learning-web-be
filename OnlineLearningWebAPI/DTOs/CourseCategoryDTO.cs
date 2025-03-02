namespace OnlineLearningWebAPI.DTOs
{
    public class CourseCategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<string> CourseTitles { get; set; } = new List<string>(); 
    }
}
