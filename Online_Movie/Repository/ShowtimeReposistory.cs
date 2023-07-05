using Online_Movie.Models;

namespace Online_Movie.Repository
{
    public interface IShowtimeReposistory
    {
        public bool Create(Showtime showtime);
        public bool Update(Showtime showtime);
        public bool Delete(int showtime);
        public List<Showtime> GetAll();

        public List<Showtime> GetAllShowtimesByMovieId(int id);

        public Showtime findByID(int id);

        public bool checkName(string name);
    }
    public class ShowtimeReposistory : IShowtimeReposistory
    {
        private MoviesContext _ctx;
        public ShowtimeReposistory(MoviesContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Showtime showtime)
        {
            _ctx.Showtimes.Add(showtime);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(int ID)
        {
            Showtime c = _ctx.Showtimes.FirstOrDefault(x=>x.Id== ID);
            _ctx.Showtimes.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public bool Update(Showtime showtime)
        {
            Showtime c = _ctx.Showtimes.FirstOrDefault(x => x.Id == showtime.Id);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(showtime);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Showtime findByID(int id)
        {
            Showtime c = _ctx.Showtimes.FirstOrDefault(x => x.Id == id);
            return c;
        }

        public List<Showtime> GetAllShowtimesByMovieId(int id)
        {
            return _ctx.Showtimes.Where(x => x.MovieId == id).ToList();
        }
        public bool checkName(string name)
        {
            Category c = _ctx.Categories.Where(x => x.CategoryName.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;

        }
        List<Showtime> IShowtimeReposistory.GetAll()
        {
            return _ctx.Showtimes.ToList();
        }
    }
}
