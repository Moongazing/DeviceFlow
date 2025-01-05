namespace Moongazing.DeviceFlow.Api.Entities;

public class SensorData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public string SensorType { get; set; } = default!;
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
    public virtual Device Device { get; set; } = default!;
}

