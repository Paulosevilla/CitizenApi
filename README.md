# 🚀 CitizenApi - Practice02

CitizenApi is a RESTful Web API built with **ASP.NET Core Web API** as part of **Practice02**.


> Este proyecto consiste en una API Web REST desarrollada con ASP.NET Core para la gestión de ciudadanos.  
> La aplicación permite registrar, consultar, actualizar y eliminar ciudadanos, almacenar los datos en un archivo CSV, consumir una API externa para asignar un objeto personal aleatorio, documentar los endpoints con Swagger y aplicar principios de organización inspirados en **12 Factor App**.

---

## 📌 Overview

CitizenApi is designed to manage citizen information through HTTP endpoints following a clean backend structure.

The application:

- manages citizen records
- stores data in a CSV file
- assigns a random blood group during creation
- consumes an external API to assign a random personal asset
- exposes endpoints through Swagger
- uses Git Flow with `main`, `develop`, and `P2-001`


> La finalidad del proyecto fue construir una API funcional y ordenada, aplicando buenas prácticas de backend.  
> Además del CRUD, el sistema agrega lógica de negocio: al crear un ciudadano se le asigna automáticamente un grupo sanguíneo aleatorio y un objeto personal obtenido desde una API externa.

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

## 🧱 Architecture

This project uses a layered and organized structure with controllers, DTOs, models, services, and CSV-based storage.

- **Controllers** → Handle HTTP requests and responses
- **DTOs** → Define input data for create and update operations
- **Models** → Represent domain entities
- **Services** → Manage business logic and file access
- **Data** → Store persisted data in CSV format


> La arquitectura del proyecto fue organizada por responsabilidades.  
> Esto permite que el código sea más claro, fácil de mantener y más profesional para una práctica académica.

### 1. Controller Layer
- `Controllers/CitizenController.cs`

 
Aquí se manejan los endpoints de la API.  
El controlador recibe las solicitudes del cliente y coordina la lógica necesaria para consultar, crear, actualizar y eliminar ciudadanos.

### 2. DTO Layer
- `DTOs/CreateCitizenDto.cs`
- `DTOs/UpdateCitizenDto.cs`

 
Los DTOs se usan para controlar qué datos recibe la API al crear o actualizar ciudadanos.  
Esto evita exponer directamente el modelo interno.

### 3. Model Layer
- `Models/Citizen.cs`

 
El modelo representa la entidad principal del proyecto: el ciudadano.  
Aquí se definen sus propiedades, como nombre, apellido, CI, grupo sanguíneo y objeto personal.

### 4. Service Layer
- `Services/CitizenFileService.cs`


El servicio centraliza la lógica para leer y escribir el archivo CSV.  
De esta manera, el controlador queda más limpio y la persistencia queda mejor organizada.

### 5. Data Layer
- `Data/citizens.csv`

 
Este archivo almacena los registros persistentes del sistema.  
En lugar de usar una base de datos relacional, el proyecto utiliza un CSV para simplificar la práctica y enfocarse en la lógica del backend.

---

## ⚙️ Technologies Used

- ASP.NET Core Web API
- C#
- HttpClient
- JSON Serialization
- CSV File Handling
- Swagger / Swashbuckle
- Git & GitHub
- Visual Studio


> Estas tecnologías permitieron desarrollar una API completa y funcional.  
> ASP.NET Core facilitó la construcción de endpoints, `HttpClient` permitió integrar servicios externos, el CSV reemplazó temporalmente una base de datos y Swagger ayudó a documentar y probar la API.

---

## 🔗 Features

- ✅ CRUD operations for citizens
- ✅ Data persistence using CSV file
- ✅ Random blood group assignment
- ✅ External API consumption for random personal asset
- ✅ Logging and error handling
- ✅ DTO-based input handling
- ✅ Swagger documentation
- ✅ Organized service layer
- ✅ Local request testing with `CitizenApi.http`

### Feature Explanation

