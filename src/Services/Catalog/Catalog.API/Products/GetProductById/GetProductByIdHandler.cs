namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProducByIdResult>;
public record GetProducByIdResult(Product Product);

internal class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProducByIdResult>
{
    public async Task<GetProducByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken)
        ?? throw new ProductNotFoundException(query.Id);

        return new(product);
    }
}
