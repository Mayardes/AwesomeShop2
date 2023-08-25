using AwesomeShop.Services.Orders.Core.Events;

namespace AwesomeShop.Services.Orders.Core.Entities;

public class AggregateRoot : IEntityBase
{
    private readonly List<IDomainEvents> _events = new();
    public Guid Id { get; protected set; }
    
    public IEnumerable<IDomainEvents> Events => _events;

    protected void AddEvent(IDomainEvents @event)
    {
        _events.Add(@event);
    }
}