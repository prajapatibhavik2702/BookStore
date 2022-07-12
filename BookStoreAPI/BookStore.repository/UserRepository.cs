using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;
using BookStore.models.Models;
namespace BookStore.repository
{
    public class UserRepository
    {
        testContext _context=new testContext();
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User Login(LoginModel login)
        {
            return _context.Users.FirstOrDefault(c => c.Email.Equals(login.email.ToLower()) && c.Password.Equals(login.password));
        }
        public User Register(RegisterModel register)
        {
            var check = _context.Users.FirstOrDefault(c => c.Email.Equals(register.Email.ToLower()));
            if (check == null)
            {
                User user = new User()
                {
                    Firstname = register.Firstname,
                    Lastname = register.Lastname,
                    Email = register.Email,
                    Password = register.Password,
                    RoleId = register.RoleId,

                };
                var entry = _context.Users.Add(user);
                _context.SaveChanges();
                return entry.Entity;
            }
            else
            {
                return null;
            }
        }
    }
}
