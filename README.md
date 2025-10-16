# Million – Aplicación de Listado de Propiedades

Aplicación para **Senior Frontend Developer** para la gestión y visualización de propiedades con capacidades de filtrado.  
El proyecto está dividido en dos partes principales: **backend (.NET + MongoDB)** y **frontend (Next.js + TypeScript)**.

---

## Tabla de Contenidos

- [Estructura del Proyecto](#estructura-del-proyecto)
- [Características](#características)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Instalación y Ejecución](#instalación-y-ejecución)
  - [Configuración del Backend](#configuración-del-backend)
  - [Configuración del Frontend](#configuración-del-frontend)

---

## Estructura del Proyecto

```
Million/
├── backend/
│   ├── Application/          # Lógica de aplicación, servicios y DTOs
│   ├── Domain/               # Entidades del dominio
│   ├── Infrastructure/       # Persistencia y repositorios (MongoDB)
│   ├── Presentation/         # API Controllers (ASP.NET Core)
│   └── appsettings.json      # Configuración del entorno
│
└── frontend/
    ├── src/
    │   ├── app/              # Páginas Next.js
    │   ├── core/             # Entidades y casos de uso (Clean Architecture)
    │   ├── infrastructure/   # Servicios y conexión con la API
    │   ├── ui/               # Componentes visuales (React + Bootstrap)
    │   └── styles/           # Archivos SCSS
    ├── public/
    └── next.config.js
```

---

## Características

### Backend
- **Gestión de Propiedades:** Permite filtrar por nombre, dirección y rango de precios.
- **Integración con MongoDB:** Persistencia de datos en base NoSQL.
- **Soporte CORS:** Configurado para permitir peticiones desde el frontend.
- **Arquitectura Limpia (Clean Architecture):** Separación de responsabilidades en capas.

### Frontend
- **Listado de Propiedades:** Interfaz amigable que consume el backend.
- **Filtros interactivos:** Filtrado dinámico sin recargar la página.
- **Diseño Responsivo:** Adaptado para móviles y escritorio usando Bootstrap.
- **Detalles de Propiedad:** Vista completa con carrusel de imágenes, información del propietario y trazas de venta.
- **Arquitectura Limpia:** Separación entre dominio, infraestructura y presentación.

---

## Tecnologías Utilizadas

### Backend
- **C# (.NET 8)**
- **MongoDB**
- **AutoMapper** para mapeo entre entidades y DTOs  
- **Swagger** para documentación interactiva de la API  

### Frontend
- **Next.js 14** (basado en React)
- **TypeScript**
- **Bootstrap 5** y **React-Bootstrap**
- **SASS / SCSS** para estilos personalizados
- **Clean Architecture** adaptada al frontend

---

## Instalación y Ejecución

### Configuración del Backend

1. Abre una terminal y navega al directorio `backend/`:
   ```bash
   cd backend
   dotnet restore
   dotnet run --project Presentation
   ```
2. El backend quedará disponible en:
   ```
   http://localhost:5076
   ```

---

### Configuración del Frontend

1. Abre otra terminal y navega al directorio `frontend/`:
   ```bash
   cd frontend
   npm install
   npm run dev
   ```

2. El frontend quedará disponible en:
   ```
   http://localhost:3000
   ```

---