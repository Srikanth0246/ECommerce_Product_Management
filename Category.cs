<<<<<<< HEAD

=======
>>>>>>> 62f680d3144decdc7f351eabd84592d327c3dd3c
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
        if (!Products.Exists(p => p.Id == product.Id))
        {
            Products.Add(product);
        }
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }

    public List<Product> GetProducts()
    {
        return Products;
    }
<<<<<<< HEAD
}

// public class Category{
//     internal object product;

//     public int Id{get; set;}
//     public string Name{get; set;}

// }
=======
}
>>>>>>> 62f680d3144decdc7f351eabd84592d327c3dd3c
