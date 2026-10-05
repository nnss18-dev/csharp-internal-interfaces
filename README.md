# Facade Pattern in C# .NET 10

## Overview

This project demonstrates the **Facade Pattern** in C# with .NET 10, combining:
- **Public Interface** (`IOrderService`)
- **Internal Interfaces** (Inventory, Payment, Notification, Logging)
- **Internal Classes** implementing the internal interfaces
- **Facade Class** (`OrderServiceFacade`) coordinating all subsystems

## Pattern Structure

```
Public API
   ↓
IOrderService (Public Interface)
   ↓
OrderServiceFacade (Facade Class)
   ↓
┌─────────────────────────────────────────┐
│ Internal Services (Hidden)              │
├─────────────────────────────────────────┤
│ • IInventoryService                     │
│ • IPaymentService                       │
│ • INotificationService                  │
│ • ILoggingService                       │
└─────────────────────────────────────────┘
```

## Benefits

✅ **Simplified Client Interface** - Clients only see `IOrderService`

✅ **Hidden Complexity** - Internal services completely hidden from public API

✅ **Loose Coupling** - Easy to modify internal implementation without affecting clients

✅ **Single Responsibility** - Each internal service has one job

✅ **Encapsulation** - Implementation details are internal only

## How It Works

```csharp
// Simple public interface
IOrderService orderService = new OrderServiceFacade();
orderService.PlaceOrder("CUST001", "Widget", 5);
```

Behind the scenes:
1. Check inventory stock
2. Reserve stock
3. Calculate tax and process payment
4. Create order record
5. Send notifications
6. Log the operation

All handled by the facade without exposing complexity to the client!

## File Structure

```
FacadePattern/
├── Interfaces/
│   ├── IOrderService.cs (Public)
│   └── Internal/
│       ├── IInventoryService.cs
│       ├── IPaymentService.cs
│       ├── INotificationService.cs
│       └── ILoggingService.cs
├── Models/
│   └── OrderStatus.cs
├── Internal/
│   ├── InventoryService.cs
│   ├── PaymentService.cs
│   ├── NotificationService.cs
│   └── LoggingService.cs
└── Facade/
    └── OrderServiceFacade.cs
```

## Running the Project

```bash
dotnet run
```

## Key Concepts

- **Public Interface**: Only `IOrderService` is visible to clients
- **Internal Interfaces**: Define contracts for internal components
- **Internal Classes**: Implement internal interfaces (not exposed)
- **Facade**: Coordinates all internal services transparently

This is the essence of the Facade Pattern! 🎭
