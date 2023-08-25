namespace AwesomeShop.Services.Orders.Core.Entities;

public class Custumer : IEntityBase
{
    public Custumer(string fullName, string email)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
}