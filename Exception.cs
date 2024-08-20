  public class ProductAlreadyExistsException : Exception
{
    public ProductAlreadyExistsException(string message) : base(message) { }
}

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(string message) : base(message) { }
}

public class DuplicateProductException : Exception
{
    public DuplicateProductException(string message) : base(message) { }
}
public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message) { }
}
