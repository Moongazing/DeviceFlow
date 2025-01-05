import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private hubConnection!: signalR.HubConnection;

  constructor() {}

  public startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/deviceHub') // Backend SignalR Hub URL
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connection started'))
      .catch((err: any) => console.error('SignalR Connection error:', err));
  }

  public addSensorDataListener(callback: (data: any) => void): void {
    this.hubConnection.on('ReceiveSensorData', (data: any) => {
      callback(data);
    });
  }

  public addLocationDataListener(callback: (data: any) => void): void {
    this.hubConnection.on('ReceiveLocationData', (data: any) => {
      callback(data);
    });
  }

  public addEventDataListener(callback: (data: any) => void): void {
    this.hubConnection.on('ReceiveEventData', (data: any) => {
      callback(data);
    });
  }

  public addEnergyDataListener(callback: (data: any) => void): void {
    this.hubConnection.on('ReceiveEnergyData', (data: any) => {
      callback(data);
    });
  }
}
