using System.ComponentModel.DataAnnotations;

namespace Greenovative.Identity.App.ViewModels;

public partial class UserViewModel
{
    public UserViewModel()
    {

    }

    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    public Guid ClientId { get; set; }
    public int StoreId { get; set; }
}
