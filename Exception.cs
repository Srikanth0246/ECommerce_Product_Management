  public class ProductAlreadyExistsException : Exception
{
    public ProductAlreadyExistsException(string message) : base(message) { }
}

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message) { }
}
