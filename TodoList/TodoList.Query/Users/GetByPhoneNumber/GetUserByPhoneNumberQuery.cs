using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users.GetByPhoneNumber
{
    public record GetUserByPhoneNumberQuery(string PhoneNumber) : IQuery<UserDto?>;
}
