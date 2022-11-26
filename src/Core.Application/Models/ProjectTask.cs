namespace Core.Application.Models
{
	public class ProjectTask
	{
		public ProjectTask(string name) {

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException();

		   this.Name = name;
		}

		public string Name { get; }
	}
}
