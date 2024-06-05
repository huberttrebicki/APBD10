using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int IdRole { get; set; }
    
    [Column("name")]
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public ICollection<Account> Accounts { get; set; }
}