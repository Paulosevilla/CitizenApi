# 🚀 CitizenApi - Practice02

## 📌 Overview
CitizenApi is a RESTful Web API developed using ASP.NET Core as part of Practice02.

The application manages citizen data and integrates external APIs to enrich information dynamically.

---

## 🧱 Architecture

This project follows a clean and organized structure:

- **Controllers** → Handle HTTP requests
- **Models** → Represent data entities
- **DTOs** → Data transfer objects for requests/responses
- **Services** → Business logic and file handling
- **Data** → Data storage (CSV-based)

---

## ⚙️ Technologies Used

- ASP.NET Core Web API
- C#
- HttpClient (External API integration)
- JSON Serialization
- CSV File Handling
- Git & GitHub

---

## 🔗 Features

- ✅ CRUD operations for citizens
- ✅ Data persistence using CSV file
- ✅ External API consumption
- ✅ Logging and error handling
- ✅ DTO-based architecture

---

## 📂 Project Structure

```
CitizenApi/
│
├── Controllers/
│   └── CitizenController.cs
│
├── DTOs/
│   ├── CreateCitizenDto.cs
│   └── UpdateCitizenDto.cs
│
├── Models/
│   └── Citizen.cs
│
├── Services/
│   └── CitizenFileService.cs
│
├── Data/
│   └── citizens.csv
│
├── appsettings.json
└── Program.cs
```

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
```
https://localhost:5001
```

---

## 🌐 External API Integration

The application consumes an external API using `HttpClient`:

- Retrieves random asset data
- Handles errors and fallback responses
- Uses configuration from `appsettings.json`

---

## 🧪 Example Endpoints

| Method | Endpoint        | Description              |
|--------|----------------|--------------------------|
| GET    | /citizens      | Get all citizens         |
| GET    | /citizens/{id} | Get citizen by ID        |
| POST   | /citizens      | Create new citizen       |
| PUT    | /citizens/{id} | Update citizen           |
| DELETE | /citizens/{id} | Delete citizen           |

---

## 🧠 Design Principles

- Separation of concerns
- Clean code practices
- Scalable structure
- Maintainability

---

## 👨‍💻 Author

Developed as part of Practice02.

---

## 📄 License

Educational purposes only.