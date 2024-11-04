using Common.Domain;
using Common.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using TodoList.Domain.UserAgg;

namespace TodoList.Domain.ToDoAgg
{
    public   class ItemList : AggregateRoot
    {
        public string Title { get; private set; }

        // کلید خارجی برای User
        public long UserId { get; set; }

        // رابطه با User
        [ForeignKey(nameof(UserId))]
        public User User { get; private set; }

        // لیست آیتم‌ها (رابطه یک به چند با Item)
        public List<Item> Items { get; set; }

        public ItemList(string name, long userId,  List<Item> items)
        {
            Title = name;
            UserId = userId;
            Items = items;
        }

        public ItemList() { }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void Edit(string name )
        {

            Title=name;  
        }
        public void RemoveItem(long itemId)
        {

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }
        public void EditItem(Item item, long ItemId)
        {
            var oldItem = Items.FirstOrDefault(f => f.Id == ItemId);
            if (oldItem == null)
                throw new NullOrEmptyDomainDataException("Item Not Exist");
            oldItem.Edit(item.Title, item.Description, item.IsProcessed);

        }
        public void Gurd(string name)
        {
            if (name == null) throw new NullOrEmptyDomainDataException("Name is Null");
        }
    }
  
}
