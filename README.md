## Adding required packages

```sh
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Hosting
```

## Configuration

To use secrets the following must be added to the `Program.cs`:

```cs
var host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostContext, config) => {
    config
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>(optional: true, reloadOnChange: true);

}).Build();
```

and to load the secrets:

```cs
var configuration = host.Services.GetRequiredService<IConfiguration>();
var value = configuration["Secret"];
```

When running this command:

```sh
dotnet user-secrets init
```

`secrets.json` hidden file is created in the following directory:

```sh
`%APPDATA%\RoamingMicrosoft\UserSecrets\<USER_SECRETS_ID>`
```

this allows editing secrets directly in `secrets.json`. When running or building project the secrets are taken from user-secrets, if that is not available, then `appsettings.json` secrets are being used.

## using user-secrets

All secrets with values can be listed with the following command:

```sh
dotnet user-secrets list
```

and secret can be set via:

```sh
dotnet user-secrets set "<secret_name>" "<secret_value>"
```

## Additional documentation

[Microsoft Learn Documentation - app-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows)
