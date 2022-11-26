using Core.Application;
using Core.Application.Models;
using System.Xml.Linq;

namespace Core.Infrastructure.MockData
{
    public class ProjectRepository : IProjectRepository
    {
        private List<Project> _projects = new List<Project>()
            {
                new Project
                {
                    Name= "Test01",
                    Description= "Test project",
                    Active= true
                },
                new Project
                {
                    Name= "Test02",
                    Description= "Another test project",
                    Active= true
                }
            };

        public Task<IReadOnlyCollection<Project>> GetAll()
        {

            return Task.FromResult(_projects as IReadOnlyCollection<Project>)  ;
        }

        public Task<Project?> GetByName(string name)
        {
            Project? project = null;

            var projectInRepository = _projects.FirstOrDefault(p => p.Name == name);
            if (projectInRepository != null) {
                project = new Project
                {
                    Name = projectInRepository.Name,
                    Description = projectInRepository.Description,
                    Active = projectInRepository.Active
                };
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
            var projectInRepository = new Project()
            {
                Name = project.Name,
                Description = project.Description,
                Active = project.Active
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