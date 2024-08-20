public class ProductManager

{

    private List<Product> products = new List<Product>();

    private List<Category> categories = new List<Category>();
 
    public void AddProduct(Product product)

    {

        if (products.Any(p => p.Id == product.Id))
        {
            throw new DuplicateProductException("Product with the same ID already exists.");
        }
    products.Add(product);

    }
 
    public void UpdateProduct(Product product)

    {

        var existingProduct = products.Find(p => p.Id == product.Id);

        if (existingProduct != null)

        {

            existingProduct.Name = product.Name;

            existingProduct.Price = product.Price;

            existingProduct.CategoryId = product.CategoryId;

        }

    }
   
    public void DeleteProduct(int productId)

    {

       var product = products.Find(p => p.Id == productId);
        if (product == null)
        {
            throw new ProductNotFoundException("Product not found.");
        }
        products.Remove(product);

    }
 
    public Product SearchProduct(int productId)

    {

        return products.Find(p => p.Id == productId);

    }
  public void AddCategory(Category category)
{
    categories.Add(category);
}
 
public List<Product> GetProductsByCategory(int categoryId)
{
    return products.Where(p => p.CategoryId == categoryId).ToList();
}
    

}

 
