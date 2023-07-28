using Microsoft.AspNetCore.Mvc;

namespace API.ProductManagementAPI.Controllers;

[ApiController]
[Route("api/controler")]
public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult GetAllProducts(){
        
    } 
}