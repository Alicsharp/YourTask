using Common.Application;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg.Services;

namespace TodoList.Application.Todo.ItemList.Edit
{
    public class EditItemListCommand :IBaseCommand
    {
        public long Id { get; set;}
        public string Title { get; set; }
       

        public EditItemListCommand(long id, string title )
        {
            Id = id;
            Title = title;
            
        }
    }
    public class EditItemListCommandHandler : IBaseCommandHandler<EditItemListCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public EditItemListCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<OperationResult> Handle(EditItemListCommand request, CancellationToken cancellationToken)
        {
            var TodoItem=  await _todoRepository.GetTracking(request.Id);
            if(TodoItem == null) { throw new NullOrEmptyDomainDataException(); }
             TodoItem.Edit(request.Title);
           await _todoRepository.Save();
            return OperationResult.Success();

        }
    }
}
