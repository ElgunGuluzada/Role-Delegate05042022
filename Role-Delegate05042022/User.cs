using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Role_Delegate05042022
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }


        public User(string username, string email, Role role)
        {
            Username = username;
            Email = email;
            Role = role;
        }

        public void ShowInfo()
        {

        }
    }
}
