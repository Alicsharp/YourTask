using Common.Application;
using TodoList.Domain.ToDoAgg;
using TodoList.Domain.ToDoAgg.Services;

namespace TodoList.Application.Todo.Item.Edit
{
    public class EditToDoItemCommandHandler : IBaseCommandHandler<EditToDoItemCommand>
    {
        private readonly ITodoRepository _repository;

        public EditToDoItemCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetTracking(request.ParentId);

            Domain.ToDoAgg.Item Item = new Domain.ToDoAgg.Item(request.Title, request.Description, request.IsProcessed);


            item.EditItem(Item, request.ItemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
