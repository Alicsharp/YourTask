using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;
using TodoList.Domain.ToDoAgg.Services;

namespace TodoList.Application.Todo.ItemList.Create
{
    public class CreateItemListCommand : IBaseCommand
    {
        public CreateItemListCommand(string title, long userId, List<Domain.ToDoAgg.Item> items)
        {
            Title = title;
            UserId = userId;
            Items = items;
        }

        public string Title {  get; set; }
        public long UserId { get;   set; }
        public List<Domain.ToDoAgg.Item> Items { get; set; }    

    }
    public class CreateItemListCommandHandler : IBaseCommandHandler<CreateItemListCommand>
    {
        private readonly ITodoRepository _repository;

        public CreateItemListCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateItemListCommand request, CancellationToken cancellationToken)
        {
        
           Domain.ToDoAgg.ItemList item= new Domain.ToDoAgg.ItemList(request.Title,request.UserId,request.Items);
            _repository.Add(item);
          await  _repository.Save();
            return OperationResult.Success();

        }
    }
}
