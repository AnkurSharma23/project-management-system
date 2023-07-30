using API.ProductManagementAPI.Application.Common.Interface;
using API.ProductManagementAPI.Data;
using API.ProductManagementAPI.DTOs;
using MediatR;

namespace API.ProductManagementAPI.Application.Products;

public class CreateProductsCommand : IRequest<Product>
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public int SubcategoryId { get; set; }
    public Category Category { get; set; }
    public Subcategory Subcategory { get; set; }
}

public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, Product>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateProductsCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Product> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        Product requestProduct = null;

        if (request != null)
        {
            requestProduct = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                ProductCode = request.ProductCode,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                Category = request.Category,
                Subcategory = request.Subcategory
            };

            _applicationDbContext.Products.Add(requestProduct);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return requestProduct;
        }
        return requestProduct;
    }
}