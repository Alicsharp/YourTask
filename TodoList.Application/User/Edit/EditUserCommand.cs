using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.User.Edit
{
    public class EditUserCommand :IBaseCommand
    {
        public EditUserCommand(long userId, string name, string family, string phoneNumber, string email, string password)
        {
            UserId = userId;    
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }
        public long UserId { get; set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
