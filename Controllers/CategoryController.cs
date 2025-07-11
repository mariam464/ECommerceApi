using ECommerceApi.Data;
using ECommerceApi.DTO;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetCategory()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategoryById(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            else
            {
                var category = _db.Categories.FirstOrDefault(p => p.Id == id);
                if (category != null)
                {
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }
            }

        }
        //for seller
        [HttpPost]
        [Route("")]
        public IActionResult AddCategory([FromBody] CreateCategoryDto category)
        {

            if (ModelState.IsValid)
            {
                Category newCategory = new Category() { Name = category.Name };
                _db.Categories.Add(newCategory);
                _db.SaveChanges();
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            else
            {
                var category = _db.Categories.FirstOrDefault(p => p.Id == id);
                if(category == null)
                {
                    return NotFound();
                }
                else
                {
                    _db.Categories.Remove(category);
                    _db.SaveChanges();
                    return NoContent();
                }
            }
            
        }
        [HttpPut]
        [Route("Edit/{id}")]
        public IActionResult EditCategory(int? id,[FromBody] CreateCategoryDto category)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            else
            {
                var updatedCategory = _db.Categories.FirstOrDefault(p => p.Id == id);
                if (updatedCategory != null)
                {
                    if (ModelState.IsValid)
                    {
                        updatedCategory.Name = category.Name;
                        _db.Categories.Update(updatedCategory);
                        _db.SaveChanges();
                        return Created();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
    
}

