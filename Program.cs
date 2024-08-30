using System;
using System.Linq;
 
public class Program
{
    static void Main(string[] args)
    {
        var system = new ProductManagementSystem();
        system.InitializePredefinedData();
        bool running = true;
 
        do
        {
            Console.Clear();
            Console.WriteLine("E-Commerce Product Management System");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Find Product");
            Console.WriteLine("6. View Categories");
            Console.WriteLine("7. View Products by Category");
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
                    ViewProductsByCategory(system);
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
        try
        {
            Console.Write("Enter category ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
 
            var category = new Category(id, name);
            system.AddCategory(category);
            Console.WriteLine("Category added successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please enter a valid ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ViewCategories(system);
    }
 
    private static void AddProduct(ProductManagementSystem system)
    {
        try
        {
            Console.Write("Enter category ID for the product: ");
            ViewCategories(system);
            int categoryId = int.Parse(Console.ReadLine());
            var category = system.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
 
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());
 
            var product = new Product(id, name, price, category.Id);
 
            system.AddProduct(product, category);
            Console.WriteLine("Product added successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please enter valid numbers.");
        }
        catch (ProductAlreadyExistsException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        ViewProductsByCategory(system);
    }
 
    private static void UpdateProduct(ProductManagementSystem system)
    {
        try
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
            string name = Console.ReadLine();
            Console.Write("Enter new product price: ");
            decimal price = decimal.Parse(Console.ReadLine());
 
            existingProduct.UpdateDetails(name, price);
 
            system.UpdateProduct(existingProduct);
            Console.WriteLine("Product updated successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please enter valid numbers.");
        }
        catch (ProductNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
 
    private static void DeleteProduct(ProductManagementSystem system)
    {
        try
        {
            Console.Write("Enter product ID to delete: ");
            int id = int.Parse(Console.ReadLine());
 
            system.DeleteProduct(id);
            Console.WriteLine("Product deleted successfully.");
        }
        catch (ProductNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
 
    private static void FindProduct(ProductManagementSystem system)
    {
        try
        {
            Console.Write("Enter product ID to find: ");
            int id = int.Parse(Console.ReadLine());
 
            var product = system.FindProduct(id);
            if (product != null)
            {
                Console.WriteLine(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please enter a valid ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
 
    private static void ViewCategories(ProductManagementSystem system)
    {
        Console.WriteLine("Categories:");
        foreach (var category in system.Categories)
        {
            Console.WriteLine(category);
        }
    }
 
    private static void ViewProductsByCategory(ProductManagementSystem system)
    {
        Console.Write("Enter category name to view products: ");
        string categoryName = Console.ReadLine();
 
        var category = system.Categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
        if (category != null)
        {
            Console.WriteLine($"Products in category '{categoryName}':");
            //var products = category.GetProducts();
            var products=system.Products.Where(c => c.Id==category.Id).ToList();
            if (products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
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
    }
}