namespace Moongazing.DeviceFlow.Api.Entities;

public class NetworkData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public double SignalStrength { get; set; }
    public double BandwidthUsage { get; set; }
    public string ConnectionStatus { get; set; } = default!;
    public DateTime Timestamp { get; set; }

    public virtual Device Device { get; set; } = default!;
}

