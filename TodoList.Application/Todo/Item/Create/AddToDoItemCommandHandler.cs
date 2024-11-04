using Common.Application;
using TodoList.Domain.ToDoAgg;
using TodoList.Domain.ToDoAgg.Services;

namespace TodoList.Application.Todo.Item.Create
{
    public class AddToDoItemCommandHandler : IBaseCommandHandler<AddToDoItemCommand>
    {
        private readonly ITodoRepository _repository;

        public AddToDoItemCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

     

        public async Task<OperationResult> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {

            var todo = await _repository.GetTracking(request.ParentId);
            var TodoItem =  new Domain.ToDoAgg.Item(request.Title, request.Description,request.IsProcessed);
              todo.AddItem(TodoItem);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
