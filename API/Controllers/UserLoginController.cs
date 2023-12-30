using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly DatabaseContext _context;
        //Default CTOR
        public UserLoginController(DatabaseContext context)
        {
            _context = context;
        }

        //Method for user to login
        [HttpPost]
        public async Task<ActionResult<User>> Login(string firstname, string password)
        {
            //Get the user
            var user = await _context.Users.SingleOrDefaultAsync(x => x.FirstName.ToLower() == firstname);
            //If username is empty or null, we return error
            if(user == null) return Unauthorized("Invalid First Name provided");

            //If we have the username then we check for the password
            if(user.Password != password) return Unauthorized("Invalid password for the user");

            //Return the user info
            return new User{
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
    }
}