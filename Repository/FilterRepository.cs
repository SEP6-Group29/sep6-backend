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
          //  query = query
          //.Include(f => f.rating);
          

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
        public async Task<List<FilterMovie>> GetMoviesAsync(Filter filter)
        {           
             
            var movies = dbContext.movies_.AsQueryable().Where(m => EF.Functions.Like(m.title, $"%{filter.title}%")).Take(5);         

            return await movies.ToListAsync();
        }
       
        public async Task<List<FilterMovie?>> GetListOf8Movies()
        {
            //var movies = dbContext.movies_.AsQueryable().Where(m => m.year == 2021).OrderByDescending(m => m.id).Take(8);
            var movies = dbContext.movies_.AsQueryable().Where(m => m.year == 2021).Take(8);


            return await movies.ToListAsync();

        }
        //public async Task<List<FilterMovie?>> GetPoster()
        //{
        //  var movies = dbContext.movies_

        //}
        public async Task<List<FilterMovie?>> GetListofDecade(int decade)
        {
            var decade80 = dbContext.movies_.AsQueryable().Where(m => m.year < 1990 && m.year > 1979).Take(5); //80s 8
            var decade90 = dbContext.movies_.AsQueryable().Where(m => m.year < 2000 && m.year > 1989).Take(5);//90 9
            var decade00 = dbContext.movies_.AsQueryable().Where(m => m.year < 2010 && m.year > 1999).Take(5);//00 0
            var decade10 = dbContext.movies_.AsQueryable().Where(m => m.year < 2020 && m.year > 2009).Take(5);//10 10
            if(decade == 8)
            {
               return await decade80.ToListAsync();

            }
            else if(decade == 9)
            {
                return await decade90.ToListAsync();
            }
            else if(decade == 10)
            {
                return await decade10.ToListAsync();

            }
            else 
            {
                return await decade00.ToListAsync();
            }
            
            
            //return await movies.ToListAsync();

        }

    }
}
