using Common.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Infrastructure.Persistent.Ef;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users.GetById
{
    public class GetUserByIdQuery : IQuery<UserDto?>
    {
        public GetUserByIdQuery(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; private set; }
    }
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly ToDoContext _context;

        public GetUserByIdQueryHandler(ToDoContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
            if (user == null)
                return null;


            return   user.Map();
        }
    }
}
