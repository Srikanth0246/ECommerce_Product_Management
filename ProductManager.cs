using System;
using System.Collections.Generic;
using System.Linq;
 
public class ProductManagementSystem
{
    private static List<Category> _categories = new List<Category>();
    private static List<Product> _products = new List<Product>();
 
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
    public IReadOnlyList<Product> Products => _products.AsReadOnly();
 
    public void AddCategory(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null.");
        }
 
        if (_categories.Any(c => c.Id == category.Id))
        {
            throw new InvalidOperationException("Category with this ID already exists.");
        }
 
        _categories.Add(category);
    }
 
    public void AddProduct(Product product, Category category)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }
 
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null.");
        }
 
        if (_products.Any(p => p.Id == product.Id))
        {
            throw new ProductAlreadyExistsException("Product with this ID already exists.");
        }
 
        _products.Add(product);
        category.AddProduct(product);
    }
 
    public void UpdateProduct(Product updatedProduct)
    {
        if (updatedProduct == null)
        {
            throw new ArgumentNullException(nameof(updatedProduct), "Updated product cannot be null.");
        }
 
        var product = _products.SingleOrDefault(p => p.Id == updatedProduct.Id);
        if (product == null)
        {
            throw new ProductNotFoundException("Product not found.");
        }
 
        product.UpdateDetails(updatedProduct.Name, updatedProduct.Price);
    }
 
    public void DeleteProduct(int productId)
    {
        var product = _products.SingleOrDefault(p => p.Id == productId);
        if (product == null)
        {
            throw new ProductNotFoundException("Product not found.");
        }
 
        _products.Remove(product);
 
        foreach (var category in _categories)
        {
            category.RemoveProduct(product);
        }
    }
 
    public Product FindProduct(int productId)
    {
        return _products.SingleOrDefault(p => p.Id == productId);
    }
 
    public void InitializePredefinedData()
    {
        var electronics = new Category(1, "Electronics");
        var clothing = new Category(2, "Clothing");
 
        AddCategory(electronics);
        AddCategory(clothing);
 
        var smartphone = new Product(1, "Smartphone", 699.99m, electronics.Id);
        var laptop = new Product(2, "Laptop", 1299.99m, electronics.Id);
        var tShirt = new Product(3, "T-Shirt", 19.99m, clothing.Id);
 
        AddProduct(smartphone, electronics);
        AddProduct(laptop, electronics);
        AddProduct(tShirt, clothing);
    }
}
 