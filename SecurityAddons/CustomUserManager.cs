using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAddons
{
    public class CustomUserManager
    {
        private List<User> _users = new List<User>
        {
            new User() { 
                FirstName = "Arthur", 
                LastName = "Olsen", 
                NickName = "Art", 
                UserName = "art1" , 
                Password = "trout" , Roles = new List<String>{ "Admin", "Edit", "View"},
                Email = "artjtrout@yahoo.com",
            },
               new User() { 
                FirstName = "Robert", 
                LastName = "Tester", 
                NickName = "Bob", 
                UserName = "bob1" , 
                Password = "test" , Roles = new List<String>{ "View"},
                Email="bob@test.com"
             },
                new User() { 
                FirstName = "Sally", 
                LastName = "Editor", 
                NickName = "Sal", 
                UserName = "sally1" , 
                Password = "edit" , Roles = new List<String>{"Edit", "View",},
                Email="Sally@test.com"
                },
        };

        public List<User> Users { get { return _users; } }

        public User GetUserIfValid(string userName, string password)
        {
            return (from u in Users
                    where u.UserName == userName && u.Password == password
                    select u).FirstOrDefault();
        }
    }
}
