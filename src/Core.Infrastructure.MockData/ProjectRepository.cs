using Core.Application;
using Core.Application.Models;

namespace Core.Infrastructure.MockData
{
    public class ProjectRepository : IProjectRepository
    {
        private List<Models.Project> _projects = new List<Models.Project>()
            {
                new Models.Project("Test01")
                {
                    Description= "Test project",
                    Active= true,
                    Tasks =  new List<Models.ProjectTask>()
                    {
                        new Models.ProjectTask("C") { Description = "Coding"},
                        new Models.ProjectTask("T") { Description = "Testing"},
                        new Models.ProjectTask("C") { Description = "Documenting"},
                        new Models.ProjectTask("B") { Description = "Bug fixing"},
                    }
                },
                new Models.Project("Test02")
                {
                    Name= "Test02",
                    Description= "Another test project",
                    Active= true,
                    Tasks =  new List<Models.ProjectTask>()
                    {
                        new Models.ProjectTask("C") { Description = "Coding"},
                        new Models.ProjectTask("T") { Description = "Testing"},                        
                        new Models.ProjectTask("C") { Description = "Documenting"},
                        new Models.ProjectTask("B") { Description = "Bug fixing"},
                    }
                }
            };

        public Task<IReadOnlyCollection<Project>> GetAll()
        {
            return Task.FromResult(_projects.Select(p => p.ToApplication()).ToList() as IReadOnlyCollection<Project>)  ;
        }

        public Task<Project?> GetByName(string name)
        {
            Project? project = null;

            var projectInRepository = _projects.FirstOrDefault(p => p.Name == name);
            if (projectInRepository != null) {
                project = projectInRepository.ToApplication();
            }

            return Task.FromResult(project);
        }

         public Task Update(string name, Project project) {

            var projectInRepository = _projects.FirstOrDefault(p => p.Name == name);
            if (projectInRepository != null)
            {
                projectInRepository.Name = project.Name;
                projectInRepository.Description = project.Description;
                projectInRepository.Active = project.Active;
            }

            return Task.CompletedTask;
        }

        public Task Insert(Project project)
        {
            var projectInRepository = new Models.Project(project.Name)
            {
                Description = project.Description,
                Active = project.Active,
            };

            _projects.Add(projectInRepository);
            return Task.CompletedTask;
        }

        public Task Delete(string name)
        {

            var projectInRepository = _projects.FirstOrDefault(p => p.Name == name);
            if (projectInRepository != null)
            {
                _projects.Remove(projectInRepository);
            }

            return Task.CompletedTask;
        }
    }
}