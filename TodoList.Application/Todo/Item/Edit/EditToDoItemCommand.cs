using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;

namespace TodoList.Application.Todo.Item.Edit
{
    public class EditToDoItemCommand : IBaseCommand
    {
        public EditToDoItemCommand(long parentId,long itemId  ,string title, string description, bool isProcessed)
        {
            ParentId = parentId;
            ItemId = itemId;
            Title = title;
            Description = description;
            IsProcessed = isProcessed;
          
        }
        public long ParentId { get; set; }
        public long ItemId { get; set; }
        public string Title { get;   set; }
        public string Description { get;   set; }
        public bool IsProcessed { get;   set; }
    }
}
