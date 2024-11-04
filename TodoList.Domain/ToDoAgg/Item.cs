using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.ToDoAgg
{
    public class Item :BaseEntity
    {
        // کلید خارجی برای ItemList
        public long ItemListId { get; set; }

        // رابطه با ItemList
        [ForeignKey(nameof(ItemListId))]
        public ItemList ItemList { get; set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsProcessed { get; private set; }

        public Item(string title, string description , bool isProcessed)
        {
            Gurd(title, description);
            Title = title;
            Description = description;
            IsProcessed = isProcessed;
        }

        public Item() { }
        public void Edit(string title, string desciption, bool isprocessed=false)
        {
            Title=title;
            Description=desciption;
            IsProcessed = isprocessed;
        }
       public void Gurd(string  title , string description)
        {
            if( title == null || description == null )
            {
                throw new NullOrEmptyDomainDataException("Title Or Description Is Empty");
            }
        }
    }
}
