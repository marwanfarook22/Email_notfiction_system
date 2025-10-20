# 📧 Email Notification System

A flexible and extensible email notification system built with C# that demonstrates the **Adapter** and **Factory** design patterns. This project allows seamless integration with multiple email service providers through a unified interface.

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-purple)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

---

## 📑 Table of Contents

- [Features](#-features)
- [Project Structure](#️-project-structure)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#-usage)
  - [Running the Application](#running-the-application)
  - [Example Workflow](#example-workflow)
- [How It Works](#-how-it-works)
  - [Adapter Pattern](#adapter-pattern)
  - [Factory Pattern](#factory-pattern)
  - [Notification Manager](#notification-manager)
- [Code Examples](#-code-examples)
- [Design Patterns Deep Dive](#-design-patterns-deep-dive)
- [Key Classes](#-key-classes)
- [Extending the System](#️-extending-the-system)
- [Benefits of This Architecture](#-benefits-of-this-architecture)
- [Learning Resources](#-learning-resources)
- [Contributing](#-contributing)
- [License](#-license)
- [Author](#-author)
- [Support](#-support)

---

## 🌟 Features

### ✨ Multiple Email Service Providers
- **SMTP** - Traditional email protocol support
- **SendGrid** - Cloud-based email delivery service
- **Gmail API** - Google's email service integration
- **Mailgun** - Transactional email API

### 🎯 Design Patterns Implemented
- **Adapter Pattern** - Converts incompatible email service APIs into a common interface
- **Factory Pattern** - Centralizes object creation for email services and notifications
- **Dependency Injection** - Promotes loose coupling and testability

### 📨 Pre-built Notification Templates
- Welcome Email
- Password Reset Email
- Order Confirmation Email

### 🔌 Easy Provider Switching
Switch between email providers without changing your business logic - just change the factory selection!

### ✅ Input Validation
- Email format validation
- User input validation
- Connection testing before sending

## 🏗️ Project Structure

```
Email_notification_system/
├── Models/
│   ├── EmailMessage.cs          # Email data model
│   └── EmailResult.cs           # Result object for email operations
├── Interfaces/
│   └── IEmailService.cs         # Common interface for all email services
├── Third_Party_Services/
│   ├── SmtpClient.cs            # SMTP client implementation
│   ├── SendGridApiClient.cs     # SendGrid API client
│   ├── GmailClient.cs           # Gmail API client
│   └── MailgunClient.cs         # Mailgun API client
├── Adaptors/
│   ├── SmtpClient_Adaptor.cs    # SMTP adapter
│   ├── SendGridApi_Adaptor.cs   # SendGrid adapter
│   ├── GmailClientAdaptor.cs    # Gmail adapter
│   └── MailgunClient_Adaptor.cs # Mailgun adapter
├── Service/
│   └── NotificationManager.cs   # High-level notification service
├── Factories/
│   ├── ThirdParty_service_Factory.cs      # Email service factory
│   └── NotificationManager_Factory.cs     # Notification factory
└── Program.cs                   # Main application entry point
```

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or higher
- Visual Studio 2022 / VS Code / Rider

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/yourusername/email-notification-system.git
cd email-notification-system
```

2. **Build the project**
```bash
dotnet build
```

3. **Run the application**
```bash
dotnet run
```

## 💻 Usage

### Running the Application

When you run the application, you'll see an interactive menu:

```
╔════════════════════════════════════════╗
║     Email Notification System - Demo   ║
╚════════════════════════════════════════╝

Select Third-Party Email Service:
1. SMTP
2. SendGrid
3. Gmail
4. Mailgun
Please select an option (1-4):
```

### Example Workflow

1. **Select Email Service Provider**
   - Choose from SMTP, SendGrid, Gmail, or Mailgun

2. **Enter Email Details**
   - Receiver Email
   - Sender Email
   - Subject
   - Body

3. **Choose Notification Type**
   - Welcome Email
   - Password Reset Email
   - Order Confirmation Email

4. **Email Sent!**
   - Confirmation message displayed

## 🔧 How It Works

### Adapter Pattern
Each email service has its own unique API. The Adapter pattern converts these different APIs into a single `IEmailService` interface:

```csharp
public interface IEmailService
{
    EmailResult SendEmail(EmailMessage message);
    bool ValidateConnection();
}
```

**Example Adapter:**
```csharp
public class SendGridApi_Adaptor : IEmailService
{
    private readonly SendGridApiClient _client;
    
    public SendGridApi_Adaptor(SendGridApiClient client)
    {
        _client = client;
    }
    
    public EmailResult SendEmail(EmailMessage message)
    {
        // Convert EmailMessage to SendGrid format
        var response = _client.Send(message.From, message.To, 
                                     message.Subject, message.Body);
        
        // Convert SendGrid response to EmailResult
        return new EmailResult
        {
            Success = response.StatusCode == 202,
            MessageId = response.MessageId
        };
    }
}
```

### Factory Pattern
The Factory pattern centralizes object creation, making it easy to switch between providers:

```csharp
IEmailService service = thirdPartyServiceFactory.GetThirdPartyService(userSelection, email);
```

### Notification Manager
High-level service that uses any email provider through dependency injection:

```csharp
var notificationManager = new NotificationManager(emailService);
notificationManager.SendWelcomeEmail("user@example.com", "John Doe");
```

## 📋 Code Examples

### Sending a Welcome Email with SendGrid

```csharp
// Create email message
var emailMessage = new EmailMessage
{
    To = "newuser@example.com",
    From = "noreply@myapp.com",
    Subject = "Welcome!",
    Body = "Welcome to our platform!"
};

// Get SendGrid service from factory
IEmailService emailService = factory.GetThirdPartyService(2, emailMessage);

// Send using Notification Manager
var notificationManager = new NotificationManager(emailService);
notificationManager.SendWelcomeEmail("newuser@example.com", "John");
```

### Switching Providers

```csharp
// Use SMTP
IEmailService smtp = factory.GetThirdPartyService(1, emailMessage);

// Switch to Gmail - same interface!
IEmailService gmail = factory.GetThirdPartyService(3, emailMessage);

// Both work with NotificationManager
var manager1 = new NotificationManager(smtp);
var manager2 = new NotificationManager(gmail);
```

## 🎨 Design Patterns Deep Dive

### Why Adapter Pattern?

**Problem:** Each email service has different APIs:
- SendGrid: `Send(from, to, subject, htmlContent)`
- Mailgun: `SendMessage(MailgunMessage)`
- SMTP: `Send(from, to, subject, body)`

**Solution:** Create adapters that convert all APIs to a common interface `IEmailService`

**Benefits:**
- ✅ Unified interface for all providers
- ✅ Easy to add new providers
- ✅ Business logic doesn't depend on specific APIs

### Why Factory Pattern?

**Problem:** Creating email service objects requires knowing:
- Which concrete class to instantiate
- What parameters each service needs
- How to configure each service

**Solution:** Factory handles all object creation logic

**Benefits:**
- ✅ Centralized object creation
- ✅ Hides complexity from client code
- ✅ Easy to extend with new services

## 🔍 Key Classes

### `EmailMessage`
Data model representing an email:
```csharp
public class EmailMessage
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
```

### `EmailResult`
Result of an email operation:
```csharp
public class EmailResult
{
    public bool Success { get; set; }
    public string MessageId { get; set; }
    public string ErrorMessage { get; set; }
}
```

### `IEmailService`
Common interface for all email services:
```csharp
public interface IEmailService
{
    EmailResult SendEmail(EmailMessage message);
    bool ValidateConnection();
}
```

## 🛠️ Extending the System

### Adding a New Email Provider

1. **Create the third-party client**
```csharp
public class NewEmailClient
{
    public ResponseType Send(parameters) { }
}
```

2. **Create an adapter**
```csharp
public class NewEmailAdapter : IEmailService
{
    private readonly NewEmailClient _client;
    
    public EmailResult SendEmail(EmailMessage message)
    {
        // Adapt the interface
    }
}
```

3. **Add to factory**
```csharp
case 5: return CreateNewEmailAdapter(mail);
```

That's it! No changes needed in business logic.

## 🎯 Benefits of This Architecture

| Benefit | Description |
|---------|-------------|
| **Flexibility** | Switch providers without code changes |
| **Maintainability** | Each provider isolated in its own adapter |
| **Testability** | Easy to mock `IEmailService` interface |
| **Scalability** | Add new providers without breaking existing code |
| **Clean Code** | Clear separation of concerns |

## 📚 Learning Resources

This project demonstrates:
- **SOLID Principles**
  - Single Responsibility Principle
  - Open/Closed Principle
  - Liskov Substitution Principle
  - Interface Segregation Principle
  - Dependency Inversion Principle

- **Design Patterns**
  - Adapter Pattern
  - Factory Pattern
  - Dependency Injection

## 🤝 Contributing

Contributions are welcome! Here are some ideas:
- Add more email providers (AWS SES, Postmark, etc.)
- Implement unit tests with xUnit
- Add email templates system
- Implement retry logic for failed sends
- Add logging functionality
- Create a fallback mechanism

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**MarwanFarouq**
- GitHub: [@MarwanFarouq](https://github.com/marwanfarook22)
- LinkedIn: [Your LinkedIn](https://www.linkedin.com/in/marwan-farook-411154314/)

## 🙏 Acknowledgments

- Inspired by real-world email service integration challenges
- Built to demonstrate design patterns in practice
- Created as a learning project for software architecture

## 📞 Support

If you have any questions or run into issues, please open an issue on GitHub.

---

⭐ **If you found this project helpful, please give it a star!** ⭐
