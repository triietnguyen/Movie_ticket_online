using Online_Movie.Models;
namespace Online_Movie.Views
{
    public class ViewDeleteMovieId
    {
        public string Id { get; set; }
        public ViewDeleteMovieId()
        {
            Console.WriteLine("Enter BookId");
            Id = Console.ReadLine();
        }
    }
}
