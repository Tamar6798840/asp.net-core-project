using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {

        public int ProdId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string Description { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

     
    }

    
}
