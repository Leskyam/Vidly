using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "In stock")]
        public int InStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

    }
}