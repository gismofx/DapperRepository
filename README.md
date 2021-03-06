# DapperRepository  
![NuGet](https://img.shields.io/nuget/v/TheDapperRepository?color=blue)
![DLs](https://img.shields.io/nuget/dt/TheDapperRepository?color=brightgreen&label=NuGet%20downloads)
![Issues](https://img.shields.io/github/issues/gismofx/DapperRepository?color=red)
![license](https://img.shields.io/github/license/gismofx/DapperRepository?color=brightgreen)
![stars](https://img.shields.io/github/stars/gismofx/DapperRepository?style=social)  
Generic Repository Pattern For Dapper using Dapper and Dapper.Contrib
Simple and Easy to Setup!  



### Nuget
https://www.nuget.org/packages/TheDapperRepository/  
or  
`Install-Package TheDapperRepository -Version 1.1.0`
### Example Usage

Add references
```c#
using DapperRepository;
```

*Define your POCO/database table class using dapper/dapper contrib conventions*
```c#
[Table("IdentityUser")]
    public class IdentityUser
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecurityStamp { get; set; }

        [Write(false)]
        public List<CustomIdentityRole> Roles { get; set; }

    }
```

*Add the repository to your project `startup.cs` for dependency injection*
```c#
//Call this before adding repositories:
var connString = Configuration.GetConnectionString("DefaultConnection");
services.AddDbConnectionInstantiatorForRepositories<MySqlConnection>(connString);

services.AddTransientRepository<IdentityUser>();
//add more here
```

If not using dependency injection you can simply instantiate a repository with the dbconnection
```c#
var myEventRepo = new Repository<Event>(new SQLiteConnection(connectionString));
//pass the DbConnection back into each method so it does not get disposed
//Dapper will handle opening and closing of the connection
await myEventRepo.InsertAsync(newEvent, myEventRepo.DbConnection);
```
