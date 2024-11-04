using Common.Query;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Persistent.Ef;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users.GetByPhoneNumber
{
    public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
    {
        private readonly ToDoContext _context;

        public GetUserByPhoneNumberQueryHandler(ToDoContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber, cancellationToken);

            if (user == null)
                return null;


            return   user.Map();

        }
    }
}
