using _StarbucksApi.Data;
using _StarbucksApi.Entities;
using _StarbucksApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _StarbucksApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class AnonymousController : ControllerBase
    {
        private readonly StarbucksContext _context;
        public AnonymousController(StarbucksContext context)
        {
            _context = context;
        }

        [HttpPost("Register")] 
        public IActionResult Register(SaveUserViewModel users)
        {
            var user = new User()
            {
                FullName = users.FullName,
                Email = users.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }


    }
}
