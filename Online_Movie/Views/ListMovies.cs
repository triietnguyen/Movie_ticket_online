using Online_Movie.Models;

namespace Online_Movie.Views
{
    public class ListMovies
    {
        public ListMovies(List<Movie> movies)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-10} | {1, -20} | {2,-10} | {4, -20} | {5,-10}", "ID", "MovieName", "Rating", "Likes", "Actors"));
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

            foreach (Movie movie in movies)
            {
                Console.WriteLine(String.Format("{0,-10} | {1, -20} | {2,-10} | {3,-15} | {4, -20} | {5,-10}", movie.MovieId, movie.MovieName,movie.Rating,movie.Likes,movie.Actors));
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        }
    }
}
