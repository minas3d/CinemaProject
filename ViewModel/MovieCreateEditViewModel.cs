using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Cinema_project.ViewModels
{
    public class MovieCreateEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Release Date")]
        public DateTime DateTime { get; set; } = DateTime.Now;

        public string SubImg { get; set; } // existing image path

         [Display(Name = "Poster Image")]
        public IFormFile PosterFile { get; set; }

        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; }

        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }
        public SelectList Cinemas { get; set; }

         [Display(Name = "Actors")]
        public int[] SelectedActorIds { get; set; } = Array.Empty<int>();
        public MultiSelectList Actors { get; set; }
    }
}
