using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesDto = new List<MovieDto>();
            foreach (var movie in _db.Movies)
            {
                var movieDto = new MovieDto();
                MovieDto.Mapper(movie, movieDto);
                moviesDto.Add(movieDto);
                Debug.WriteLine($"{movieDto.Id}: {movieDto.Name}");
            }
            return Ok(moviesDto);
        }

        // Get /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieDto = MovieDto.Mapper(_db.Movies.SingleOrDefault(m => m.Id == id), new MovieDto());
            if(movieDto == null) 
                return NotFound();

            return Ok(movieDto);
        }

        // POST /api/movies/
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            movieDto.Id = _db.Movies.Add((Movie)MovieDto.Mapper(movieDto, new Movie())).Id;
            _db.SaveChanges();

            return Created($"{Request.RequestUri}/{movieDto.Id}", movieDto);
        }

        // PUT /api/movies/
        [System.Web.Mvc.HttpPut]
        public IHttpActionResult PutMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var dbMovie = _db.Movies.SingleOrDefault(m => m.Id == movieDto.Id);
            if (dbMovie == null)
                return NotFound();

            MovieDto.Mapper(movieDto, dbMovie);
            _db.SaveChanges();

            return Ok(movieDto);

        }

        // DELETE /api/movies/
        [System.Web.Mvc.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var dbMovie = _db.Movies.SingleOrDefault(m => m.Id == id);
            if (dbMovie == null) return BadRequest();

            _db.Movies.Remove(dbMovie);
            _db.SaveChanges();

            return Ok(true);
        }


        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }
    }
}
