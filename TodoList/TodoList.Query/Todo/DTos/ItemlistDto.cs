
using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;

namespace TodoList.Query.Todo.DTos
{
    public  class ItemlistDto:BaseDto
    {
        public string Title { get;   set; }
        public long? UserId{  get; set; }   
       
        public List<ItemDto>?  items { get; set; }

    }
}
