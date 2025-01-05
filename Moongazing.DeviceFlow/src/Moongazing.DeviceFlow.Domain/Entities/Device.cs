using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.DeviceFlow.Domain.Entities;

public class Device
{
    public int Id { get; set; }
    public string DeviceId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string DeviceType { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<SensorData> SensorData { get; set; } = new HashSet<SensorData>();
    public virtual ICollection<LocationData> LocationData { get; set; } = new HashSet<LocationData>();
    public virtual ICollection<EnergyData> EnergyData { get; set; } = new HashSet<EnergyData>();
    public virtual ICollection<HealthData> HealthData { get; set; } = new HashSet<HealthData>();
    public virtual ICollection<EventData> EventData { get; set; } = new HashSet<EventData>();
    public virtual ICollection<NetworkData> NetworkData { get; set; } = new HashSet<NetworkData>();
    public virtual ICollection<CommandData> CommandData { get; set; } = new HashSet<CommandData>();
}

