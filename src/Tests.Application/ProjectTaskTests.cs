using Core.Application.Models;
using FluentAssertions;

namespace Tests.Application
{
	public class ProjectTaskTests
	{
		[Fact(DisplayName ="PT001 - Empty name is not allowed.")]
		public void PT001()
		{
			// when
			var tst = () => new ProjectTask(string.Empty);

			// then
			tst.Should().Throw<ArgumentNullException>();
		}
	}
}