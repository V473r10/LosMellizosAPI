using LosMellizosAPI.Contexts;
using LosMellizosAPI.Models;

namespace LosMellizosAPI.Services
{
    public class UserService: IUserService
    {
        private readonly Database _database;

        public UserService(Database database)
        {
            this._database = database;
        }

        public IEnumerable<User> GetUsers()
        {
            return _database.Users!;
        }

        public User GetUser(int id)
        {
            return _database.Users!.FirstOrDefault(user => user.Id == id)!;
        }

        public User CreateUser(User user)
        {
            _database.Users!.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            var userToUpdate = _database.Users!.FirstOrDefault(u => true)!;
            userToUpdate.Name = user.Name;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Email = user.Email;
            userToUpdate.Phone = user.Phone;
            userToUpdate.Password = user.Password;
            userToUpdate.Role = user.Role;
            userToUpdate.Active = user.Active;

            return userToUpdate;
        }

        public User DeleteUser(int id)
        {
            var userToDelete = _database.Users!.FirstOrDefault(user => user.Id == id)!;
            _database.Users!.Remove(userToDelete);
            return userToDelete;
        }
    }

    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}
