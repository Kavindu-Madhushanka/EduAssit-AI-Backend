# EduAssit-AI-Backend
AI-powered Study Companion platform. Built using React (Vite + Tailwind CSS) for a futuristic, high-performance UI and powered by a robust .NET 8 Web API backend managing secure authentication, data transfer objects (DTOs), and core business logic.

#  EduAsst AI - Backend & Core Engine

Welcome to the core repository of **EduAsst AI**, an advanced AI-powered Study Companion designed to streamline learning. This repository houses the robust, enterprise-grade backend built with the **.NET Web API** framework.

##  Tech Stack & Architecture

The project follows a clean **Decoupled MVC / Client-Server Architecture** where the frontend and backend communicate securely through RESTful APIs.

- **Frontend:** React (Vite) + Tailwind CSS *(Cyberpunk/Neon Green Glow Theme)*
- **Backend:** .NET 8.0 Web API (C#)
- **Design Patterns:** Model-View-Controller (MVC), Data Transfer Objects (DTOs) for secure payload handling, and Repository Pattern.

---

##  Core Backend Features Implemented

### 1.  Modular API Controllers (`Controllers/`)
- Managed by `AuthController.cs` to route traffic and handle incoming client requests seamlessly.
- Built-in **CORS Policy Configuration** to allow safe cross-origin data fetching from the React client (`localhost:5173`).

###  2. Secure Data Transfer Objects (`DTOs/`)
- Implemented `UserLoginDto` and `UserRegisterDto` to filter incoming payloads.
- **Why DTOs?** Enforces strict security bounds, prevents Over-Posting attacks, and isolates the database layer from direct frontend exposure.

###  3. Strong Business & Calculation Models (`Models/`)
- Dedicated to managing data validation, structural integrity, and core calculations (such as user analytics, video processing tasks, and study progress tracking).

---

##  Project Structure

```text
EduAsst.Backend/
│
├── Controllers/         #  API Endpoints (e.g., AuthController.cs)
├── DTOs/                #  Data Transfer Objects for secure request handling
├── Models/              #  Core Data Models & Business Logic
├── Program.cs           #  Application bootstrapping & CORS middleware
└── appsettings.json     #  Configuration and Environment settings
