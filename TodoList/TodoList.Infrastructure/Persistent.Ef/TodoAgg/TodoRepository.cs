using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;
using TodoList.Domain.ToDoAgg.Services;
using TodoList.Infrastructure._Utilities;

namespace TodoList.Infrastructure.Persistent.Ef.TodoAgg
{
    internal class TodoRepository : BaseRepository<ItemList>, ITodoRepository
    {
     
        public TodoRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<bool> DeleteItemList(long id)
        {
            var itemlist = await Context.ItemList.Include(c => c.Items).FirstOrDefaultAsync(f => f.Id == id);
            if (itemlist == null) return false;

              Context.ItemList.Remove(itemlist); 
            return true;

        }

       
        public async Task<ItemList> GetCurrentItemList(long ItemListId)
        {
            return await Context.ItemList.FirstOrDefaultAsync(f =>f.Id==ItemListId);
        }
    }
}
