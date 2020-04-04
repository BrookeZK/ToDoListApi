using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ToDoListApiContext _db;

        public CategoriesController(ToDoListApiContext db)
        {
        _db = db;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get(string name)
        {
            IQueryable<Category> query = _db.Categories.AsQueryable();

            if (name != null)
            {
            query = query.Where(entry => entry.Name.Contains(name));
            }

            return query.ToList();
        }

        // POST api/categories
        [HttpPost]
        public void Post([FromBody] Category category)
        {
        _db.Categories.Add(category);
        _db.SaveChanges();
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return _db.Categories
            // .Include(category => category.Items)
            // .ThenInclude(join => join.Item)
            .FirstOrDefault(entry => entry.CategoryId == id);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public void Put(int id, int itemId, [FromBody] Category category)
        {
            CategoryItem join = _db.CategoryItem.Where(entry => entry.CategoryId == id).FirstOrDefault();
            if (join != null)
            {
                if (join.ItemId != itemId && itemId != 0)
                {
                    _db.CategoryItem.Add(new CategoryItem() { CategoryId = id, ItemId = itemId });
                }  
            }
            category.CategoryId = id;
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        var categoryToDelete = _db.Categories.FirstOrDefault(entry => entry.CategoryId == id);
        _db.Categories.Remove(categoryToDelete);
        _db.SaveChanges();
        }
    }
}