using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository.Interface
{
    public interface IMovieRepository
    {
      
        Task<Movie?> GetMovie(int id);
        Task<List<Movie>> GetMoviesAsync(Filter filter);
        Task<List<Movie>> AddMovieToFavList();
       
    }
}
