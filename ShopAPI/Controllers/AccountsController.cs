using Microsoft.AspNetCore.Mvc;
using ShopAPI.Exceptions;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController(IAccountService service) : ControllerBase
{

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAccountDetails(int id, CancellationToken cancellationToken)
    {
        try
        {
            var account = await service.GetAccountDetails(id, cancellationToken);
            return Ok(account);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    } 
    
    
}