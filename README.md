# Pulse

Pulse is a C# ASP.NET Core MVC application developed to help users focus on important goals, tasks, and budgets in their upcoming week. This application uses Identity framework for Sign Up/Sign In functionalities, a local SQL Database to store user information, and canvas.js to display charts.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Configuration](#configuration)
- [License](#license)

## Requirements

- .NET 8 SDK (Lower versions may work I just don't know/haven't checked)
- Visual Studio Code (I used the 2022 version. Other IDEs are fine but if you are developing ASP.NET Core applications I highly recommend using Visual Studio Code)
- A SendGrid account for email functionalities (Required for now to login and see the full application. I'll fix this in the next commit)
- Microsoft and Facebook developer accounts for external login
- Local SQL Server instance. Download SQL Server Management Studio (SSMS) to make your life easier

## Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/Pulse.git
   cd Pulse
   ```

2. (Optional) You might not need to do this as when you build your application it gets invoked I think but if the Nuget packages don't work try:

  ```bash
  dotnet restore
  ```

# Configuration

1. Add User Secrets:

   ```bash
   dotnet user-secrets init
   ```

2. Set the secrets:

  ```bash
  dotnet user-secrets set "SendGrid:ApiKey" "<YOUR_SENDGRID_API_KEY>"
  dotnet user-secrets set "Authentication:Microsoft:ClientId" "<YOUR_MICROSOFT_CLIENT_ID>"
  dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<YOUR_MICROSOFT_CLIENT_SECRET>"
  dotnet user-secrets set "Authentication:Facebook:AppId" "<YOUR_FACEBOOK_APP_ID>"
  dotnet user-secrets set "Authentication:Facebook:AppSecret" "<YOUR_FACEBOOK_APP_SECRET>"
  dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=<YOUR_SERVER>;Database=<YOUR_DATABASE>;User Id=<YOUR_USER_ID>;Password=<YOUR_PASSWORD>;"
  ```

3. Update `program.cs` files DefaultConnection to your local SQL Server instances connection string

4. Navigate to Chrome://flags/ #allow-insecure-localhost if you're using chrome to debug or edge://flags/#allow-insecure-localhost if you're on edge and enable these options

5. Build the project with ctrl+f5. Some dialogs may pop up asking you if you trust ssl certificates. You can read through it, just make sure you press yes.

# License

This project uses the MIT license. Basically use it however you'd like :).


