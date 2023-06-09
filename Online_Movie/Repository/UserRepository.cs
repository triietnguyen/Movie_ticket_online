using Online_Movie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace Online_Movie.Repository
{
    public interface IUserReposistory
    {
        public bool Create(User user);
        public bool Delete(int id);
        public List<User> GetAll();

        public User findByID(int id);

        public bool checkUsername(string username);
        public bool checkEmail(string email);

        public bool checkLogin(string username, string password);
    }
    public class UserRepository : IUserReposistory
    {
        private MoviesContext _ctx;
        public UserRepository(MoviesContext ctx)
        {
            _ctx = ctx;
        }

        public bool Create(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            User c = _ctx.Users.FirstOrDefault(x => x.Id == id);
            _ctx.Users.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public User findByID(int id)
        {
            User c = _ctx.Users.FirstOrDefault(x => x.Id == id);
            return c;
        }

        public bool checkUsername(string username)
        {
            User c = _ctx.Users.Where(x => x.UserName.Trim() == username.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }

        public bool checkEmail(string email)
        {
            User c = _ctx.Users.Where(x => x.Email.Trim() == email.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }

        public bool checkLogin(string username, string password)
        {
            User c = _ctx.Users.Where(x => x.UserName.Trim() == username.Trim() && x.Password == password).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }
    }
}
