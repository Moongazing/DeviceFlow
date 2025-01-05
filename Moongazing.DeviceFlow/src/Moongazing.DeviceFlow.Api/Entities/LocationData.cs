namespace Moongazing.DeviceFlow.Api.Entities;

public class LocationData
{
    public int Id { get; set; }
    public int DeviceId { get; set; } = default!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Altitude { get; set; }
    public DateTime Timestamp { get; set; }

    public virtual Device Device { get; set; } = default!;
}

