﻿namespace ShopAPI.ResponseModels;

public class GetAccountDetailsResponseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public List<ProductDetails> Cart { get; set; }
}

public class ProductDetails
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
}