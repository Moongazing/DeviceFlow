namespace Moongazing.DeviceFlow.Domain.Entities;

public class EnergyData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public double Voltage { get; set; }
    public double Current { get; set; }
    public double Power { get; set; }
    public double Energy { get; set; }
    public DateTime Timestamp { get; set; }

    public virtual Device Device { get; set; } = default!;
}

