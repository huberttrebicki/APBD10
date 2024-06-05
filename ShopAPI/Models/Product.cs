using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int IdProduct { get; set; }
    
    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("weight", TypeName = "decimal(5,2)")]
    public decimal Weight { get; set; }
    
    [Column("width", TypeName = "decimal(5,2)")]
    public decimal Width { get; set; }
    
    [Column("height", TypeName = "decimal(5,2)")]
    public decimal Height { get; set; }
    
    [Column("depth", TypeName = "decimal(5,2)")]
    public decimal Depth { get; set; }
    
    public ICollection<ProductCategory> ProductCategories { get; set; }
    
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}