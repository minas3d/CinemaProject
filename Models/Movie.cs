using System.ComponentModel.DataAnnotations;

namespace Cinema_project.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateTime { get; set; }

        public string SubImg { get; set; }

         public List<MovieActor> MovieActors { get; set; } = new();

         public int CategoryId { get; set; }
        public Category Category { get; set; }

         public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
    }
}
