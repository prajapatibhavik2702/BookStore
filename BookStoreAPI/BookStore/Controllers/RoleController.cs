using Microsoft.AspNetCore.Mvc;
using BookStore.repository;
using BookStore.models.Models;
namespace BookStore.Controllers
{
    [Route("role")]
    [ApiController]

    public class RoleController : Controller
    {
        RolesRepository repository = new RolesRepository();
        [HttpPost]
        [Route("list")]
        public IActionResult GetRoles(int pageindex = 1, int pagesize = 10, string? keyword = "")
        {
            var role = repository.GetRoles(pageindex, pagesize, keyword);
            ListResponse<RoleModel> listResponse = new ListResponse<RoleModel>()
            {
                records = role.records.Select(c => new RoleModel(c)),
                totalRecords = role.totalRecords,
            };
            return Ok(listResponse);
        }
    }
}