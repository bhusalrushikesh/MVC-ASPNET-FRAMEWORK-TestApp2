using System.Collections.Generic;
using TestApp2.Models;

namespace TestApp2.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}