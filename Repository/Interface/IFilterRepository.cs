using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository.Interface
{
    public interface IFilterRepository
    {
       
        Task<List<FilterMovie>> GetMoviesAsync(Filter filter);
        Task<List<FilterMovie>> GetListOf8Movies();

    }
}
