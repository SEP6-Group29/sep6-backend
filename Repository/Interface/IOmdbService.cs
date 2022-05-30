using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository.Interface
{
    public interface IOmdbService
    {
        Task<IEnumerable<FilterMovie>> getMoviePoster(int id);
    }
}
