using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopAPI.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int IdAccount { get; set; }
    
    [Column("FK_role")]
    public int IdRole { get; set; }
    
    [Column("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Column("email")]
    [Required]
    [MaxLength(80)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    [RegularExpression("[0-9]{9}")]
    public string PhoneNumber { get; set; }
    
    [ForeignKey(nameof(IdRole))]
    public Role Role { get; set; }
    
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}