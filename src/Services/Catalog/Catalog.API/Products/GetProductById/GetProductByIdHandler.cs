


namespace Catalog.API.Products.GetProductById;
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

public class GetProductByIdQueryHandler (IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetProductByIdQuery for product with ID: {Id}", query.Id);
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if(product is null)
        {
            logger.LogWarning("Product with ID: {Id} not found", query.Id);
            throw new ProductNotFoundException();
        }
        return new GetProductByIdResult(product);   


    }
}
