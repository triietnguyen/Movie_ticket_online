using Online_Movie.Models;
using Microsoft.EntityFrameworkCore;
namespace Online_Movie.Repository
{
    public interface IMovieReposistory
    {
        public bool Create(Movie movie);
        public bool Update(Movie movie);
        public bool Delete(int movie);
        public List<Movie> GetAll();

        public List<Movie> GetAllMoviesByCategoryId(int id);


        public Movie findByID(int id);

        public bool checkName(string name);
    }
    public class MovieReposistory : IMovieReposistory
    {
        private MoviesContext _ctx;
        public MovieReposistory(MoviesContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Movie movie)
        {
            _ctx.Movies.Add(movie);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(int ID)
        {
            Movie c = _ctx.Movies.FirstOrDefault(x =>x.MovieId == ID);
            _ctx.Movies.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public bool Update(Movie movie)
        {
            Movie c = _ctx.Movies.FirstOrDefault(x => x.MovieId == movie.MovieId);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(movie);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Movie findByID(int id)
        {
            Movie c = _ctx.Movies.FirstOrDefault(x => x.MovieId == id);
            return c;
        }

        public List<Movie> GetAllMoviesByCategoryId(int id)
        {
            return _ctx.Movies.Where(x => x.CategoryId== id).ToList();
        }
        public bool checkName(string name)
        {
            Movie c = _ctx.Movies.Where(x => x.MovieName.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;

        }
        List<Movie> IMovieReposistory.GetAll()
        {
            return _ctx.Movies.Include(x=>x.Category).ToList();
        }
    }
}
