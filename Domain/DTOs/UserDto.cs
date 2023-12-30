using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    //We use this class to return only certain information about the user
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set;}
        public ICollection<Blog> Blogs {get; set;}
    }
}