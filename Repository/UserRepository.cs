using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class UserRepository : BaseUser<User>, IUserRepository
    {
        //private readonly MovieDbContext movieDbContext;

        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
           

            //this.movieDbContext = dbContext;
        }

        //------------------GET MOVIE BY ID
        public User GetUsers(string username)
        {

            return dbContext.users.FirstOrDefault(o => o.username == username);
        }
        public async Task<List<User>> GetUsersAsync()
        {

            var users = dbContext.users.AsQueryable().Take(5);

            return await users.ToListAsync();
        }
      

        public async Task<User> CreateUser(User user)
        {

            dbContext.users.Add(user);
            user.id= dbContext.SaveChanges();
            return user;
            
        }
        public User GetById(int id)
        {

            return dbContext.users.FirstOrDefault(o => o.id == id);
        }

        
    }
}
