// internal class Program
// {
//     public static void TestProductManagement()
//     {
//         var productManager = new ProductManager();
//         var category = new Category { Id = 1, Name = "Electronics" };
//         productManager.AddCategory(category);
    
//         var product = new Electronics { Id = 1, Name = "Laptop", Price = 1000, CategoryId = 1, Brand = "BrandA", Model = "ModelX" };
//         productManager.AddProduct(product);
    
//         var retrievedProduct = productManager.SearchProduct(1);
//         Console.WriteLine($"Product: {retrievedProduct.Name}, Price: {retrievedProduct.Price}");
//     }
//     private static void Main(string[] args)
//     {
//         TestProductManagement();
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
 
namespace ECommerceManagementApp
{
    public class Program
    {
        public static void Main()
        {
            var productManager = new ProductManager();
 
            var clothingCategory = new Category { Id = 101, Name = "Clothing" };
            var electronicsCategory = new Category { Id = 102, Name = "Electronics" };
 
            productManager.AddCategory(clothingCategory);
            productManager.AddCategory(electronicsCategory);
 
            var clothing = new Clothing
            {
                Id = 1,
                Name = "T-Shirt",
                Price = 670,
                CategoryId = 101,
                Brand = "US POLO",
                Model = "XRT432"
            };
 
            var electronics = new Electronics
            {
                Id = 2,
                Name = "Fan",
                Price = 564,
                CategoryId = 178,
                Brand = "Bajaj",
                Model = "TSR34"
            };
 
            productManager.AddProduct(clothing);
            productManager.AddProduct(electronics);
 
            Console.WriteLine("Displaying all products:");
            DisplayProductDetails(productManager);
        }
            public static void DisplayProductDetails(ProductManager productManager)
        {
            var products = productManager.GetProductsByCategory(101);
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
                if (product is Clothing clothing)
                {
                    Console.WriteLine($"  Brand: {clothing.Brand}, Model: {clothing.Model}");
                }
                else if (product is Electronics electronics)
                {
                    Console.WriteLine($"  Brand: {electronics.Brand}, Model: {electronics.Model}");
                }
                Console.WriteLine();
            }
        }
    }
 
    
}