| Feature | Explanation |
|--------|-------------|
| **CRUD operations** | Permite crear, consultar, actualizar y eliminar ciudadanos. |
| **CSV persistence** | La información se almacena en `Data/citizens.csv`. |
| **Random blood group** | Al crear un ciudadano, se asigna un grupo sanguíneo aleatorio. |
| **External API asset** | Se consulta una API externa para obtener un objeto aleatorio como `PersonalAsset`. |
| **Logging and error handling** | Se registran eventos importantes y errores de lectura, escritura o consumo externo. |
| **DTO-based architecture** | Se controlan mejor los datos de entrada. |
| **Swagger documentation** | Permite probar la API desde el navegador. |

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

## ⚙️ Core Configuration

### `Program.cs`

This file configures the application startup and HTTP pipeline.

It includes:

- controller support
- endpoint API explorer
- Swagger generation
- singleton registration for `CitizenFileService`
- `HttpClient` registration
- HTTPS redirection
- authorization middleware
- controller mapping
- application startup with `app.Run()`

  
> En `Program.cs` se configuró todo lo necesario para poner en funcionamiento la API.  
> Aquí se registran servicios, Swagger, `HttpClient` y el pipeline de ejecución.

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

### 3. Access Swagger UI

Typical local routes may look like:

```text
https://localhost:<port>/swagger
http://localhost:<port>/swagger
```

> Estos pasos permiten restaurar dependencias, ejecutar el proyecto y abrir Swagger para probar los endpoints de forma interactiva.

---

## 🌐 External API Integration

The application consumes an external API using `HttpClient`.

### Behavior

- retrieves a list of objects
- deserializes the JSON response
- selects one random object
- uses its name as the citizen's `PersonalAsset`
- falls back to `"Unknown Asset"` if the request fails or returns no data

> Una de las partes más importantes del proyecto es la integración con una API externa.  
> Al crear un ciudadano, la aplicación consulta la API, obtiene una lista de objetos y selecciona uno aleatorio para asignarlo como objeto personal.  
> Si ocurre un error, el sistema utiliza `"Unknown Asset"` como valor de respaldo.

---
## 🧪 Example Endpoints

> **Note:** The route prefix defined in the controller is `api/[controller]`, so the base route is `/api/citizen`.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/citizen` | Get all citizens |
| GET | `/api/citizen/{ci}` | Get citizen by CI |
| POST | `/api/citizen` | Create new citizen |
| PUT | `/api/citizen/{ci}` | Update citizen name and last name |
| DELETE | `/api/citizen/{ci}` | Delete citizen by CI |

> Estos endpoints representan el CRUD completo del sistema.  
> El identificador usado en las operaciones individuales es el **CI** del ciudadano.

---
## 🧪 Example Endpoints

> **Note:** The route prefix defined in the controller is `api/[controller]`, so the base route is `/api/citizen`.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/citizen` | Get all citizens |
| GET | `/api/citizen/{ci}` | Get citizen by CI |
| POST | `/api/citizen` | Create new citizen |
| PUT | `/api/citizen/{ci}` | Update citizen name and last name |
| DELETE | `/api/citizen/{ci}` | Delete citizen by CI |
  
> Estos endpoints representan el CRUD completo del sistema.  
> El identificador usado en las operaciones individuales es el **CI** del ciudadano.

---
## 💾 Data Persistence

The project uses a CSV file instead of a relational database.

### Persistence file

```text
Data/citizens.csv
```

### How it works

- citizen data is read from the CSV file
- each line is split into values
- citizen objects are reconstructed in memory
- updates are written back using `File.WriteAllLines`

### Benefits

- lightweight solution
- easy to inspect manually
- simple for academic development
- no database setup required

### Limitations

- not ideal for large-scale systems
- limited concurrency support
- less robust than a database
- intended mainly for learning purposes
  
> El uso de CSV permite trabajar persistencia sin la complejidad de instalar y configurar una base de datos.  
> Para una práctica académica, esto es útil porque deja el enfoque en la arquitectura, la lógica del backend y el consumo de APIs.

---
## 🌐 Swagger Documentation

The project includes Swagger support for:

- interactive API documentation
- endpoint visualization
- request and response testing
- easier review of the project

