using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Column("FK_account")]
    public int IdAccount { get; set; }
    
    [Column("FK_product")]
    public int IdProduct { get; set; }
    
    [Column("amount")]
    public int Amount { get; set; }
    
    [ForeignKey(nameof(IdAccount))]
    public Account Account { get; set; }
    
    [ForeignKey(nameof(IdProduct))]
    public Product Product { get; set; }
}