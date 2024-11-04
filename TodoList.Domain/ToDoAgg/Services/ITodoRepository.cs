using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.ToDoAgg.Services
{
    public interface ITodoRepository:IBaseRepository<ItemList>
    {
        Task<ItemList> GetCurrentItemList(long id);
        //Task<ItemList> GetCurrentItem(long id);
        Task<bool> DeleteItemList(long id);
    }
}
