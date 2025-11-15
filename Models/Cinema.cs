using System.ComponentModel.DataAnnotations;

namespace Cinema_project.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public string Img { get; set; }
    }
}
