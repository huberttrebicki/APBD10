using ShopAPI.Context;
using ShopAPI.Exceptions;
using ShopAPI.Models;
using ShopAPI.RequestModels;

namespace ShopAPI.Services;


public interface IProductService
{
    Task AddProductWithCategories(AddProductWithCategoriesRequestModel request, CancellationToken cancellationToken);
}


public class ProductService(ApbdContext context) : IProductService
{
    
    public async Task AddProductWithCategories(AddProductWithCategoriesRequestModel request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.ProductName,
            Weight = request.ProductWeight,
            Width = request.ProductWidth,
            Height = request.ProductHeight,
            Depth = request.ProductDepth
        };
        await context.Products.AddAsync(product, cancellationToken);
        foreach (var categoryId in request.ProductCategories)
        {
            bool doesCategoryExist = context.Categories.Any(category => category.IdCategory == categoryId);
            if (!doesCategoryExist)
            {
                throw new NotFoundException($"Category with id: {categoryId} does not exist");
            }
            await context.ProductCategories.AddAsync(
                new ProductCategory
                {
                    IdCategory = categoryId,
                    Product = product
                },
                cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        
    }
}