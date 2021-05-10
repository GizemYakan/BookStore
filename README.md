First set src/infrastructure as default project in Package Manager ConsoleAdd-Migration InitialApp -OutputDir Data/Migrations -Context Infrastructure.Data.AppDbContext -StartupProject Webupdate-database -context AppDbContextAdd-Migration InitialIdentity -OutputDir Identity/Migrations -Context Infrastructure.Identity.AppIdentityDbContext -StartupProject Webupdate-database -context AppIdentityDbContext

# Creating AntiForgeryToken In Views
https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-5.0#javascript

# Scaffold Identity Through Command-Line
https://stackoverflow.com/questions/44509694/error-package-restore-failed
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-5.0#arguments
dotnet tool install -g dotnet-aspnet-codegenerator
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=visual-studio
dotnet aspnet-codegenerator identity -dc Infrastructure.Identity.AppIdentityDbContext --files "Account.Register;Account.Login;"

