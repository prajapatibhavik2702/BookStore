using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;
using BookStore.models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.repository
{
    public class CartRepository { 
     testContext _context = new testContext();
    public ListResponse<Cart> GetCartItems(int id,int pageindex=1,int pagesize=10)
    {
        var query = _context.Carts.Include(c=>c.Book).Where(c =>c.Userid.Equals(id)).AsQueryable();
            var total = query.Count();
            List<Cart> carts = query.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return new ListResponse<Cart>()
            {
                totalRecords = total,
                records = carts
            };
        }
    public Cart GetCart(int id)
    {
        try
        {
            var check = _context.Carts.FirstOrDefault(c => c.Userid == id);
            if (check == null)
            {
                return check;
            }
            return check;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public Cart AddCart(Cart cart)
    {
        var entry = _context.Carts.Add(cart);
        _context.SaveChanges();
        return entry.Entity;
    }
    public Cart UpdateCart(Cart cart)
    {
        var entry = _context.Carts.Update(cart);
        _context.SaveChanges();
        return entry.Entity;
    }
    public Cart RemoveCart(int id)
    {
        var category = _context.Carts.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            var entry = _context.Carts.Remove(category);
            _context.SaveChanges();
            return category;
        }

        return category;
    }

}
}
