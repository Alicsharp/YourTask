using Common.Application;
using TodoList.Domain.ToDoAgg.Services;

namespace TodoList.Application.Todo.Item.Remove
{
    public class RemoveTodoItemCommandHandler : IBaseCommandHandler<RemoveTodoItemCommand>
    {
        ITodoRepository _repository;

        public RemoveTodoItemCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveTodoItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetTracking(request.patrentId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.RemoveItem(request.ItemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
