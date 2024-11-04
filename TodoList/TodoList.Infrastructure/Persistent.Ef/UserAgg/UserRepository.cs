using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.UserAgg.Repository;
using TodoList.Domain.UserAgg;
using TodoList.Infrastructure._Utilities;

namespace TodoList.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context)
        {
        }
    }
}
