using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using user_test.Models;
using user_test.Data;

namespace user_test.Repository
{    
    public class UserRepository
    {
        private readonly UserContext _context = null;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public User AddNewUser(UserModel user)
        {
            var newUser = new User()
            {                
                name = user.name,
                email = user.email,
                password = user.password
            };
            _context.User.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = new List<UserModel>();
            var userData = _context.User.ToList();
            foreach (var u in userData)
            {
                users.Add(new UserModel(){
                    id = u.id,
                    name = u.name,
                    email = u.email,                    
                });
            }
            return users;
        }
    }
}
