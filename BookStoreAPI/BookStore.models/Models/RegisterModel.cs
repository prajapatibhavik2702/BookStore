using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.models.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; } 
        public string Lastname { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public int RoleId { get; set; }
    }
}
