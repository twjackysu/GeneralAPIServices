# GeneralAPIServices

This is an outsourced project commissioned by a friend. It primarily involves converting some services in SAP, QAD from SOAP to JSON and providing an API. Since this API is directly integrated into the internal system and there is no additional budget for cybersecurity, it uses an insecure fixed secret.


## Development

```bash
dotnet restore API
dotnet build API --configuration Debug --no-restore
dotnet run --project API
```

## Production

```bash
dotnet restore API
dotnet build API --configuration Release --no-restore
dotnet publish API --configuration Release --no-build --output "API\publish"
```
Modify the `API\publish\appsettings.json` file to match your production environment settings.
Move all the files from `API\publish\*` to your server (like IIS or any other).



# XXX_WSDL_Library

Convert WSDL using the following method

## Installation

This project requires [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to be installed on your machine. 

After installing .NET SDK, you can install the `dotnet-svcutil` tool globally using the following command:

```bash
dotnet tool install --global dotnet-svcutil
```

Then, you can use the `dotnet-svcutil` tool to generate web service reference code for your project. For example:

```bash
dotnet-svcutil example.wsdl --namespace "*,ExampleNamespace"
```