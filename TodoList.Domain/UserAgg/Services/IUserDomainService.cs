using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        bool IsEmailExist(string email);

        bool PhoneNumberIsExist(string phoneNumber);
    }
}
