using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        // Get /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        // POST /api/movies/
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            throw new NotImplementedException();
        }

        // PUT /api/movies/
        [System.Web.Mvc.HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            throw new NotImplementedException();
        }

        // DELETE /api/movies/
        [System.Web.Mvc.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }


        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }
    }
}
