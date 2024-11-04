using Common.Query;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;
using TodoList.Infrastructure.Persistent.Dapper;
using TodoList.Query.Todo.DTos;

namespace TodoList.Query.Todo.GetItemListById
{
    public record GetItemListByIdQuery(long ItemListId) :IQuery<ItemlistDto>;
    public class GetItemListByIdQueryHandler : IQueryHandler<GetItemListByIdQuery, ItemlistDto>
    {
        private readonly DapperContext _dapperContext;

        public GetItemListByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ItemlistDto> Handle(GetItemListByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT Top(1) * FROM {_dapperContext.ItemList} WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<ItemlistDto>(sql, new { Id = request.ItemListId });
        }
    }
}
