# 🚀 CitizenApi - Practice02

## 📌 Overview
CitizenApi is a RESTful Web API developed using ASP.NET Core as part of Practice02.

The application manages citizen data and integrates external APIs to enrich information dynamically.

---

## 🧱 Architecture

This project uses a structured organization with controllers, DTOs, models, services, and CSV-based data storage.

- **Controllers** → Handle HTTP requests
- **Models** → Represent data entities
- **DTOs** → Data transfer objects for requests/responses
- **Services** → Business logic and file handling
- **Data** → Data storage (CSV-based)

---

## 📌 Project Snapshot

| Item | Description |
|------|-------------|
| **Project Name** | CitizenApi |
| **Practice** | Practice02 |
| **Project Type** | RESTful Web API |
| **Framework** | ASP.NET Core Web API |
| **Language** | C# |
| **Persistence** | CSV file |
| **Documentation** | Swagger / OpenAPI |
| **Testing Support** | Swagger UI + `CitizenApi.http` |
| **IDE** | Visual Studio |
| **Version Control** | Git / GitHub |

---


## ⚙️ Technologies Used

- ASP.NET Core Web API
- C#
- HttpClient (External API integration)
- JSON Serialization
- CSV File Handling
- Git & GitHub
- Swagger / Swashbuckle
- Visual Studio
---

## 🔗 Features

- ✅ CRUD operations for citizens
- ✅ Data persistence using CSV file
- ✅ External API consumption
- ✅ Logging and error handling
- ✅ DTO-based architecture
- ✅ Swagger documentation
- ✅ Organized service layer
- ✅ Local request testing with `CitizenApi.http`

---

## 📂 Project Structure

```text
CitizenApi/
├── CitizenApi.slnx
├── README.md
├── .gitignore
├── .gitattributes
└── CitizenApi/
    ├── Controllers/
    │   └── CitizenController.cs
    ├── DTOs/
    │   ├── CreateCitizenDto.cs
    │   └── UpdateCitizenDto.cs
    ├── Models/
    │   └── Citizen.cs
    ├── Services/
    │   └── CitizenFileService.cs
    ├── Data/
    │   └── citizens.csv
    ├── Properties/
    │   └── launchSettings.json
    ├── appsettings.json
    ├── appsettings.Development.json
    ├── CitizenApi.http
    └── Program.cs

---

## 🚀 Running the Project

### 1. Restore dependencies
```bash
dotnet restore
```

### 2. Run the API
```bash
dotnet run
```

### 3. Access
```text
https://localhost:5001
```

### 4. Swagger UI

Typical local routes may look like:

```text
https://localhost:<port>/swagger
http://localhost:<port>/swagger
```
## ⚙️ Core Configuration

### `Program.cs`

This file configures the application startup and the HTTP pipeline.

It includes:

- controller support
- endpoint API explorer
- Swagger generation
- `CitizenFileService` registration
- `HttpClient` registration
- HTTPS redirection
- authorization middleware
- controller mapping
- application startup with `app.Run()`

En `Program.cs` configuré todos los componentes principales para que la aplicación funcione correctamente.  
Aquí se registran los servicios, se habilita Swagger, se prepara el `HttpClient` y se define cómo se ejecuta la API.

## 🌐 External API Integration

The application consumes an external API using `HttpClient`:

- retrieves external data dynamically
- supports information enrichment
- handles errors and fallback responses
- uses configuration from `appsettings.json`
Una parte importante del proyecto es que no se limita solo al archivo CSV.  
También se preparó el consumo de APIs externas usando `HttpClient`, lo que permite enriquecer la información y demostrar una arquitectura más completa y escalable.


## 🧪 Example Endpoints

| Method | Endpoint        | Description              |
|--------|----------------|--------------------------|
| GET    | /citizens      | Get all citizens         |
| GET    | /citizens/{id} | Get citizen by ID        |
| POST   | /citizens      | Create new citizen       |
| PUT    | /citizens/{id} | Update citizen           |
| DELETE | /citizens/{id} | Delete citizen           |

---
### 1. Controller Layer
- `Controllers/CitizenController.cs`
 
Aquí se manejan las solicitudes HTTP del cliente.  
El controlador actúa como punto de entrada de la API y conecta las peticiones del usuario con la lógica interna del sistema.

### 2. DTO Layer
- `DTOs/CreateCitizenDto.cs`
- `DTOs/UpdateCitizenDto.cs`
 
Los DTOs permiten recibir y enviar datos de forma controlada.  
Con esto evité trabajar directamente con el modelo principal al momento de crear o actualizar registros.

### 3. Model Layer
- `Models/Citizen.cs`
 
El modelo representa la entidad principal del proyecto: el ciudadano.  
Aquí se define la estructura interna de los datos con los que trabaja la API.

### 4. Service Layer
- `Services/CitizenFileService.cs`

En esta capa se encuentra la lógica de negocio y el manejo de archivos.  
Aquí centralicé la lectura, escritura y administración de los datos guardados en el archivo CSV.

### 5. Data Layer
- `Data/citizens.csv`

En lugar de usar una base de datos relacional, utilicé un archivo CSV como mecanismo de persistencia.  
Esto simplifica la práctica y permite enfocarse más en la arquitectura y funcionamiento de la API.

---


## 🧠 Design Principles

- Separation of concerns
- Clean code practices
- Scalable structure
- Maintainability

---

## 👨‍💻 Author

**Paulo Sevilla**

Developed as part of **Practice02**.

---
Test README update