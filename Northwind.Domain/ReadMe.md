# Domain Layer

This will contain all entities, types and logic specific to the domain.
Additionally, this will include the Entity Framework DbContext, Entity Type Configurations, and Migrations. 
Note that this layer is not be dependent only any external resource, such as a physical database.
The Entity Framework related classes are abstract, and should be considered in the same light as .NET Core.
For testing, use an InMemory provider such as InMemory or SqlLite.