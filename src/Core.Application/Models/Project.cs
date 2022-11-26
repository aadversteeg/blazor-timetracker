using System.ComponentModel.DataAnnotations;

namespace Core.Application.Models
{
    public class Project
    {
        [Required]
        [MinLength(5)]
        public  string Name { get; set; }

        public string? Description { get; set; } 

        public bool Active { get; set; }
    }
}
