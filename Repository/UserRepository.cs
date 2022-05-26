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

        public async Task<User> CreateUser(User userDto)
        {

            var users = dbContext.users.Add(userDto);
            dbContext.SaveChanges();
            return userDto;
            
        }
        public User GetById(int id)
        {

            return dbContext.users.FirstOrDefault(o => o.id == id);
        }

        
    }
}
