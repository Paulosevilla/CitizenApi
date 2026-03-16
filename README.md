# \# CitizenApi

# 

# API Web desarrollada en \*\*ASP.NET Core Web API\*\* para la gestión de ciudadanos, como parte de la \*\*Práctica 2\*\*.  

# La aplicación implementa operaciones \*\*CRUD\*\*, persistencia en archivo \*\*CSV\*\*, consumo de una \*\*API externa\*\*, documentación con \*\*Swagger\*\* y una explicación de cómo el proyecto aplica los principios de \*\*12 Factor App\*\*.

# 

# \---

# 

# \## Descripción del proyecto

# 

# La API permite registrar ciudadanos con los siguientes atributos:

# 

# \- `FirstName`

# \- `LastName`

# \- `CI`

# \- `BloodGroup`

# \- `PersonalAsset`

# 

# \### Reglas de negocio implementadas

# 

# \- El `CI` es único para cada ciudadano.

# \- En la creación de un ciudadano:

# &#x20; - se recibe `FirstName`, `LastName` y `CI`

# &#x20; - se asigna un `BloodGroup` aleatorio

# &#x20; - se consume una API externa para obtener un objeto aleatorio como `PersonalAsset`

# \- En la actualización (`PUT`) solo se modifican:

# &#x20; - `FirstName`

# &#x20; - `LastName`

# \- `BloodGroup` y `PersonalAsset` no cambian en la actualización.

# \- Si un ciudadano no existe, la API responde con:

# &#x20; - `Citizen not found`

# 

# \---

# 

# \## Tecnologías utilizadas

# 

# \- \*\*ASP.NET Core Web API\*\*

# \- \*\*C#\*\*

# \- \*\*Swagger / Swashbuckle\*\*

# \- \*\*Archivo CSV\*\* como mecanismo de persistencia

# \- \*\*HttpClient\*\* para consumo de API externa

# \- \*\*Git y GitHub\*\* para control de versiones

# 

# \---

# 

# \## API externa utilizada

# 

# Se consumió la siguiente API pública para asignar un objeto aleatorio al campo `PersonalAsset`:

# 

# `https://api.restful-api.dev/objects`

# 

# \---

# 

# \## Estructura del proyecto

# 

# ```text

# CitizenApi

# ├── Controllers

# │   └── CitizenController.cs

# ├── DTOs

# │   ├── CreateCitizenDto.cs

# │   └── UpdateCitizenDto.cs

# ├── Data

# │   └── citizens.csv

# ├── Models

# │   └── Citizen.cs

# ├── Services

# │   └── CitizenFileService.cs

# ├── Program.cs

# ├── appsettings.json

# └── CitizenApi.csproj

