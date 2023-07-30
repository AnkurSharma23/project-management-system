namespace API.ProductManagementAPI.Application.Products;

using System.Threading;
using System.Threading.Tasks;
using API.ProductManagementAPI.Application.Common.Interface;
using MediatR;
using API.ProductManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

public class GetProductByIdQuery : IRequest<Product?>
{
    public int Id { get; set; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetProductByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
        return product;
    }
}