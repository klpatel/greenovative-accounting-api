namespace Greenovative.Identity.Infrastructure.Models;

public class Token
{
    public Guid ClientId { get; set; }
    public int? StoreId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
    public string Username { get; set; }
    public string UserFullName { get; set; }
    public Guid UserId { get; set; }
    public string[] Roles { get; set; }

}
