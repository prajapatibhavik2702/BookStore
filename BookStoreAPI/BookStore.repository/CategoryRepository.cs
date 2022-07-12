using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.Models;
using BookStore.models.ViewModels;

namespace BookStore.repository
{
    public class CategoryRepository
    {
        testContext _context = new testContext();
        public ListResponse<Category> GetCategories(int pageindex, int pagesize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Categories.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int total= query.Count();
            List<Category> categories = query.Skip((pageindex-1)*pagesize).Take(pagesize).ToList();
            return new ListResponse<Category>()
            {
                records = categories,
                totalRecords=total
                
                
            };
        }
        public Category GetCategory(int id)
        {
            try
            {
                var check = _context.Categories.FirstOrDefault(c => c.Id == id);
                if (check == null)
                {
                    return check;
                }
                return check;
            }catch(Exception ex)
            {
                return null;
            }
        }
        public Category AddCategory(Category category)
        {
            var entry= _context.Categories.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }
        public Category UpdateCategory(Category category)
        {
            var entry = _context.Categories.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }
        public Category RemoveCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                var entry = _context.Categories.Remove(category);
                _context.SaveChanges();
                return category;
            }
            
            return category;
        }

    }
}
