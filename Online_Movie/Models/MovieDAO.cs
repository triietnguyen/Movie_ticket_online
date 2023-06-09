namespace Online_Movie.Models
{
    public class MovieDAO
    {
        private MoviesContext _ctx = new MoviesContext();

        public MovieDAO() 
        {
            _ctx = new MoviesContext();
        }
        public List<Movie> getAllMovies() 
        {
            return _ctx.Movies.ToList();
        }
        
        /*public void AddMovie()
        {
            Movie movie = new Movie("Hoa Sen", 6, 7, 1000, "Phat","movie1.jpg");
            _ctx.Movies.Add(movie);
            _ctx.SaveChanges();
        } */
        public void RemoveMovieById(string Id)
        {
            Movie movieID = _ctx.Movies.Find(Id);
            _ctx.Movies.Remove(movieID);
            _ctx.SaveChanges();
        }
  
        public void UpdateSkill(Movie movie)
        {
            _ctx.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
