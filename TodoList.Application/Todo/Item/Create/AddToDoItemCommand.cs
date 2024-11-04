using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Todo.Item.Create
{
    public class AddToDoItemCommand : IBaseCommand
    {
        public AddToDoItemCommand(long parentId ,string title, string description, bool isProcessed)
        {
            ParentId=parentId;
            Title = title;
            Description = description;
            IsProcessed = isProcessed;
        }
        public long ParentId { get; set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public bool IsProcessed { get; private set; }
    }
}
