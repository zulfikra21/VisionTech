## Architecture Overview

The project follows a **Gateway/BFF pattern**:

### 1. [Vue.js](./nodejs) (Frontend)
- **Role**: The User Interface.
- **Connection**: Directly connected to **Node.js** as its primary API gateway.

### 2. [Node.js](./nodejs) (ExpressJS)
- **Role**: API Gateway & Middleware (BFF).
- **Primary Tasks**: 
    - Handles authentication and frontend-specific business logic.

### 3. [C#](./C#) (ASP.NET Core Web API)
- **Role**: Core Backend & Real-time Service.
- **Primary Tasks**: 
    - High-performance data processing.
    - **Real-time WebSockets** (SignalR) at `ws://localhost:5160/products`.
- **Interaction**: 
    - Consumes REST APIs from both Node and .NET.
    - Connects to [C# SignalR Hubs](./C#/VisionTech.Api/Hubs) for real-time updates (e.g., live product feeds, notifications).

---

##  How to Build & Run

### For .NET (C#)
1. Navigate to the `C#` folder.
2. Run `dotnet watch --project VisionTech.Api/VisionTech.Api.csproj`.
3. The server starts by default at `http://localhost:5160` (HTTP) or `https://localhost:7160` (HTTPS).

### For Node.js (ExpressJS)
1. Navigate to the `nodejs` folder.
2. Run `npm install` followed by `npm run local`.

---

##  Connection Roadmap

| Service | Protocol | Endpoint |
| :--- | :--- | :--- |
| **Node.js** | HTTP | `http://localhost:3000/api` |
| **.NET API** | HTTP | `http://localhost:5160/api` |
| **.NET Real-time** | WebSocket | `ws://localhost:5160/products` |

**Best Practice Strategy**: 
For the best experience, use **ExpressJS** to handle user security and lightweight metadata, while offloading all data-heavy operations and live updates to the **C#** service. This ensures the best of both worlds!
