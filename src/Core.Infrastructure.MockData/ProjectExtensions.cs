using Core.Application.Models;

namespace Core.Infrastructure.MockData
{
    internal static class ProjectExtensions
    {
        public static Project ToApplication(this Models.Project project)
        {
            if (project == null) { return null; }

            return new Project()
            {
                Name = project.Name,
                Description = project.Description,
                Active = project.Active,
                Tasks = project.Tasks.ToApplication()
            };
        }
    }
}
