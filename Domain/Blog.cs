using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    //This is model for Blogs
    //A typical blog will contain Id, Content
    public class Blog
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}