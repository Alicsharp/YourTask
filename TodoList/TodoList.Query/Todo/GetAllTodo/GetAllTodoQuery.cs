using Common.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Infrastructure.Persistent.Ef;
using TodoList.Query.Todo.DTos;

namespace TodoList.Query.Todo.GetAllTodo
{
    public class GetAllTodoQuery : IQuery<List<ItemlistDto>>
    {
        public GetAllTodoQuery(long userId )
        {
            UserId = userId;
             
        }

        public long UserId { get; set; }
        
    }
    public class GetAllTodoQueryHandler : IQueryHandler<GetAllTodoQuery, List<ItemlistDto>>
    {
        private readonly ToDoContext toDoContext;

        public GetAllTodoQueryHandler(ToDoContext _toDoContext)
        {
            toDoContext = _toDoContext;
        }

        public async Task<List<ItemlistDto>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            var todo = await toDoContext.ItemList
                 .Include(s => s.Items)
                 .Where(x => x.UserId == request.UserId)  // Filter by UserId
                 .OrderByDescending(x => x.Id)  // Order by Id in descending order
                 .ToListAsync();

            var model = todo.Map();
            return model;
        }
    }
}