﻿using MovieLibrary.Models;
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
   // [Route("api/[controller]")]
    public class MoviesController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        //public List<Movies> movies = new List<Movies>();


      //public MoviesController()
      //{
      //      Movies[] movies = new Movies[] {
      //      new Movies { Title = "The Departed", Genre = "Drama", DirectorName = "Martin Scorsese" },
      //      new Movies { Title = "The Dark Knight", Genre = "Drama", DirectorName = "Christopher Nolan" },
      //      new Movies { Title = "Inception", Genre = "Drama", DirectorName = "Christopher Nolan" },
      //      new Movies { Title = "Pineapple Express", Genre = "Comedy", DirectorName = "David Gordon Green" },
      //      new Movies { Title = "Die Hard", Genre = "Action", DirectorName = "John McTiernan" }
      //      };
      //}

        public IEnumerable<Movies> Get()
        {
            return db.Movies.ToList();
        }

        [HttpGet]
        [Route("api/movies/{value?}/prop/{property?}")]
        public IHttpActionResult GetMovie(string value, string property)
        {
            Movies product = null;
            switch (property)
            {
                case "Title":
                    product = db.Movies.FirstOrDefault(p => p.Title == value);
                    break;
                case "Genre":
                    product = db.Movies.FirstOrDefault(p => p.Genre == value);
                    break;
                case "DirectorName":
                    product = db.Movies.FirstOrDefault(p => p.DirectorName == value);
                    break;
                default:
                    break;
            }
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }      
    
    // PUT: api/Movies/5
    [ResponseType(typeof(void))]
    public IHttpActionResult Put(int id, Movies movie)
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

    public IHttpActionResult Post(Movies movies)
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

        [Route("Genre/{genre}")]
        public IQueryable<Movies> SearchMoviesByGenre(string genre)
        {
            return db.Movies.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }



        // GET: api/Movies/Director
        [Route("DirectorName/{name}")]
        public IQueryable<Movies> SearchMoviesByDirectorName(string name)
        {
            return db.Movies.Where(b => b.DirectorName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }



        // DELETE: api/Movies/5
        [ResponseType(typeof(Movies))]
        public IHttpActionResult Delete(int id)
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

