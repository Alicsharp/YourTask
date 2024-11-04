using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Infrastructure.Persistent.Dapper;
using TodoList.Infrastructure.Persistent.Ef;
using TodoList.Query.Todo.DTos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TodoList.Query.Users.DTOs;
using Dapper;
using TodoList.Domain.ToDoAgg;

namespace TodoList.Query.Todo
{
    public class GetItemByIdQuery:IQuery<ItemDto>
    {
    
        public GetItemByIdQuery(  long itemId)
        {
           
            ItemId = itemId;
             
        }

    
        public long ItemId { get; set;}
    }
    public class GetItemByIdQueryHandler : IQueryHandler<GetItemByIdQuery,ItemDto>
    {
        private readonly DapperContext _dapperContext;

        public GetItemByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
             var sql = $"SELECT TOP(1) Id, ItemListId, Title, Description, IsProcessed, CreationDate FROM {_dapperContext.Item} WHERE Id = @Id";

            return await   connection.QueryFirstOrDefaultAsync<ItemDto>(sql, new {  Id =request.ItemId });
        }
    }
}
