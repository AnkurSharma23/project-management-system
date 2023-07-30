namespace ProductManagementAPITest;

using API.ProductManagementAPI.Controllers;
using MediatR;
using Moq;
using System.Linq;

public class ProductsControllerTest
{
    private readonly Mock<IMediator> _mediator;

    public ProductsControllerTest()
    {
        _mediator = new Mock<IMediator>();
    }

    [Fact]
    public async void ShouldGetAllTheProducts()
    {
        ProductsController productsController = new ProductsController(_mediator.Object);
        var products = await productsController.GetAllProducts();
        Assert.NotNull(products);
    }
}