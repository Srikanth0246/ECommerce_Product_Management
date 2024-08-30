using System.Collections.Generic;
using System.Linq;
 
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    private readonly List<Product> _products = new List<Product>();
 
    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
 
    public void AddProduct(Product product)
    {
        if (!_products.Exists(p => p.Id == product.Id))
        {
            _products.Add(product);
        }
    }
 
    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }
 
    public List<Product> GetProducts()
    {
        return _products;
    }
 
    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}";
    }
}