namespace Moongazing.DeviceFlow.Domain.Entities;

public class EventData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public string EventType { get; set; } = default!;
    public string EventDetails { get; set; } = default!;
    public DateTime Timestamp { get; set; }

    public virtual Device Device { get; set; } = default!;
}

