using Microsoft.AspNetCore.Mvc;
using ShopAPI.Exceptions;
using ShopAPI.RequestModels;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IProductService service) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddProductWithCategories(AddProductWithCategoriesRequestModel requestModel, CancellationToken cancellationToken)
    {
        try
        {
            await service.AddProductWithCategories(requestModel, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}