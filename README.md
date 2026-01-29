#  GastosCorporativos API (.NET 9 + Azure)

API RESTful robusta y escalable diseñada para la gestión centralizada de gastos corporativos. Desarrollada con las últimas tecnologías de Microsoft y desplegada en la nube.

![Status](https://img.shields.io/badge/Status-Active-success)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)
![Azure](https://img.shields.io/badge/Azure-App%20Service-0078D4?logo=microsoftazure)

##  Descripción del Proyecto
Este sistema permite a las empresas registrar, monitorear y aprobar gastos de empleados. La arquitectura sigue los principios de **Domain-Driven Design (DDD)** simplificado, asegurando un código limpio, mantenible y testeable.

### Funcionalidades Clave
* **Gestión Completa (CRUD):** Registro de empleados y sus gastos asociados.
* **Validaciones de Negocio:** Reglas estrictas (ej. no permitir montos negativos) implementadas con FluentValidation/Lógica de dominio.
* **Seguridad Personalizada:** Middleware de autenticación mediante `API-Key` en Headers.
* **Persistencia Eficiente:** Entity Framework Core con enfoque **Code-First** y relaciones 1:N.
* **Cloud Native:** Despliegue automatizado en **Azure App Service** conectado a **Azure SQL Database**.
* **Documentación Viva:** Integración con Scalar/Swagger para pruebas interactivas.

## Stack Tecnológico
* **Lenguaje:** C# 12
* **Framework:** ASP.NET Core Web API (.NET 9)
* **Base de Datos:** SQL Server (Local) / Azure SQL (Producción)
* **ORM:** Entity Framework Core 9
* **Testing:** xUnit (Pruebas Unitarias)
* **Herramientas:** Visual Studio 2022, Postman/Scalar.

## Cómo probar la API (Demo)

<img width="1918" height="977" alt="ImagenScalar" src="https://github.com/user-attachments/assets/9261108b-61dc-40cb-a27d-b694b9612316" />

El proyecto se encuentra desplegado y activo en Azure. Puedes probar los endpoints utilizando la siguiente URL base y la API Key de demostración.

**URL Base:** `https://gastoscorporativosapi-2025-bwesgqemdychftej.eastus2-01.azurewebsites.net/api`
**Documentación Interactiva:** [Ver en Scalar](https://gastoscorporativosapi-2025-bwesgqemdychftej.eastus2-01.azurewebsites.net/scalar/v1)

> **Nota:** Para probar los endpoints protegidos, necesitas configurar el Header `API-KEY`.

## Configuración Local
Si deseas ejecutar este proyecto en tu máquina:

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/LuisGuillen-06/GastosCorporativosAPI.git](https://github.com/LuisGuillen-06/GastosCorporativosAPI.git)
    ```
2.  **Configurar Base de Datos:**
    Actualiza la cadena de conexión en `appsettings.json`.
3.  **Aplicar Migraciones:**
    ```bash
    Update-Database
    ```
4.  **Ejecutar:**
    ```bash
    dotnet run
    ```

---
*Desarrollado por [Luis Guillen](https://github.com/LuisGuillen-06) - 2026*
