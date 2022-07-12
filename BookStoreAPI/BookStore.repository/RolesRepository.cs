using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.Models;
using BookStore.models.ViewModels;
namespace BookStore.repository
{
    public class RolesRepository
    {
        testContext _context=new testContext();
        public ListResponse<Role> GetRoles(int pageindex, int pagesize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Roles.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int total = query.Count();
            List<Role> roles = query.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return new ListResponse<Role>()
            {
                records = roles,
                totalRecords = total


            };
        }
    }
}
