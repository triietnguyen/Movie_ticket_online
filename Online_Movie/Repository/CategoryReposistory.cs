using Online_Movie.Models;

namespace Online_Movie.Repository
{
    public interface ICategoryReposistory
    {
        public bool Create(Category category);
        public bool Update(Category category);
        public bool Delete(int category);
        public List<Category> GetAll();

        public Category findByID(int id);

        public bool checkName(string name);
    }
    public class CategoryReposistory : ICategoryReposistory
    {
        private MoviesContext _ctx;
        public CategoryReposistory(MoviesContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(int ID)
        {
            Category c = _ctx.Categories.FirstOrDefault(x=>x.CategoryId== ID);
            _ctx.Categories.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public bool Update(Category category)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(category);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Category findByID(int id)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
            return c;
        }

        public bool checkName(string name)
        {
            Category c = _ctx.Categories.Where(x => x.CategoryName.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;

        }
        List<Category> ICategoryReposistory.GetAll()
        {
            return _ctx.Categories.ToList();
        }
    }
}
