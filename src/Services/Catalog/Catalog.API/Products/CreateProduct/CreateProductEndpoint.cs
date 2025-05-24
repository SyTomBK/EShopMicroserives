using BuildingBlocks.CQRS;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.CreateProduct;

public record class CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    decimal Price,
    string ImageFile
) : ICommand<CreateProductResponse>;

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async ([FromBody] CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}", response);
        }).WithName("CreateProduct")
          .Produces<CreateProductResponse>(StatusCodes.Status201Created)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Create Product")
          .WithDescription("Create Product");
    }
}
