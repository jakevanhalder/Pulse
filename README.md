# Pulse

Pulse is a C# ASP.NET Core MVC application developed to help users focus on important goals, tasks, and budgets in their upcoming week. This application uses Identity framework for Sign Up/Sign In functionalities, a local SQL Database to store user information, and canvas.js to display charts.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Configuration](#configuration)
- [License](#license)

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (Lower versions may work I just don't know/haven't checked)
- [Visual Studio Code](https://visualstudio.microsoft.com/vs/community/) (I used the 2022 version. Other IDEs are fine but if you are developing ASP.NET Core applications I highly recommend using Visual Studio Code)
- A [SendGrid](https://sendgrid.com/) account for email functionalities (Required for now to login and see the full application. I'll fix this in the next commit)
- [Microsoft](https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade) and [Facebook](https://developers.facebook.com/) developer accounts for external login (Tutorials can be found here [Microsoft External Login](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-8.0), or [Facebook External Login](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/facebook-logins?view=aspnetcore-8.0)
- Local SQL Server instance. Download [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) to make your life easier

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

6. (Optional) If you don't want to deal with the external login functionalities just comment out the following code in `program.cs`. As of right now you still need a sendgrid api key to access the content behind the login/register but I'll make a commit soon to fix that:

   ```bash
   builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
   {
       facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
       facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
   }).AddMicrosoftAccount(microsoftOptions =>
   {
       microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
       microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
   });
   ```

# License

This project uses the MIT license. Basically use it however you'd like :).


