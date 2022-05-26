using MovieApp.Data;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public interface IUserRepository
    {
        User GetUsers(string username);
        Task<User> CreateUser(User user);
        User GetById(int id);

    }
}