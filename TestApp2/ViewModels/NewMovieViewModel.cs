using System.Collections.Generic;
using TestApp2.Models;

namespace TestApp2.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public Movie Movie { get; set; }
    }
}