> Swagger permite visualizar y probar la API directamente desde el navegador, lo que facilita tanto el desarrollo como la revisión de la práctica.

---
## 🌱 Git Workflow

This project followed a branch-based Git Flow:

- `main` → final branch
- `develop` → integration branch
- `P2-001` → working branch for Practice02 development

### Applied workflow

1. development started in `P2-001`
2. changes were merged into `develop`
3. final version was merged into `main`

> Se aplicó un flujo de trabajo con ramas para organizar el desarrollo y evitar modificar directamente la rama principal desde el inicio.

---
## 🧠 12 Factor App Principles Applied

This project was documented considering the **12 Factor App** methodology.

### 1. Codebase

A single codebase is tracked in Git and deployed through different branches.

  
El proyecto tiene un único repositorio en Git, y el trabajo se organizó por ramas (`main`, `develop`, `P2-001`) sin duplicar el código base.

---

### 2. Dependencies

Dependencies are explicitly declared and managed through the .NET project file.

 
Las dependencias del proyecto se encuentran definidas en el archivo del proyecto (`.csproj`), por ejemplo Swagger y los paquetes de ASP.NET Core.

---

### 3. Config

Configuration values are read from configuration sources instead of being hardcoded.

Examples:

- external API base URL
- CSV file path


La configuración se separa del código mediante `IConfiguration`, permitiendo obtener la ruta del archivo CSV y la URL de la API externa desde `appsettings.json` o fuentes equivalentes.

---

### 4. Backing Services

The external API acts as a backing service consumed by the application.

 
La API externa funciona como un servicio de apoyo, ya que proporciona la información necesaria para asignar el `PersonalAsset` aleatorio.

---

### 5. Build, Release, Run

The application follows clear stages:

- **Build** → restore and compile the project
- **Release** → prepare the configured version of the application
- **Run** → execute the API with `dotnet run`


El proyecto puede construirse, prepararse y ejecutarse de forma separada, siguiendo la idea de separar compilación, release y ejecución.

---

### 6. Processes

The application runs as a stateless process, while persistent data is stored externally in a CSV file.

La API no depende de guardar el estado en memoria entre ejecuciones.  
La información persistente se mantiene en el archivo CSV.

---

### 7. Port Binding

The web application exposes its functionality over HTTP/HTTPS using ASP.NET Core hosting.

 
La API se publica mediante un puerto local al ejecutarse, y se accede a ella por navegador, Swagger o clientes HTTP.

---

### 8. Concurrency

The application structure allows multiple requests to be handled by the web server, although CSV persistence is intended for small-scale academic use.


Aunque la API puede recibir múltiples solicitudes, la persistencia en CSV está pensada para escenarios pequeños y académicos, no para alta concurrencia real.

---

### 9. Disposability

The application starts quickly and can stop safely, with data persisted in the CSV file.

 
La aplicación puede iniciarse y detenerse sin procesos complejos, y los datos importantes ya quedan guardados en el archivo.

---

### 10. Dev / Prod Parity

The same project structure and configuration style can be maintained across development and production-like environments.


El proyecto mantiene una estructura consistente entre entornos, usando configuración externa y la misma base de código.

---

### 11. Logs

Logs are treated as event streams and are emitted through the logging system.

 
Las operaciones y errores importantes se registran mediante `ILogger`, en lugar de ocultarse o dejarse sin control.

---

### 12. Admin Processes

Administrative or maintenance tasks can be executed separately, such as reviewing CSV data, cleaning records, or running test requests.


Las tareas administrativas del proyecto, como revisar el archivo CSV, probar endpoints o verificar configuraciones, pueden realizarse sin modificar la lógica principal de la aplicación.

---

## 🧠 Design Principles

- Separation of concerns
- Clean code practices
- Scalable structure
- Maintainability
 
> El proyecto fue desarrollado siguiendo principios que mejoran la organización del código y facilitan futuras mejoras.

---

## 👨‍💻 Author

**Paulo Sevilla**

Developed as part of **Practice02**.

---

## 📄 License

This project was created for academic and educational purposes.