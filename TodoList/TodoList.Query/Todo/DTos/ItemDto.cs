
using Common.Query;

namespace TodoList.Query.Todo.DTos
{
    public class ItemDto  :BaseDto
    {
        public long ItemListId {  get; set; }
        public string Title { get;   set; }

        public string Description { get;   set; }

        public bool IsProcessed { get;   set; }

    }
}
