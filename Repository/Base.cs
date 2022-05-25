using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class Base<T> where T:class
    {
        protected readonly MovieDbContext dbContext;
        protected IQueryable<T> query;
        

        public Base(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
            query = this.dbContext.Set<T>().AsQueryable();
       
        }
    }
}
