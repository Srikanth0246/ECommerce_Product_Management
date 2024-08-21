/*public class ProductManager
{
    private List<Product> products = new List<Product>();
    private List<Category> categories = new List<Category>();
    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        if (products.Any(p => p.Id == product.Id))
            throw new InvalidOperationException("Product with the same ID already exists.");
        var categoryExists = categories.Any(c => c.Id == product.CategoryId);
        if (!categoryExists)
            throw new KeyNotFoundException("Category not found.");
        products.Add(product);
    }
    public void UpdateProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        var existingProduct = products.Find(p => p.Id == product.Id);
        if (existingProduct == null)
            throw new KeyNotFoundException("Product not found.");
        var categoryExists = categories.Any(c => c.Id == product.CategoryId);
        if (!categoryExists)
            throw new KeyNotFoundException("Category not found.");
        existingProduct.Name = product.Name;

        existingProduct.Price = product.Price;

        existingProduct.CategoryId = product.CategoryId;

    }
    public void DeleteProduct(int productId)
    {
        var product = products.Find(p => p.Id == productId);
        if (product == null)
            throw new KeyNotFoundException("Product not found.");
        products.Remove(product);
    }
 
    public Product SearchProduct(int productId)
    {
        var product = products.Find(p => p.Id == productId);

        if (product == null)

            throw new KeyNotFoundException("Product not found.");
 
        return product;

    }
 
    public void AddCategory(Category category)
    {
        if (category == null)

            throw new ArgumentNullException(nameof(category));
 
        if (categories.Any(c => c.Id == category.Id))

            throw new InvalidOperationException("Category with the same ID already exists.");
 
        categories.Add(category);

    }

    public void UpdateCategory(Category category)
    {
        if (category == null)

            throw new ArgumentNullException(nameof(category));
 
        var existingCategory = categories.Find(c => c.Id == category.Id);

        if (existingCategory == null)

            throw new KeyNotFoundException("Category not found.");
 
        existingCategory.Name = category.Name;

    }
    public void DeleteCategory(int categoryId)
    {

        var category = categories.Find(c => c.Id == categoryId);

        if (category == null)

            throw new KeyNotFoundException("Category not found.");

        if (products.Any(p => p.CategoryId == categoryId))

            throw new InvalidOperationException("Category has associated products and cannot be deleted.");
 
        categories.Remove(category);

    }

    public Category SearchCategory(int categoryId)
    {
        var category = categories.Find(c => c.Id == categoryId);

        if (category == null)

            throw new KeyNotFoundException("Category not found.");
 
        return category;

    }

    public List<Product> GetProductsByCategory(int categoryId)
    {
        var category = SearchCategory(categoryId);

        return products.Where(p => p.CategoryId == categoryId).ToList();

    }

}*/

/*public class ProductManagementSystem
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
}*/

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
 