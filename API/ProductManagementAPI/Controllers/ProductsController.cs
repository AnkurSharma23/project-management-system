using API.ProductManagementAPI.Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ProductManagementAPI.Controllers;

[ApiController]
[Route("api/controler")]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _mediator.Send(new GetProductsQuery());
        return Ok(response);
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetProductById(int Id)
    {
        if (Id == 0)
        {
            return BadRequest();
        }

        var product = _mediator.Send(new GetProductByIdQuery() { Id = Id });
        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductsCommand command)
    {
        var productCreated = _mediator.Send(command);
        return null;
    }

    [HttpPut]
    public IActionResult UpdateProduct([FromBody] CreateProductsCommand command)
    {
        var productCreated = _mediator.Send(command);
        return null;
    }

    [HttpDelete]
    [Route("{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        throw new NotImplementedException();
    }
}