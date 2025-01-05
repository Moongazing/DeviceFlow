import { Component, OnInit } from '@angular/core';
import { JsonPipe } from '@angular/common';
import { SignalRService } from '../../services/signalrservice';
import { CommonModule } from '@angular/common'; // CommonModule eklendi@Component({
  selector: 'app-dashboard',
  template: `
    <div>
      <h1>Real-Time Device Dashboard</h1>
      <div>
        <h2>Sensor Data</h2>
        <div *ngFor="let data of sensorData">
          {{ data | json }}
        </div>
      </div>
      <div>
        <h2>Location Data</h2>
        <div *ngFor="let data of locationData">
          {{ data | json }}
        </div>
      </div>
      <div>
        <h2>Event Data</h2>
        <div *ngFor="let data of eventData">
          {{ data | json }}
        </div>
      </div>
      <div>
        <h2>Energy Data</h2>
        <div *ngFor="let data of energyData">
          {{ data | json }}
        </div>
      </div>
    </div>
  `,
})
export class DashboardComponent implements OnInit {
  sensorData: any[] = [];
  locationData: any[] = [];
  eventData: any[] = [];
  energyData: any[] = [];

  constructor(private signalRService: SignalRService) {}

  ngOnInit(): void {
    this.signalRService.startConnection();

    this.signalRService.addSensorDataListener((data: any) => {
      this.sensorData.push(data);
    });

    this.signalRService.addLocationDataListener((data: any) => {
      this.locationData.push(data);
    });

    this.signalRService.addEventDataListener((data: any) => {
      this.eventData.push(data);
    });

    this.signalRService.addEnergyDataListener((data: any) => {
      this.energyData.push(data);
    });
  }
}
