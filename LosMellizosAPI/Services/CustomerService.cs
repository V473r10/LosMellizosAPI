using LosMellizosAPI.Contexts;
using LosMellizosAPI.Models;

namespace LosMellizosAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Database _database;

        public CustomerService(Database database)
        {
            _database = database;
        }

        public List<Customer> GetCustomers()
        {
            return _database.Customers!.ToList();
        }

        public ValueTask<Customer?> GetCustomer(Guid id)
        {
            return _database.Customers!.FindAsync(id!);
        }

        public Customer CreateCustomer(Customer customer)
        {
            _database.Customers!.Add(customer);
            _database.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _database.Customers!.Update(customer);
            _database.SaveChanges();
            return customer;
        }

        //public void DeleteCustomer(Guid id)
        //{
        //    var customer = _database.Customers!.FirstOrDefault(c => c.Id == id);
        //    _database.Customers!.Remove(customer!);
        //    _database.SaveChanges();
        //}
    }



    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        ValueTask<Customer?> GetCustomer(Guid id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        //void DeleteCustomer(Guid id);
    }
}
