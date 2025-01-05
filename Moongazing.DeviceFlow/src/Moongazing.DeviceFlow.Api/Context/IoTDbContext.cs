using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Context;

public class IoTDbContext : DbContext
{
    public IoTDbContext(DbContextOptions<IoTDbContext> options) : base(options) { }

    public virtual DbSet<Device> Devices { get; set; }
    public virtual DbSet<SensorData> SensorData { get; set; }
    public virtual DbSet<LocationData> LocationData { get; set; }
    public virtual DbSet<EnergyData> EnergyData { get; set; }
    public virtual DbSet<HealthData> HealthData { get; set; }
    public virtual DbSet<EventData> EventData { get; set; }
    public virtual DbSet<NetworkData> NetworkData { get; set; }
    public virtual DbSet<CommandData> CommandData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>().HasMany(d => d.SensorData).WithOne(sd => sd.Device).HasForeignKey(sd => sd.DeviceId);
        modelBuilder.Entity<Device>().HasMany(d => d.LocationData).WithOne(ld => ld.Device).HasForeignKey(ld => ld.DeviceId);
        modelBuilder.Entity<Device>().HasMany(d => d.EnergyData).WithOne(ed => ed.Device).HasForeignKey(ed => ed.DeviceId);
        modelBuilder.Entity<Device>().HasMany(d => d.HealthData).WithOne(hd => hd.Device).HasForeignKey(hd => hd.DeviceId);
        modelBuilder.Entity<Device>().HasMany(d => d.EventData).WithOne(ed => ed.Device).HasForeignKey(ed => ed.DeviceId);
        modelBuilder.Entity<Device>().HasMany(d => d.NetworkData).WithOne(nd => nd.Device).HasForeignKey(nd => nd.DeviceId);
        modelBuilder.Entity<Device>().HasMany(d => d.CommandData).WithOne(cd => cd.Device).HasForeignKey(cd => cd.DeviceId);
    }
}