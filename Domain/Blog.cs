using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    //This is model for Blogs
    //A typical blog will contain Id, Title and Content
    public class Blog
    {
        public Guid BlogId { get; set; }
        public string Title {get; set;}
        public string Content { get; set; }
        public User User {get; set;}
    }
}