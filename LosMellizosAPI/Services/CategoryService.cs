using LosMellizosAPI.Contexts;
using LosMellizosAPI.Models;

namespace LosMellizosAPI.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly Database _database;

        public CategoryService(Database database)
        {
            _database = database;
        }

        public List<Category> GetCategories()
        {
            return _database.Categories!.ToList();
        }

        public Category GetCategory(int id)
        {
            return _database.Categories!.FirstOrDefault(c => c.Id == id)!;
        }

        public Category CreateCategory(Category category)
        {
            _database.Categories!.Add(category);
            _database.SaveChanges();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            _database.Categories!.Update(category);
            _database.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var category = _database.Categories!.FirstOrDefault(c => c.Id == id);
            _database.Categories!.Remove(category!);
            _database.SaveChanges();
        }
    }

    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
