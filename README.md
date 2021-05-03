# PromoCodesAspNetCoreWebApi
An ASP.NET Core Web API for managing promo codes.

## How-to:

To run this project/solution locally, the "PromoCodesAspNetCoreWebApi.WebApi" web API project should be made the startup project. IIS Express should be chosen to run the project, for ease, even though the project has a Dockerfile (which has not been edited).

Already, I used LocalDB for the database and the connection string in the appsettings.json file.

Also, the database is automatically deleted and recreated on application startup, and migrations and data-seeding are also done. I implemented this in code.

To find user credentials to log in with, kindly see the entity configuration files in the "PromoCodesAspNetCoreWebApi.Persistence" project. The configuration files are in the "Configuration" folder there. The configuration files contain both entity configurations using Fluent API (instead of attributes) and also contain seed data for each entity and relationships are automatically taken care of by Entity Framework Core. The User entity configuration file "UserConfiguration.cs" has user email addresses and passwords that can be used with the Login endpoint of the web API.

The project uses SwaggerUI to present the endpoints of the web API.

Also, the security key used to generate the JWT for this project is in the appsettings.json file just for the sake of this demo for easy review. It is a random security key that can be replaced.

I configured the SwaggerUI for use with Authorization header too, for JWT Bearer token.

Noeworthily, the Bonus entity contains bonuses already assigned to a user with respect to a service (for example, by the system and can be in a predeterminate state where a user is yet to activate the bonus). And the bonus has an associated monetary ammount. Also, the bonus has an optionally associated promo code. So, PromoCode is a different entity that can optionally be used with a bonus. For example, a user can enter a promo code to both get enlisted for a bonus and get the bonus activated in the same process. A promo code has an optionally associated monetary amount, such that when the promo code is used to realize a bonus, the monetary amount is saved with the bonus where applicable. Also, a user can have more than 1 bonus for the same service. All these are in order for there to be flexibility to build on, for the "bonus" feature.
