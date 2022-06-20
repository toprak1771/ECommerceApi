using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _StarbucksApi.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Imgsource { get; set; }
        public List<Product> Products { get; set; }

    }
}
