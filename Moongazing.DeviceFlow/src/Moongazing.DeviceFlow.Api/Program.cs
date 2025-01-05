using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Context;
using Moongazing.DeviceFlow.Api.Hubs;
using Moongazing.DeviceFlow.Api.Services;
using Moongazing.DeviceFlow.Api.Services.Devices;
using Moongazing.DeviceFlow.Api.Services.Energys;
using Moongazing.DeviceFlow.Api.Services.Events;
using Moongazing.DeviceFlow.Api.Services.Locations;
using Moongazing.DeviceFlow.Api.Services.Sensors;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IoTDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<ISensorDataService, SensorDataService>();
builder.Services.AddScoped<ILocationDataService, LocationDataService>();
builder.Services.AddScoped<IEventDataService, EventDataService>();
builder.Services.AddScoped<IEnergyDataService, EnergyDataService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapHub<DeviceHub>("/deviceHub");

var mqttClientService = app.Services.GetRequiredService<MqttClientService>();
await mqttClientService.ConnectAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
