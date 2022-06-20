using _StarbucksApi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _StarbucksApi.Entities
{
    public class User
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string PasswordSalt { get; set; }

        public UserRole Role { get; set; }
        
    }
}
