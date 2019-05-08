using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace MovieLibrary.Controllers
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        //public List<T> movies = new List<T>;


      public MoviesController()
      {
            new Movies { Title = "The Departed", Genre = "Drama", DirectorName = "Martin Scorsese" };
            new Movies { Title = "The Dark Knight", Genre = "Drama", DirectorName = "Christopher Nolan" };
            new Movies { Title = "Inception", Genre = "Drama", DirectorName = "Christopher Nolan" };
            new Movies { Title = "Pineapple Express", Genre = "Comedy", DirectorName = "David Gordon Green" };
            new Movies { Title = "Die Hard", Genre = "Action", DirectorName = "John McTiernan" };
      }

        public IEnumerable<Movies> GetAllMovies()
        {
            return db.Movies.ToList();
        }

        public IHttpActionResult GetMovie(int id)
        {
            var product = db.Movies.FirstOrDefault(p => p.MovieId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }      
    
    // PUT: api/Movies/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutMovie(int id, Movies movie)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != movie.MovieId)
        {
            return BadRequest();
        }
        db.Entry(movie).State = EntityState.Modified;
        db.SaveChanges();
        return StatusCode(HttpStatusCode.NoContent);
    }

    public IHttpActionResult PostMovie(Movies movies)
    {
      if (!ModelState.IsValid)
      return BadRequest("Invalid data.");

        using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(new Movies()
                {
                    MovieId = movies.MovieId,
                    Title = movies.Title,
                    Genre = movies.Genre,
                    DirectorName=movies.DirectorName,
                });

                ctx.SaveChanges();
            }

            return Ok();
        }



        // DELETE: api/Movies/5
        [ResponseType(typeof(Movies))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movies movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

    }
}

