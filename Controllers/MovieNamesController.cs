using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MovieApp.Models;
using MovieApp.Data;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieNamesController : ControllerBase
    {
        private MovieDbContext dbContext;
        //private readonly IConfiguration configuration;

        public MovieNamesController (MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {


            var movies = dbContext.movies.ToList();
                if(movies.Count ==0)
                {
                    return StatusCode(404, "no movie");
                }
                return Ok(movies);
            
            
            //string query = @"
            //        select id, title, year from dbo.movies";
            //DataTable table = new DataTable();
            //string sqlDataSource = configuration.GetConnectionString("MoviesAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader); ;
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new JsonResult(table);
        }
        [HttpGet("GetDirectors")]
        public IActionResult GetDirectors()
        {


            var directors = dbContext.directors.ToList();
            if (directors.Count == 0)
            {
                return StatusCode(404, "no directors");
            }
            return Ok(directors);
        }


        [HttpGet("GetRatings")]
        public IActionResult GetRatings()
        {


            var ratings = dbContext.ratings.ToList();
            if (ratings.Count == 0)
            {
                return StatusCode(404, "no ratings");
            }
            return Ok(ratings);
        }
        [HttpGet("GetStars")]
        public IActionResult GetStars()
        {


            var stars = dbContext.stars.ToList();
            if (stars.Count == 0)
            {
                return StatusCode(404, "no ratings");
            }
            return Ok(stars);
        }
        [HttpGet("GetPeople")]
        public IActionResult GetPeople()
        {

            var p = dbContext.people.ToList();
            if (p.Count == 0)
            {
                return StatusCode(404, "no people");
            }
            return Ok(p);
        }
        [HttpGet("{id}")]
        public IActionResult GetPeople(int id)
        {

            Person person = dbContext.people.Where(c => c.id == id).FirstOrDefault();
            if (person == null)
            {
                return StatusCode(404, "no people");
            }
            return Ok(person);
        }
        [HttpGet("GetDirectorsMovies")]
        public IActionResult GetDirectorsMovies()
        {


            var directors_movies = (from c in dbContext.directors
                                    join ca in dbContext.movies
      on c.movie_id equals ca.id
                                    select new
                                    {
                                        MovieId = c.movie_id,
                                        Title = ca.title
                                    });
            if (directors_movies == null)
            {
                return StatusCode(404, "no directors");
            }
            return Ok(directors_movies.ToList());
        }


        //[HttpGet("GetMoviesInfo")]
        //public IActionResult GetMoviesWithRatingStarsDirectors()
        //{

        //    //movies with starsid
        //    //var movie_starsName = (from m in dbContext.movies join
        //    //                       s in dbContext.stars
        //    //                       on m.id equals s.movie_id
        //    //                       select new 
        //    //                       { 
        //    //                             MovieId = m.id,
        //    //                             Title = m.title,
        //    //                             StarId = s.person_id
        //    //                       });
        //    //movies with starsname
        //    //var movie_starsName = (from m in dbContext.movies join
        //    //                       s in dbContext.stars  
        //    //                       on m.id equals s.movie_id join
        //    //                       p in dbContext.people on s.person_id equals p.id
        //    //                       select new
        //    //                       {
        //    //                           MovieId = m.id,
        //    //                           StarName = p.name
        //    //                       });
        //    //movies with starsname and director name
        //    //var directorName = (from p in dbContext.people
        //    //                            join
        //    // d in dbContext.directors
        //    // on p.id equals d.person_id
        //    //                            select new DirectorName
        //    //                            {
        //    //                                DirectorName_ = p.name
        //    //                            }
        //    //                    );
        //    //var movie_starsName = (from m in dbContext.movies join
        //    //                        s in dbContext.stars
        //    //                        on m.id equals s.movie_id join
        //    //                        p in dbContext.people 
        //    //                        on s.person_id equals p.id 
        //    //                       select new MovieInfo
        //    //                       {
        //    //                           MovieId = m.id,
        //    //                           StarName = p.name,
        //    //                           DirectorName = directorName
        //    //                       });

        //    //var movie_info = (from m in dbContext.movies join 

        //    //                  c in dbContext.directors
        //    //                        join ca in dbContext.movies
        //    //                 on c.movie_id equals ca.id
        //    //                        select new
        //    //                        {
        //    //                            Id = m.id,
        //    //                            Title = m.title,
        //    //                            Year = m.year,


        //    //                        });
        //    if (movie_starsName == null)
        //    {
        //        return StatusCode(404, "no directors");
        //    }
        //    return Ok(movie_starsName.ToList());
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetMovie(int id)
        //{


        //    var movie = dbContext./*rating_movie*/spmr.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return StatusCode(404, "no movie");
        //    } 
        //    return Ok(movie);
        //}
        //[HttpPost]
        //public IActionResult AddMovieToTopList(Movie movie)
        //{

        //    var topmovies = new Movie()
        //    {
        //        title = movie.title,
        //        year = movie.year,
        //        movie_id = movie.movie_id,
        //        rating = movie.rating,
        //        star_name = movie.star_name,
        //        director_name = movie.director_name



        //    };        
        //    dbContext.top10movies.Add(topmovies);
        //    return Ok(topmovies);
        //    Console.WriteLine(topmovies);
        //}
        //[HttpGet("GetTopMovies")]
        //public IActionResult GetTop10Movies()

        //{


        //    var movies = dbContext./*rating_movie*/top10movies;
        //    if (movies == null)
        //    {
        //        return StatusCode(404, "no movie");
        //    }
        //    return Ok(movies);
        //}


        //[HttpGet]
        //public JsonResult GetMovie(int id)
        //{
        //    string query = @"
        //            select id, title, year from dbo.movies";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = configuration.GetConnectionString("MoviesAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader); ;
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}
        //[HttpPost]
        //public JsonResult PostMovies(Movies movies)
        //{
        //    string query = @"
        //            insert into dbo.movies (id, title, year) values 
        //            (
        //             '" + movies.id + @"'
        //             ,'" + movies.title + @"'
        //             ,'" + movies.year + @"'
        //            )";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = configuration.GetConnectionString("MoviesAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader); ;
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult("Added");
        //}

    }
    }
