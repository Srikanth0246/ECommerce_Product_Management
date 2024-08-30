public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
 
    public Product(int id, string name, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty.", nameof(name));
        }
 
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Product price cannot be negative.");
        }
 
        Id = id;
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }
 
    public void UpdateDetails(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty.", nameof(name));
        }
 
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Product price cannot be negative.");
        }
 
        Name = name;
        Price = price;
    }
 
    public override string ToString()
    {
        return $"ID: {Id} \nName: {Name} \nPrice: {Price} \nCategory ID: {CategoryId}";
    }
}