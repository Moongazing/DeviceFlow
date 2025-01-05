# DeviceFlow

**DeviceFlow** is a senior-level IoT Dashboard application designed to manage and visualize real-time data from IoT devices. It leverages modern technologies such as **.NET 8**, **Entity Framework Core**, **MQTT**, **SignalR**, and **Angular** to provide a robust and scalable platform for IoT device management and telemetry data visualization.

---

## **Features**

- **Real-Time Data Streaming**: Receive and display real-time data from IoT devices using MQTT and SignalR.
- **Data Visualization**: Use dynamic charts (Chart.js) to visualize IoT device metrics.
- **Device Management**: Easily monitor and manage IoT devices.
- **Historical Data Analysis**: Retrieve and analyze historical device data from the database.
- **Extensibility**: Built with Clean Architecture for maintainability and scalability.
- **Secure Data Storage**: Uses EF Core to persist device data in a relational database (SQL Server/PostgreSQL).

---

## **Technologies Used**

### **Backend**
- **.NET 9**: Provides the core framework for the backend.
- **Entity Framework Core**: Handles database operations.
- **MQTT (MQTTnet)**: Manages IoT device communication.
- **SignalR**: Enables real-time communication with the frontend.

### **Frontend**
- **Angular**: Provides a dynamic and responsive user interface.
- **Chart.js**: Visualizes device data in real-time.

---

## **Setup Instructions**

### **Prerequisites**
- **.NET 8 SDK** installed
- **Node.js** and **Angular CLI** for the frontend
- A **SQL Server** or **PostgreSQL** database
- **MQTT Broker** (e.g., HiveMQ or Mosquitto)

---

### **Backend Setup**

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/deviceflow.git
   cd deviceflow
