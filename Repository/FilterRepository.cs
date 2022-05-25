using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class FilterRepository : Base<Movie>, IFilterRepository
    {
        public FilterRepository(MovieDbContext dbContext) : base(dbContext)
        {
            
             
        }
        //-----------------GET MOVIE BY TITLE (FILTERING)
        //syntax for routing filter
        //http://localhost:5000/api/movienames/getmovies/?title=frivolinas
        //public async Task<List<Movie>> GetMoviesAsync(Filter filter)
        //{

        //    IQueryable<Movie> q = query;
        //    if (filter.title != null)
        //    {
        //        q = query.Where(m => EF.Functions.Like(m.title, $"%{filter.title}%"));
        //    }
        //    return await q.ToListAsync();
        //}
        public async Task<List<Movie>> GetMoviesAsync(Filter filter)
        {           
             
            var movies = dbContext.movies.AsQueryable().Where(m => EF.Functions.Like(m.title, $"%{filter.title}%")).Take(5);         

            return await movies.ToListAsync();
        }

        public async Task<List<FilterMovie?>> GetListOf8Movies()
        {
            var movies = dbContext.movies_.AsQueryable().Where(m => m.year == 2022).Take(5);
            return await movies.ToListAsync();
        }

    }
}
