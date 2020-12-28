using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.Controllers
{
    [ApiController]
    [Route("v1/cproduct")]
    public class CategoryProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>>
        Get([FromServices] DataContext context)
        {
            var products = await context.products.ToListAsync();
            return products;
        }

        // SELECT "categories".id, "categories".title FROM "categories"
        //INNER JOIN "categoryproducts"
        //ON "categoryproducts".categoryid = "categories".id
        //INNER JOIN "products"
        //ON "products".id = "categoryproducts".productid
        //WHERE "products".id = 1 ;
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>>
        Get([FromServices] DataContext context, int id)
        {
            var query =
                await(from a in context.categories
                join b in context.categoryProducts on a.id equals b.categoryid
                join c in context.products on b.productid equals c.id
                where c.id == id
                select a).ToListAsync();

            return query;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>>
        GetByCategory([FromServices] DataContext context, int id)
        {
            var products =
                await context
                    .products
                    .Include(x => x.category)
                    .Where(x => x.categoryid == id)
                    .ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>>
        Post([FromServices] DataContext context, [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                context.products.Add (model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
