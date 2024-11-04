using Common.Application;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg.Services;

namespace TodoList.Application.Todo.ItemList.Remove
{
    public record RemoveItemlistCommand( long ItemListId):IBaseCommand;
    public class RemoveItemlistCommandHandler : IBaseCommandHandler<RemoveItemlistCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public RemoveItemlistCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<OperationResult> Handle(RemoveItemlistCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.DeleteItemList(request.ItemListId);
            if (todo == null) { throw new NullOrEmptyDomainDataException(); }
            
            await _todoRepository.Save();
            return OperationResult.Success();
        }
    }

}
