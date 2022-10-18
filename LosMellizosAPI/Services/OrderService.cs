using LosMellizosAPI.Contexts;
using LosMellizosAPI.Models;

namespace LosMellizosAPI.Services
{
    public class OrderService: IOrderService
    {
        private readonly Database _database;

        public OrderService(Database database)
        {
            this._database = database;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _database.Orders!;
        }

        public Order GetOrder(int id)
        {
            return _database.Orders!.FirstOrDefault(order => order.Id == id)!;
        }

        public Order CreateOrder(Order order)
        {
            _database.Orders!.Add(order);
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            var orderToUpdate = _database.Orders!.FirstOrDefault(o => true)!;
            orderToUpdate.CustomerId = order.CustomerId;
            orderToUpdate.Address = order.Address;
            orderToUpdate.Products = order.Products;
            orderToUpdate.ListPrice = order.ListPrice;
            orderToUpdate.Discount = order.Discount;
            orderToUpdate.TotalPrice = order.TotalPrice;
            orderToUpdate.UpdateDate = order.UpdateDate;
            orderToUpdate.DeliveryDate = order.DeliveryDate;
            orderToUpdate.Status = order.Status;

            return orderToUpdate;
        }

        public Order DeleteOrder(int id)
        {
            var orderToDelete = _database.Orders!.FirstOrDefault(order => order.Id == id)!;
            _database.Orders!.Remove(orderToDelete);
            return orderToDelete;
        }


    }

    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        Order CreateOrder(Order order);
        Order UpdateOrder(Order order);
        Order DeleteOrder(int id);
    }
}
