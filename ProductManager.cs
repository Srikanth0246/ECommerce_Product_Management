public class ProductManager

{

    private List<Product> products = new List<Product>();

    private List<Category> categories = new List<Category>();
 
    public void AddProduct(Product product)

    {

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

        if (product != null)

        {

            products.Remove(product);

        }

    }
 
    public Product SearchProduct(int productId)

    {

        return products.Find(p => p.Id == productId);

    }

}

 
