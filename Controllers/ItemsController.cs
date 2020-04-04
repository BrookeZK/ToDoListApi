using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private ToDoListApiContext _db;

        public ItemsController(ToDoListApiContext db)
        {
        _db = db;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get(string description, int? priority)
        {
            IQueryable<Item> query = _db.Items.AsQueryable();

            if (description != null)
            {
            query = query.Where(entry => entry.Description.Contains(description));
            }

            if (priority != null)
            {
            query = query.Where(entry => entry.Priority == priority);
            }

            return query.ToList();
        }

        // POST api/items
        [HttpPost]
        public void Post([FromBody] Item item, int? categoryId)
        {
            System.Console.WriteLine(categoryId);
            _db.Items.Add(item);
            if (categoryId != null)
            {
                _db.CategoryItem.Add(new CategoryItem() { CategoryId = (int) categoryId, ItemId = item.ItemId });
            }
            _db.SaveChanges();
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            Item foundItem = _db.Items
            // .Include(item => item.Categories)
            // .ThenInclude(join => join.Category)
            .FirstOrDefault(item => item.ItemId == id);
            // foreach (CategoryItem item in foundItem.Categories)
            // {
            //     foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(item.Item))
            //     {
                    
            //         string name=descriptor.Name; 
            //         object value=descriptor.GetValue(item.Item);
            //         Console.WriteLine("{0}={1}",name,value);
            //     }
            //     foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(item.Category))
            //     {
                    
            //         string name=descriptor.Name; 
            //         object value=descriptor.GetValue(item.Category);
            //         Console.WriteLine("{0}={1}",name,value);
            //     }
            // }
            
            // System.Console.WriteLine(foundItem);
            return foundItem;
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public void Put(int id, int categoryId, [FromBody] Item item)
        {
            CategoryItem join = _db.CategoryItem.Where(entry => entry.ItemId == id).FirstOrDefault();
            if (join !=  null)
            {
                if (join.CategoryId != categoryId && categoryId != 0)
                {
                    _db.CategoryItem.Add(new CategoryItem() { CategoryId = categoryId, ItemId = id });
                }
            }
            item.ItemId = id;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        var itemToDelete = _db.Items.FirstOrDefault(entry => entry.ItemId == id);
        _db.Items.Remove(itemToDelete);
        _db.SaveChanges();
        }

        [HttpPost("{id}/add_category/{categoryId}")]
        public void PostCategory(int id, int categoryId)
        {
            if (categoryId != 0)
            {
                _db.CategoryItem.Add(new CategoryItem() { CategoryId = categoryId, ItemId = id });
            }
            _db.SaveChanges();
        }

        [HttpDelete("delete_category/{joinId}")]
        public void DeleteCategory(int id, int joinId)
        {
            var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CategoryItemId == joinId);
            _db.CategoryItem.Remove(joinEntry);
            _db.SaveChanges();
        }
    }
}