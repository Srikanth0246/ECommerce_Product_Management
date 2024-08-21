<<<<<<< HEAD
﻿class Program
{
    static void Main(string[] args)
    {
        var system = new ProductManagementSystem();
        bool running = true;

        do
        {
            Console.WriteLine("E-Commerce Product Management System");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Find Product");
            Console.WriteLine("6. View Categories");
            Console.WriteLine("7. View Products");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option (1-8): ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddCategory(system);
                    break;
                case "2":
                    AddProduct(system);
                    break;
                case "3":
                    UpdateProduct(system);
                    break;
                case "4":
                    DeleteProduct(system);
                    break;
                case "5":
                    FindProduct(system);
                    break;
                case "6":
                    ViewCategories(system);
                    break;
                case "7":
                    ViewProducts(system);
                    break;
                case "8":
                    running = false;
                    Console.WriteLine("Exiting the system.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        } while (running);
    }

    private static void AddCategory(ProductManagementSystem system)
    {
        Console.Write("Enter category ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter category name: ");
        string name = Console.ReadLine();

        var category = new Category(id, name);
        system.AddCategory(category);
        Console.WriteLine("Category added successfully.");
        ViewCategories(system);
    }

    private static void AddProduct(ProductManagementSystem system)
    {
        Console.Write("Enter product ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        var product = new Product(id, name, price);

        Console.Write("Enter category ID for the product: ");
        ViewCategories(system);
        int categoryId = int.Parse(Console.ReadLine());
        var category = system.Categories.Find(c => c.Id == categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found.");
            return;
        }

        try
        {
            system.AddProduct(product, category);
            Console.WriteLine("Product added successfully.");
            ViewProducts(system);

        }
        catch (ProductAlreadyExistsException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateProduct(ProductManagementSystem system)
    {
        Console.Write("Enter product ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var existingProduct = system.FindProduct(id);

        if (existingProduct == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write("Enter new product name: ");
        existingProduct.Name = Console.ReadLine();
        Console.Write("Enter new product price: ");
        existingProduct.Price = decimal.Parse(Console.ReadLine());

        try
        {
            system.UpdateProduct(existingProduct);
            Console.WriteLine("Product updated successfully.");
        }
        catch (ProductNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteProduct(ProductManagementSystem system)
    {
        Console.Write("Enter product ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        try
        {
            system.DeleteProduct(id);
            Console.WriteLine("Product deleted successfully.");
        }
        catch (ProductNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void FindProduct(ProductManagementSystem system)
    {
        Console.Write("Enter product ID to find: ");
        int id = int.Parse(Console.ReadLine());

        var product = system.FindProduct(id);
        if (product != null)
        {
            Console.WriteLine($"Product ID: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price:C}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    private static void ViewCategories(ProductManagementSystem system)
    {
        Console.WriteLine("Categories:");
        foreach (var category in system.Categories)
        {
            Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
        }
    }

    private static void ViewProducts(ProductManagementSystem system)
    {
        Console.Write("Enter category name to view products: ");
        string categoryName = Console.ReadLine();

        var category = system.Categories.Find(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
        if (category != null)
        {
            Console.WriteLine($"Products in category '{categoryName}':");
            var products = category.GetProducts();
            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
                }
            }
            else
            {
                Console.WriteLine("No products found in this category.");
            }
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
=======
﻿// internal class Program
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
>>>>>>> 0ea0a401d63e67e36157eedd1c00105fdfc66e2a
    }
 
    
}
