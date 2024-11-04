using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Todo.Item.Remove
{
    public record RemoveTodoItemCommand(long patrentId, long ItemId) : IBaseCommand;
}
