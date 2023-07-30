namespace API.ProductManagementAPI.Application.Products;

using System.Threading;
using System.Threading.Tasks;
using API.ProductManagementAPI.Application.Common.Interface;
using MediatR;
using API.ProductManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

public class GetProductsQuery : IRequest<List<Product>>
{
}

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetProductsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _applicationDbContext.Products.ToListAsync();
        return products;
    }
}