### Documentación
## Tecnologías
- ASP.NET Core 8
- ENTITY FRAMEWORK
- AutoMapper
- Razor

## Arquitectura
El proyecto sigue una arquitectura horizontal de capas (N-Tier/N-layers) con la siguiente estructura de proyectos:
- Domain: Entidades.
- AppCore: capa de Lógica de negocio (Servicios, DTOs y perfiles mapper).
- Infrastructure: Capa de acceso a datos (Repositorios, Unidad de trabajo, DbContext y migraciones.
- WebApp: Capa de presentación (Controladores, vistas y Program.cs).
# Dependencias entre proyectos:
![image](https://github.com/user-attachments/assets/3c67a01a-7431-4e29-96fe-cf270c92cd1d)

## Patrones de diseño
- Repository Pattern junto a Unit Of Work.
- Inyección de dependencias.

## Base de datos y migraciones
Se conecta mediante EntityFramework Core a una base de datos gestionada con SQL Server.
ejemplo migraciones:
![image](https://github.com/user-attachments/assets/f47474f7-ec65-4616-84d2-c37fd6f7298a)

## Correr proyecto
Unicamente clonando el repositorio y ejecutandolo en Visual Studio (u otro IDE), el proyecto se ejecuta correctamente.
- git clone https://github.com/Silber16/PruebaTecnicaAA
