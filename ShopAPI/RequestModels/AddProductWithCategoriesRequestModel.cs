﻿namespace ShopAPI.RequestModels;

public class AddProductWithCategoriesRequestModel
{
    public string ProductName { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductWidth { get; set; }
    public decimal ProductHeight { get; set; }
    public decimal ProductDepth { get; set; }
    public List<int> ProductCategories { get; set; }
}