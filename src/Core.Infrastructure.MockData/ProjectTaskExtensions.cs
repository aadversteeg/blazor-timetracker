using Core.Application.Models;

namespace Core.Infrastructure.MockData
{
    internal static class ProjectTaskExtensions
    {
        public static ProjectTask ToApplication(this Models.ProjectTask source)
        {
            return new ProjectTask(source.Name)
            {
                Description = source.Description
            };
        }

        public static IReadOnlyCollection<ProjectTask> ToApplication(this IEnumerable<Models.ProjectTask> source)
        {
            return source
                .Select(s => s.ToApplication())
                .ToList();
        }
    }
}
