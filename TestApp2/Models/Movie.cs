using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RealeaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        public int NoInStock { get; set; }
        public GenreType GenreType { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreTypeId { get; set; }

        public int NumberAvailable { get; set; }
    }
}