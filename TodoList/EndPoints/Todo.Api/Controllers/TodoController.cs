using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoList.Application.Todo.Item.Create;
using TodoList.Application.Todo.Item.Edit;
using TodoList.Application.Todo.ItemList.Create;
using TodoList.Application.Todo.ItemList.Edit;
using TodoList.Application.Todo.ItemList.Remove;
using TodoList.Presentation.Facade.Todo;
using TodoList.Query.Todo;
using TodoList.Query.Todo.DTos;
using TodoList.Query.Todo.GetAllTodo;

namespace Todo.Api.Controllers
{
    [Authorize]
    public class TodoController : ApiController
    {
        private readonly ITodoFacade _facade;

        public TodoController(ITodoFacade facade)
        {
            _facade = facade;
        }

        //[HttpGet("GetAll")]
        //public async Task<ApiResult<List<ItemlistDto>>> GetList([FromQuery] long userId)
        //{

        //    var result = await _facade.GetAll(userId);
        //    return QueryResult(result);
        //}
        [HttpGet("GetAll")]
        public async Task<ApiResult<List<ItemlistDto>>> GetList()
        {
            var userId = User.GetUserId();
            var result = await _facade.GetAll(userId);
            return QueryResult(result);
        }
        [HttpGet("GetItemById")]
        public async Task<ApiResult<ItemDto>> GetItemById(long ItemId)
        {
            var result = await _facade.GetItemById(ItemId);
            return QueryResult(result);
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create( AddToDoItemCommand command)
        {
            var result = await _facade.Create(command);
            return CommandResult(result);
        }

        [HttpPost("CreateItem")]
        public async Task<ApiResult> CreateItem(CreateItemListCommand command)
        {
            var result = await _facade.CreateItem(command);
            return CommandResult(result);
        }
        [HttpPut("EditItemList")]
        public async Task<ApiResult> EditItemList( EditItemListCommand EditItemList)
        {
            var result = await _facade.EditItemList(EditItemList);
            return CommandResult(result);
        }
        [HttpDelete("RemoveList/{RemoveItemListId}")]
        public async Task<ApiResult> RemoveItemList(long RemoveItemListId)
        {
            var result = await _facade.RemoveItemList(RemoveItemListId);
            return CommandResult(result);
        }

        [HttpDelete("RemoveItem/{RemoveItemId}")]
        public async Task<ApiResult> RemoveItem([FromQuery] long parentId, long RemoveItemId)
        {
            var result = await _facade.RemoveItem(parentId, RemoveItemId);
            return CommandResult(result);
        }



        [HttpPut("EditItem")]
        public async Task<ApiResult> EditItem([FromBody]EditToDoItemCommand command)
        {
            var result = await _facade.EditItem(command);
            return CommandResult(result);
        }
        [HttpGet("GetItemListById")]
        public async Task<ApiResult<ItemlistDto>> GetItemListById(long GetItemListById)
        {
            var result=await _facade.GetItemListByIdQuery(GetItemListById);
            return QueryResult(result);

        }

    }
}
