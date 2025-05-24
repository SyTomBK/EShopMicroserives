namespace Catalog.API.Endpoints.Products;

public record CreateProductCommand(
    string Name, string Description, decimal Price, string ImageFile, List<string> Category);

public record ProductResult(Guid Id);

internal class CreateProductCommandHandler
{

}
