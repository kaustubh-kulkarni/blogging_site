using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class UserLoginController : ControllerBase
    {
        //Get the DatabaseContext to query against
        private readonly DatabaseContext _context;
        //Default CTOR
        public UserLoginController(DatabaseContext context)
        {
            _context = context;
        }

        //Method for user to login
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            //Get the user
            var user = await _context.Users.SingleOrDefaultAsync(x => x.FirstName.ToLower() == loginDto.FirstName);
            //If username is empty or null, we return error
            if(user == null) return Unauthorized("Invalid First Name provided");

            //If we have the username then we check for the password
            if(user.Password != loginDto.Password) return Unauthorized("Invalid password for the user");

            //Return the user info
            return new UserDto{
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}