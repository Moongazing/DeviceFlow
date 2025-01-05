using Microsoft.AspNetCore.SignalR;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Hubs;
using Moongazing.DeviceFlow.Api.Services.Energys;
using Moongazing.DeviceFlow.Api.Services.Events;
using Moongazing.DeviceFlow.Api.Services.Locations;
using Moongazing.DeviceFlow.Api.Services.Sensors;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using System.Text;
using System.Text.Json;


namespace Moongazing.DeviceFlow.Api.Services;

public class MqttClientService
{
    private readonly IManagedMqttClient mqttClient;
    private readonly ISensorDataService sensorDataService;
    private readonly ILocationDataService locationDataService;
    private readonly IEventDataService eventDataService;
    private readonly IEnergyDataService energyDataService;
    private readonly IHubContext<DeviceHub> hubContext;

    public MqttClientService(ISensorDataService sensorDataService,
                             ILocationDataService locationDataService,
                             IEventDataService eventDataService,
                             IEnergyDataService energyDataService,
                             IHubContext<DeviceHub> hubContext)
    {
        this.sensorDataService = sensorDataService;
        this.locationDataService = locationDataService;
        this.eventDataService = eventDataService;
        this.energyDataService = energyDataService;
        this.hubContext = hubContext;

        var factory = new MqttFactory();
        mqttClient = factory.CreateManagedMqttClient();
    }

    public async Task ConnectAsync()
    {
        var options = new MqttClientOptionsBuilder()
            .WithClientId("IoTDashboard")
            .WithTcpServer("broker.hivemq.com", 1883)
            .Build();

        var managedOptions = new ManagedMqttClientOptionsBuilder()
            .WithClientOptions(options)
            .Build();

        mqttClient.ConnectedAsync += async e =>
        {
            Console.WriteLine("Connected to MQTT Broker.");
            await mqttClient.SubscribeAsync([new MqttTopicFilterBuilder().WithTopic("iot/devices/#").Build()]);
        };

        mqttClient.DisconnectedAsync += async e =>
        {
            await mqttClient.SubscribeAsync([new MqttTopicFilterBuilder().WithTopic("iot/devices/#").Build()]);
            Console.WriteLine("Disconnected from MQTT Broker.");
            await Task.CompletedTask;
        };

        mqttClient.ApplicationMessageReceivedAsync += async e =>
        {
            var topic = e.ApplicationMessage.Topic;
            var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Console.WriteLine($"Message Received: Topic={topic}, Payload={payload}");

            await ProcessMessageAsync(topic, payload);
        };

        await mqttClient.StartAsync(managedOptions);
    }

    private async Task ProcessMessageAsync(string topic, string payload)
    {
        try
        {
            if (topic.StartsWith("iot/devices/sensor"))
            {
                var sensorData = JsonSerializer.Deserialize<SensorData>(payload);
                if (sensorData != null)
                {
                    await sensorDataService.AddSensorDataAsync(sensorData);
                    await hubContext.Clients.All.SendAsync("ReceiveSensorData", sensorData);
                }
            }
            else if (topic.StartsWith("iot/devices/location"))
            {
                var locationData = JsonSerializer.Deserialize<LocationData>(payload);
                if (locationData != null)
                {
                    await locationDataService.AddLocationDataAsync(locationData);
                    await hubContext.Clients.All.SendAsync("ReceiveLocationData", locationData);
                }
            }
            else if (topic.StartsWith("iot/devices/event"))
            {
                var eventData = JsonSerializer.Deserialize<EventData>(payload);
                if (eventData != null)
                {
                    await eventDataService.AddEventDataAsync(eventData);
                    await hubContext.Clients.All.SendAsync("ReceiveEventData", eventData);
                }
            }
            else if (topic.StartsWith("iot/devices/energy"))
            {
                var energyData = JsonSerializer.Deserialize<EnergyData>(payload);
                if (energyData != null)
                {
                    await energyDataService.AddEnergyDataAsync(energyData);
                    await hubContext.Clients.All.SendAsync("ReceiveEnergyData", energyData);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing MQTT message: {ex.Message}");
        }
    }
}
