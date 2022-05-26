using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class BaseUser<T> where T : class
    {
        protected readonly UserDbContext dbContext;
        protected IQueryable<T> query;


        public BaseUser(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
            query = this.dbContext.Set<T>().AsQueryable();

        }
    }
}
