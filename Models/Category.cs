using System.Collections.Generic;

namespace ToDoListApi.Models
{
    public class Category
    {
         public Category()
        {
            this.Items = new List<CategoryItem>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryItem> Items { get; set; }
    }
}