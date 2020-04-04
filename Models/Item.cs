using System.Collections.Generic;

namespace ToDoListApi.Models
{
    public class Item
    {
        public Item()
        {
            this.Categories = new List<CategoryItem>();
        }

        public int ItemId { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public ICollection<CategoryItem> Categories { get; set;}
    }
}