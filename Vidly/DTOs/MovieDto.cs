using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDto : IMovie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public int InStock { get; set; }

        [Required]
        public int GenreId { get; set; }

        public static IMovie Mapper(IMovie from, IMovie to)
        {
            if (from == null) return null;

            foreach (var fromProperty in typeof(IMovie).GetProperties())
            {
                var toProperty = to.GetType().GetProperty(fromProperty.Name);
                toProperty.SetValue(to, fromProperty.GetValue(from));
            }
            return to;
        }

    }

    public interface IMovie
    {
        int Id { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        DateTime ReleaseDate { get; set; }

        [Required]
        DateTime DateAdded { get; set; }

        int InStock { get; set; }

        [Required]
        int GenreId { get; set; }


    }
}
