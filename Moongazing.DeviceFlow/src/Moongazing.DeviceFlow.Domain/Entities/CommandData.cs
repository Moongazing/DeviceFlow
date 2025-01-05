namespace Moongazing.DeviceFlow.Domain.Entities;

public class CommandData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public string CommandType { get; set; } = default!;
    public string CommandPayload { get; set; } = default!;
    public bool IsSuccessful { get; set; }
    public DateTime Timestamp { get; set; }

    public virtual Device Device { get; set; } = default!;
}

