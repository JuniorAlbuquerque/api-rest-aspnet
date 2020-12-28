using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class CategoryProduct
    {
        public int productid { get; set; }

        public Product product { get; set; }

        public int categoryid { get; set; }

        public Category category { get; set; }
    }
}
