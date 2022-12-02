using System.ComponentModel.DataAnnotations;

namespace Core.Application.Models
{
	public class ProjectTask
	{
		public ProjectTask(string name) {

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException();

		   this.Name = name;
		}


		[Required]
		[MinLength(2)]
		public string Name { get; }

		public string? Description { get; set; }

	}
}
