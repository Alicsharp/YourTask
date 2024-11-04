using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.User.RemoveToken
{
    public record RemoveUserTokenCommand(long UserId, long TokenId) : IBaseCommand;
}
