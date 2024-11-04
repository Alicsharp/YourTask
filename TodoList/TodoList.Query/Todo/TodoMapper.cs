using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;
using TodoList.Query.Todo.DTos;

namespace TodoList.Query.Todo
{
    public static class TodoMapper
    {
        public static ItemlistDto Map(this ItemList dto)
        {
            return new ItemlistDto()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                Title = dto.Title,
                CreationDate = dto.CreationDate,
            
                 items = dto.Items.Select(x => new ItemDto() { Id=x.Id,CreationDate=x.CreationDate,Description=x.Description,IsProcessed=x.IsProcessed,Title=x.Title}).ToList(),   
       
            };


        }
        public static ItemDto Map(this Item dto)
        {
            return new ItemDto()
            {
                Id = dto.Id,
                Title = dto.Title,
                CreationDate = dto.CreationDate,
                IsProcessed = dto.IsProcessed,

            };
        }
        public static List<ItemlistDto> Map(this List<ItemList> dto)
        {
            var model=new List<ItemlistDto>();
            dto.ForEach(B =>
            {
                model.Add(new ItemlistDto()
                {
                    Id = B.Id,
                    Title = B.Title,
                    items = B.Items?.Select(item => new ItemDto
                    {
                        Id = item.Id,
                        Title = item.Title,
                      CreationDate= item.CreationDate,
                        ItemListId=item.ItemListId,
                        Description = item.Description,
                        IsProcessed = item.IsProcessed
                    }).ToList()
                });
                 
 
            });
            return model;

        }
    }
}
