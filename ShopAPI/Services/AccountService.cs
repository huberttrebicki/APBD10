using Microsoft.EntityFrameworkCore;
using ShopAPI.Context;
using ShopAPI.Exceptions;
using ShopAPI.Models;
using ShopAPI.ResponseModels;

namespace ShopAPI.Services;


public interface IAccountService
{
    Task<GetAccountDetailsResponseModel> GetAccountDetails(int id, CancellationToken cancellationToken);
}


public class AccountService(ApbdContext context) : IAccountService
{
    public async Task<GetAccountDetailsResponseModel> GetAccountDetails(int id, CancellationToken cancellationToken)
    {
        var account = await context.Accounts.Include(account => account.Role)
            .Include(a => a.ShoppingCarts)
            .ThenInclude(cart => cart.Product)
            .SingleOrDefaultAsync(a => a.IdAccount == id, cancellationToken);
            
        if (account is null)
        {
            throw new NotFoundException($"Account with id: {id} does not exist");
        }

        return new GetAccountDetailsResponseModel
        {
            FirstName = account.FirstName,
            LastName = account.LastName,
            Email = account.Email,
            Phone = account.PhoneNumber,
            Role = account.Role.Name,
            Cart = account.ShoppingCarts.Select(cart => new ProductDetails
            {
                ProductId = cart.IdProduct,
                ProductName = cart.Product.Name,
                Amount = cart.Amount
            }).ToList()
        };
    }
}