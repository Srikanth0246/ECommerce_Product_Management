  public class ProductAlreadyExistsException : Exception
{
    public ProductAlreadyExistsException(string message) : base(message) { }
}

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(string message) : base(message) { }
}
