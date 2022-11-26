using Core.Application.Models;

namespace Core.Application
{
    public interface IProjectRepository
    {
        Task<IReadOnlyCollection<Project>> GetAll();

        Task<Project?> GetByName(string name);

        Task Delete(string name);

        Task Update(string name, Project project);

        Task Insert(Project project);
    }
}