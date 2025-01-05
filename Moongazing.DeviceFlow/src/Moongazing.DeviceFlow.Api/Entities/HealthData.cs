namespace Moongazing.DeviceFlow.Api.Entities;

public class HealthData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public double CpuUsage { get; set; }
    public double MemoryUsage { get; set; }
    public double Temperature { get; set; }
    public DateTime Timestamp { get; set; }

    public virtual Device Device { get; set; } = default!;
}

