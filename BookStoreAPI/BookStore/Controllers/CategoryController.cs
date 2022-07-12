using Microsoft.AspNetCore.Mvc;
using BookStore.models.ViewModels;
using BookStore.repository;
using BookStore.models.Models;
namespace BookStore.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : Controller
    {
        CategoryRepository repository=new CategoryRepository();
        [Route("list")]
        [HttpGet]
        public IActionResult GetCategorIes(int pageindex=1,int pagesize=10,string? keyword="")
        {
            var category=repository.GetCategories(pageindex,pagesize,keyword);
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                records = category.records.Select(c => new CategoryModel(c)),
                totalRecords = category.totalRecords,
            };
            return Ok(listResponse);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var category = repository.GetCategory(id);
                CategoryModel categoryModel = new CategoryModel(category);
                if (category == null)
                {
                    return BadRequest("this id is not available");
                }
                return Ok(categoryModel);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("add")]
        [HttpPost]

        public IActionResult AddCategory(CategoryModel model)
        {
            if (model == null)
            {
                return BadRequest("value must be not null");
            }
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };
            var entry = repository.AddCategory(category);
            CategoryModel categoryModel = new CategoryModel(entry);
            return Ok(categoryModel);
        }
        [Route("update")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            if (model == null)
            {
                return BadRequest("value must be not null");
            }
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };
            var entry = repository.UpdateCategory(category);
            CategoryModel categoryModel = new CategoryModel(entry);
            return Ok(categoryModel);
        }
        [Route("remove/{id}")]
        [HttpDelete]
        public IActionResult RemoveCategory(int id)
        {
            if(id== 0)
            {
                return BadRequest("id must Be not null");
            }
            var entry = repository.RemoveCategory(id);
            if(entry != null) {
                return Ok("category removed successfully");

            }
            return BadRequest("you enterd wrong id");
      
        }
    }
}
