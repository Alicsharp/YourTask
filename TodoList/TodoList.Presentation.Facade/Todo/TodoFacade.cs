using Common.Application;
using MediatR;
using TodoList.Application.Todo.Item.Create;
using TodoList.Application.Todo.Item.Edit;
using TodoList.Application.Todo.Item.Remove;
using TodoList.Application.Todo.ItemList.Create;
using TodoList.Application.Todo.ItemList.Edit;
using TodoList.Application.Todo.ItemList.Remove;
using TodoList.Domain.ToDoAgg;
using TodoList.Query.Todo;
using TodoList.Query.Todo.DTos;
using TodoList.Query.Todo.GetAllTodo;
using TodoList.Query.Todo.GetItemListById;

namespace TodoList.Presentation.Facade.Todo
{
    public class TodoFacade : ITodoFacade
    {
        private readonly IMediator _mediator;

        public TodoFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(AddToDoItemCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<OperationResult> CreateItem(CreateItemListCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<OperationResult> Edit(EditToDoItemCommand command)
        { 
            return await _mediator.Send(command);

        }

        public async Task<OperationResult> EditItem(EditToDoItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditItemList(EditItemListCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<ItemlistDto?>> GetAll(long UserId)
        {
            return await _mediator.Send(new GetAllTodoQuery(UserId));


        }

        public async Task<ItemDto> GetItemById( long ItemId)
        {
            return await _mediator.Send(new GetItemByIdQuery(ItemId));
        }

        public async Task<ItemlistDto> GetItemListByIdQuery(long ItemListId)
        {
            return await _mediator.Send(new GetItemListByIdQuery(ItemListId));
        }

        public async Task<OperationResult> RemoveItem(long parentId,long ItemId)
        {
            return await _mediator.Send(new RemoveTodoItemCommand(parentId,ItemId));

        }

        public async Task<OperationResult> RemoveItemList(long ItemListId  )
        {
            return await _mediator.Send(new RemoveItemlistCommand(ItemListId)) ;

        }
    }
}
