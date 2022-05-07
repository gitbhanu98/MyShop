using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    // By Default class will be private, we need to make this below class Public so that other classes/namespaces/projects can access this class
    public class Product
    {
        public string Id { get; set; }
        
        //Limit the size of Name, display the Name of Product
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        
        //Adding the Range of the Price
        [Range(0,10000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        //Adding Constructor
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }

    
}
