using System.ComponentModel.DataAnnotations;
namespace WebUi.Models;
public class LoginModel
{
    [EmailAddress, Required]
    public string? Email { get; set; }

    [Required, DataType(DataType.Password), StringLength(20,MinimumLength = 5)]
    public string? Password { get; set; }
}

