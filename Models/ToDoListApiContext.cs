using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Models
{
    public class ToDoListApiContext : DbContext
    {
        public ToDoListApiContext(DbContextOptions<ToDoListApiContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<CategoryItem> CategoryItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Item>()
            .HasData(
                new Item { ItemId = 1, Description = "Walk the doog", Priority = 2 },
                new Item { ItemId = 2, Description = "Pet the cat", Priority = 3 },
                new Item { ItemId = 3, Description = "Water the plants", Priority = 2  },
                new Item { ItemId = 4, Description = "Ask for help", Priority = 3  },
                new Item { ItemId = 5, Description = "meditate", Priority = 4 }
            );
        builder.Entity<Category>()
            .HasData(
                new Category { CategoryId = 1, Name = "Career Goals" },
                new Category { CategoryId = 2, Name = "Life Goals" },
                new Category { CategoryId = 3, Name = "Yolo Goals" },
                new Category { CategoryId = 4, Name = "Friendship" },
                new Category { CategoryId = 5, Name = "Garden" }
            );
        builder.Entity<CategoryItem>()
            .HasData(
                new CategoryItem { CategoryItemId = 1, ItemId = 1, CategoryId = 2 },
                new CategoryItem { CategoryItemId = 2, ItemId = 2, CategoryId = 3 },
                new CategoryItem { CategoryItemId = 3, ItemId = 5, CategoryId = 5 },
                new CategoryItem { CategoryItemId = 4, ItemId = 3, CategoryId = 4 },
                new CategoryItem { CategoryItemId = 5, ItemId = 4, CategoryId = 1 }
            );
        }

    }
}