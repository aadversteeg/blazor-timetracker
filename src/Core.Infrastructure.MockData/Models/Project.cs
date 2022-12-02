namespace Core.Infrastructure.MockData.Models
{
    internal class Project
    {
        public Project(string name) { 
            Name = name;
            Tasks = new List<ProjectTask>();   
        }
        
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool Active { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
