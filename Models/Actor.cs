using System.ComponentModel.DataAnnotations;

namespace Cinema_project.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Image { get; set; }

         public List<MovieActor> MovieActors { get; set; } = new();
    }
}
