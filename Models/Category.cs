using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashion.Models
{
    class Category
    { 

        public string Name { get; set; } = "";
        private List<Product> categoriesProducts=new List<Product>();

        public List<Product> CategoriesProducts
        {
            get { return categoriesProducts; }
            set { categoriesProducts = value; }
        }


        public Category(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Name = name;

        }

        public  List<Product> GetCategoriesProducts()
        {
            return categoriesProducts;
        }

       

        public  void AddProduct(Product product)
        {
            if (CategoriesProducts.Contains(product))
                throw new ArgumentException("produkt redan tillagd");

            categoriesProducts.Add(product);
         

        }
        public void RemoveProduct(Product product)
        {
            categoriesProducts.Remove(product);

        }
             
      
    }
}
