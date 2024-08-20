internal class Program
{
    public static void TestProductManagement()
    {
        var productManager = new ProductManager();
        var category = new Category { Id = 1, Name = "Electronics" };
        productManager.AddCategory(category);
    
        var product = new Electronics { Id = 1, Name = "Laptop", Price = 1000, CategoryId = 1, Brand = "BrandA", Model = "ModelX" };
        productManager.AddProduct(product);
    
        var retrievedProduct = productManager.SearchProduct(1);
        Console.WriteLine($"Product: {retrievedProduct.Name}, Price: {retrievedProduct.Price}");
    }
    private static void Main(string[] args)
    {
        TestProductManagement();
    }
}