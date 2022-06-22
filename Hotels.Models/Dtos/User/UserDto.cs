using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Dtos.User;

public class UserDto : LoginDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

}
