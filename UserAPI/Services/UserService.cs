using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User AddUser(User product)
        {
            var result = context.Users.Add(product);
            context.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(int Id)
        {
            var filteredData = context.Users.Where(x => x.UserId == Id).FirstOrDefault();
            var result = context.Remove(filteredData);
            context.SaveChanges();
            return result != null ? true : false;
        }

        public User GetUserById(int id)
        {
            return context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUserList()
        {
            return context.Users.ToList();
        }

        public User UpdateUser(User product)
        {
            var result = context.Users.Update(product);
            context.SaveChanges();
            return result.Entity;
        }
    }
}
