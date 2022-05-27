
//Added References in this project: System.Runtime.Caching, MyShop.Core. See References of this project.

using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        //using the namespace Runtime.Caching for ObjectCache,MemoryCache

        ObjectCache cache = MemoryCache.Default;

        //Using the namespace MyShop.Core.Models to use Product Model
        List<Product> products;
        
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        //Commit method is created to save the list of products added by Customer and store in Cache
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
                Console.WriteLine("product updated");
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        //to find an existing Product
        public Product Find(string Id)
        {
            Product productToFind = products.Find(p => p.Id == Id);
            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("Product not found");
            }
        
        }

        // What is this and Why this is used ?
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        //To delete a Product 
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }

        }
    }
}
