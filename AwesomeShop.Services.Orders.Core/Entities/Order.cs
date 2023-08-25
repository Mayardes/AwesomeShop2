using AwesomeShop.Services.Orders.Core.Enums;
using AwesomeShop.Services.Orders.Core.Events;
using AwesomeShop.Services.Orders.Core.ValueObjects;

namespace AwesomeShop.Services.Orders.Core.Entities;

public class Order : AggregateRoot
{
    public Order(decimal totalPrice, Custumer custumer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress,
        PaymentInfo paymentInfo, List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        TotalPrice = items.Sum(x => x.Price * x.Quantity);
        Custumer = custumer;
        DeliveryAddress = deliveryAddress;
        PaymentAddress = paymentAddress;
        Items = items;
        CreateAt = DateTime.UtcNow;
        PaymentInfo = paymentInfo;
        AddEvent(new OrderCreated(Id, TotalPrice, PaymentInfo, Custumer.FullName, Custumer.Email));
    }

    public decimal TotalPrice { get; private set; }
    public Custumer Custumer { get; private set; }
    public DeliveryAddress DeliveryAddress { get; private set; }
    public PaymentAddress PaymentAddress { get; private set; }
    public PaymentInfo PaymentInfo { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public DateTime CreateAt { get; private set; }
    public OrderStatus Status { get; private set; }

    public void SetAsCompleted()
    {
        Status = OrderStatus.Completed;
    }

    public void SetAsRejected()
    {
        Status = OrderStatus.Rejected;
    }
}