
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Product> Products { get; set; } = new List<Product>();

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddProduct(Product product)
    {
        if (Products.Exists(p => p.Id == product.Id))
        {
            throw new ProductAlreadyExistsException("Product with this ID already exists in the category.");
        }
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        Products.RemoveAll(p => p.Id == product.Id);
    }

    public List<Product> GetProducts()
    {
        return new List<Product>(Products);
    }
}

// public class Category{
//     internal object product;

//     public int Id{get; set;}
//     public string Name{get; set;}

// }
