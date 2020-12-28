using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string title { get; set; }

        public ICollection<CategoryProduct> categoryProducts { get; set; }
    }
}
