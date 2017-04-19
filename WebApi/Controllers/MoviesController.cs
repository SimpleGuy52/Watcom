using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Context;
using Entity.Model;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/<controller>
        public object Get()
        {
            //InitContext();

            //List<Movie> movies = new List<Movie>
            //{
            //    new Movie(1, "Moolen"),
            //    new Movie(2, "Broken heart")
            //};

            object cars = null;
            using (var context = new BusinessContext())
            {
                cars = context.Cars.Select(i=> new
                {
                    Id =i.Id,
                    Name=i.Name,
                    Developer =new
                    {
                        Id=i.Developer.Id,
                        Name=i.Developer.Name
                    }
                }).Take(10).ToList();
            }

            return cars;
        }

        private void InitContext()
        {
            using (BusinessContext context = new BusinessContext())
            {
                var audi = new Developer {Name = "Audi"};
                var audiA4 = new Car() {Name = "A4"};
                var audiA6 = new Car() {Name = "A6"};
                audi.Cars = new List<Car>() {audiA4, audiA6};

                context.Developers.Add(audi);
                context.Cars.Add(audiA4);
                context.Cars.Add(audiA6);
                context.SaveChanges();
            }
        }

        // GET api/<controller>
        public IEnumerable<Movie> Get(int id)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Movie> MyMethod(int id)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        [HttpPost]
        public object PostMethod(PostMethodParams @params)
        {
            var t = @params;

            return new
            {
                Success = true,
                Value = "Some value"
            };
        }

        [HttpGet]
        public IEnumerable<Movie> GetMethod()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        [HttpGet]
        public object GetMethod(int id)
        {
            var t = id;
            
            return new
            {
                Success = true,
                Value = "Some value"
            };
        }
    }

    public class PostMethodParams
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
