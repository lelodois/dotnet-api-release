namespace dotnet.Models
{
    public class Task
    {
        private long Id { get; set; }
        private string Name { get; set; }
        private bool IsComplete { get; set; }
        private Author Author { get; set; }
    }
}