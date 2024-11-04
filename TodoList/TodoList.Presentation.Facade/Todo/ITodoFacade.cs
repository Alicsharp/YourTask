using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Todo.Item.Create;
using TodoList.Application.Todo.Item.Edit;
using TodoList.Application.Todo.Item.Remove;
using TodoList.Application.Todo.ItemList.Create;
using TodoList.Application.Todo.ItemList.Edit;
using TodoList.Application.Todo.ItemList.Remove;
using TodoList.Query.Todo;
using TodoList.Query.Todo.DTos;
using TodoList.Query.Todo.GetAllTodo;
using TodoList.Query.Todo.GetItemListById;

namespace TodoList.Presentation.Facade.Todo
{
    public interface ITodoFacade
    {
        Task<OperationResult> Create(AddToDoItemCommand command);
        Task<OperationResult> CreateItem(CreateItemListCommand command);
        Task<OperationResult> Edit(EditToDoItemCommand command);
        Task<OperationResult> RemoveItemList( long ItemListId  );
        Task<OperationResult> EditItemList(EditItemListCommand command);
        Task<OperationResult> EditItem(EditToDoItemCommand command);
        Task<ItemlistDto> GetItemListByIdQuery(long ItemListId);
        Task<OperationResult> RemoveItem(long parentid,long ItemId);

        Task<List<ItemlistDto?>> GetAll( long UserId);
        Task<ItemDto> GetItemById(long ItemId);


    }
}
