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
    public class UserRegisterController : ControllerBase
    {
        //Get the DatabaseContext to query against
        private readonly DatabaseContext _context;
        //Default CTOR
        public UserRegisterController(DatabaseContext context)
        {
            _context = context;
        }


        //Method to register a user and add it to DB
        [HttpPost]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            //Check if the user already exists, if so we cannot register it
            var username = await _context.Users.FirstOrDefaultAsync(x => x.FirstName.ToLower() == registerDto.FirstName);

            //If user is present we throw error
            if(username != null) return BadRequest("User already exists.");

            //If user does not exist, we add it to db
            //Setup the return object
            var user = new User{
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = registerDto.Password
            };
            

            //Add user to db
            _context.Users.Add(user);

            //Save changes to DB
            await _context.SaveChangesAsync();

            //return it
            return new User{
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email
            };
        }
    }
}