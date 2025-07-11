using ECommerceApi.Data;
using ECommerceApi.DTO;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
      
        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetProducts()
        {
            var products = _db.Products.ToList();
            List<ProductInfoDto> productDtos = new List<ProductInfoDto>();
            foreach (var product in products)
            {
                ProductInfoDto productDto = new ProductInfoDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    QuantityAvaliable = product.QuantityAvaliable,
                    CategoryName = _db.Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name
                };
                productDtos.Add(productDto);
            }
            return Ok(productDtos);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductById(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            else
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    ProductInfoDto productDto = new ProductInfoDto()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        QuantityAvaliable = product.QuantityAvaliable,
                        CategoryName = _db.Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name
                    };
                    return Ok(productDto);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet]
        [Route("{name:alpha}")]
        public IActionResult SearchForProduct(string name)
        {
            name = name.ToLower();
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            else
            {
                List<Product> products = _db.Products.Where(p => p.Name == name).ToList();
                if (products != null)
                {
                    List<ProductInfoDto> productDtos = new List<ProductInfoDto>();
                    foreach (var product in products)
                    {
                        ProductInfoDto productDto = new ProductInfoDto()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price,
                            QuantityAvaliable = product.QuantityAvaliable,
                            CategoryName = _db.Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name
                        };
                        productDtos.Add(productDto);
                    }

                    return Ok(productDtos);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpGet]
        [Route("Category_filter")]
        public IActionResult GetFilteredProductsByCategory()
        {
            var filteredProductsByCategory = from p in _db.Products
                        join c in _db.Categories
                        on p.CategoryId equals c.Id
                        orderby c.Name
                        select new
                        {
                            CategoryName = c.Name,
                            p.Id,
                            p.Name,
                            p.Price,
                            p.QuantityAvaliable,
                            p.Description
                        };
             

            return Ok(filteredProductsByCategory);
        }
        [HttpGet]
        [Route("Price_filter")]
        public IActionResult GetFilteredProductsByPrice()
        {
            var filteredByPrice = _db.Products.OrderBy(p => p.Price);
            return Ok(filteredByPrice);
        }

        //for seller ==Authorize
       
        [HttpPost]
        [Route("")]
        public IActionResult AddProduct([FromBody] CreatedProductDto product)
        {
          
            if (ModelState.IsValid)
            {
                Product newProduct = new Product() { Name= product.Name, Price = product.Price, QuantityAvaliable = product.QuantityAvaliable, Description = product.Description, CategoryId = product.CategoryId};
                
                _db.Products.Add(newProduct);
                _db.SaveChanges();
                return Created();
            } else
            {
                return BadRequest();
            }
        }
        ////for seller
        [HttpDelete]
        [Route("")]
        public IActionResult RemoveProduct(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            else
            {
                var product = _db.Products.Find(id);
                if (product != null)
                {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            
        }
        [HttpPut]
        [Route("Edit/{id}")]
        public IActionResult EditProduct(int? id, [FromBody] CreatedProductDto product)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            else
            {
               Product updatedProduct = _db.Products.FirstOrDefault(p => p.Id == id);
                if (updatedProduct != null)
                {
                    if (ModelState.IsValid)
                    {
                        updatedProduct.Name = product.Name;
                        updatedProduct.Price = product.Price;
                        updatedProduct.Description = product.Description;
                        updatedProduct.QuantityAvaliable= product.QuantityAvaliable;
                        updatedProduct.CategoryId = product.CategoryId;
                      
                        _db.Products.Update(updatedProduct);
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
