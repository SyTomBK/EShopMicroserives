namespace Catalog.API.Products.GetProducts;

public record GetProductQuery() : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);
internal class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductQueryHandler: {request}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductResult(products);
    }
}

