namespace Core.Infrastructure.MockData.Models
{
    internal class ProjectTask
    {
        public ProjectTask(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string? Description { get; set; }
    }
}
