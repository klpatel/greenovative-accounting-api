namespace Greenovative.Identity.Infrastructure.ClientModels;

public class BaseModel
{
    public BaseModel() { }
    public string CreatedBy { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public string ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }

    public void AuditAdd(Guid? userId)
    {
        CreatedOn = DateTime.UtcNow;
        CreatedBy = userId.ToString();
        ModifiedOn = DateTime.UtcNow;
        ModifiedBy = userId.ToString();
    }
    public void AuditUpdate(Guid? userId)
    {
        ModifiedOn = DateTime.UtcNow;
        ModifiedBy = userId.ToString();
    }
}
