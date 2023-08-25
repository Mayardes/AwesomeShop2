using AwesomeShop.Services.Orders.Core.ValueObjects;

namespace AwesomeShop.Services.Orders.Core.Events;

public class OrderCreated : IDomainEvents
{
    public OrderCreated(Guid id, decimal totalPrice, PaymentInfo paymentInfo, string fullname, string email)
    {
        Id = id;
        TotalPrice = totalPrice;
        PaymentInfo = paymentInfo;
        FullName = fullname;
        Email = email;
    }
    
    public Guid Id { get; private set; }
    public decimal TotalPrice { get; private set; }
    public PaymentInfo PaymentInfo{ get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
}