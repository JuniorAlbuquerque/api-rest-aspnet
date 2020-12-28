using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string title { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public int categoryid { get; set; }

        public Category category { get; set; }
    }
}
