using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopAPI.Models;

[Table("Products_Categories")]
public class ProductCategory
{
    [Column("FK_product")]
    public int IdProduct { get; set; }
    
    [Column("FK_category")]
    public int IdCategory { get; set; }
    
    [ForeignKey(nameof(IdProduct))]
    public Product Product { get; set; }
    
    [ForeignKey(nameof(IdCategory))]
    public Category Category { get; set; }
}