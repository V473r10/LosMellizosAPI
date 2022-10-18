using LosMellizosAPI.Contexts;
using LosMellizosAPI.Models;

namespace LosMellizosAPI.Services
{
    public class CustomerClassService: ICustomerClassService
    {
        private readonly Database _database;

        public CustomerClassService(Database database)
        {
            _database = database;
        }

        public IEnumerable<CustomerClass> GetCustomerClasses()
        {
            return _database.CustomerClasses!;
        }

        public ValueTask<CustomerClass?> GetCustomerClass(int id)
        {
            return _database.CustomerClasses!.FindAsync(id);
        }

        public async Task<CustomerClass> CreateCustomerClass(CustomerClass customerClass)
        {
            await _database.CustomerClasses!.AddAsync(customerClass);
            return customerClass;
        }

        public async Task<CustomerClass> UpdateCustomerClass(int id, CustomerClass customerClass)
        {
            var customerClassToUpdate = await _database.CustomerClasses!.FindAsync(id);

            customerClassToUpdate!.Name = customerClass.Name;
            customerClassToUpdate.Threshold = customerClass.Threshold;
            customerClassToUpdate.Discount = customerClass.Discount;

            await _database.SaveChangesAsync();

            return customerClassToUpdate;
        }

        public async Task<CustomerClass> DeleteCustomerClass(int id)
        {
            var customerClassToDelete = await _database.CustomerClasses!.FindAsync(id);
            _database.CustomerClasses!.Remove(customerClassToDelete!);
            return customerClassToDelete!;
        }
    }

    public interface ICustomerClassService
    {
        IEnumerable<CustomerClass> GetCustomerClasses();
        ValueTask<CustomerClass?> GetCustomerClass(int id);
        Task<CustomerClass> CreateCustomerClass(CustomerClass customerClass);
        Task<CustomerClass> UpdateCustomerClass(int id, CustomerClass customerClass);
        Task<CustomerClass> DeleteCustomerClass(int id);
    }
}
