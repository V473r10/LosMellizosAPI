using LosMellizosAPI.Contexts;
using LosMellizosAPI.Models;

namespace LosMellizosAPI.Services
{
    public class ProductService: IProductService
    {
        private readonly Database _database;

        public ProductService(Database database)
        {
            _database = database;
        }

        public List<Product> GetProducts()
        {
            return _database.Products!.ToList();
        }

        public Product GetProduct(Guid id)
        {
            return _database.Products!.FirstOrDefault(p => p.Id == id)!;
        }

        public Product CreateProduct(Product product)
        {
            _database.Products!.Add(product);
            _database.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _database.Products!.Update(product);
            _database.SaveChanges();
            return product;
        }

        public void DeleteProduct(Guid id)
        {
            var product = _database.Products!.FirstOrDefault(p => p.Id == id);
            _database.Products!.Remove(product!);
            _database.SaveChanges();
        }
    }

    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(Guid id);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(Guid id);
    }
}
