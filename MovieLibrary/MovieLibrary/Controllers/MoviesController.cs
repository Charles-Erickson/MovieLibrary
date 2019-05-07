using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieLibrary.Controllers
{
    public class MoviesController : ApiController
    {
        Movies[] movies = new Movies[]
      {
        new Models.Movies { Title = "The Departed", Genre = "Drama", DirectorName = "Martin Scorsese"},
        new Models.Movies { Title = "The Dark Knight", Genre = "Drama", DirectorName = "Christopher Nolan"},
        new Models.Movies { Title = "Inception", Genre = "Drama", DirectorName = "Christopher Nolan"},
        new Models.Movies { Title = "Pineapple Express", Genre = "Comedy", DirectorName = "David Gordon Green"},
        new Models.Movies { Title = "Die Hard", Genre = "Action", DirectorName = "John McTiernan"}
      };

        public IEnumerable<Movies> GetAllProducts()
        {
            return movies;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = movies.FirstOrDefault((p) => p.MovieId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
}
