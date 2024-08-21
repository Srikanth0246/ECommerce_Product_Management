public class ProductManagementSystem
{
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<Product> Products { get; set; } = new List<Product>();

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

    public void AddProduct(Product product, Category category)
    {
        if (Products.Exists(p => p.Id == product.Id))
        {
            throw new ProductAlreadyExistsException("Product with this ID already exists.");
        }

        Products.Add(product);
        category.AddProduct(product);
    }

    public void UpdateProduct(Product updatedProduct)
    {
        var product = Products.Find(p => p.Id == updatedProduct.Id);
        if (product == null)
        {
            throw new ProductNotFoundException("Product not found.");
        }

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
    }

    public void DeleteProduct(int productId)
    {
        var product = Products.Find(p => p.Id == productId);
        if (product == null)
        {
            throw new ProductNotFoundException("Product not found.");
        }

        Products.Remove(product);

        foreach (var category in Categories)
        {
            category.RemoveProduct(product);
        }
    }

    public Product FindProduct(int productId)
    {
        return Products.Find(p => p.Id == productId);
    }
}
 