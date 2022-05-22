//using Microsoft.EntityFrameworkCore;
//using MovieApp.Data;
//using MovieApp.Repository.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MovieApp.Repository
//{
//    public class MovieRepository : IMovieRepository
//    {
//        //private readonly MovieDbContext dbContext;

//        //public MovieRepository(MovieDbContext dbContext)
//        //{
//        //    this.dbContext = dbContext;
//        //}
//        //public async Task<IEnumerable<Movie>> GetMovies()
//        //{
//        //    return await dbContext.Movies.AsQueryable().OrderBy(i => i.id).ToListAsync();
//        //}
//        //public async Task<IEnumerable<Movie>> GetMovie(int id)
//        //{
//        //    var item
//        //    return await Task.FromResult dbContext.Movies.FindAsync(id);
//        //}
//        public Task<IEnumerable<Movie>> GetMovie(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<Movie>> GetMovies()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
