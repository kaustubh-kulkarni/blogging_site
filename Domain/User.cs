using System;
using System.Collections.Generic;

namespace Domain;

//This is a model class for Users
//User consists of ID, FirstName, LastName, Password and Email
//User will also contain list of blogs created by him
public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email {get; set;}
    public List<Blog> Blogs;
}
