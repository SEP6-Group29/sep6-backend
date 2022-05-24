using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class MovieRepository : Base<Movie>, IMovieRepository
    {
        //private readonly MovieDbContext movieDbContext;

        public MovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
            query = query
             .Include(f => f.rating)
             .Include(f => f.stars).ThenInclude(f => f.person)
               .Include(f => f.directors).ThenInclude(f => f.person);
            //this.movieDbContext = dbContext;
        }

        //------------------GET MOVIE BY ID
        public async Task<Movie?> GetMovie(int id)
        {
           
            return await query.FirstOrDefaultAsync(o => o.id ==  id);
        }

        //-----------------GET MOVIE BY TITLE (FILTERING)
        //syntax for routing filter
        //http://localhost:5000/api/movienames/getmovies/?title=frivolinas
        public async Task<List<Movie>> GetMoviesAsync(Filter filter)
        {
            IQueryable<Movie> q = query;
            if (filter.title != null)
            {
                q = query.Where(m => EF.Functions.Like(m.title, $"%{filter.title}%"));
            }
            return await q.ToListAsync();
        }
       
      }
}
