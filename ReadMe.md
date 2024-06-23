**Full Stack .NET Coding Challenge**
**Objective**
Your objective is to create a Contact Manager MVC Web App using .NET 8. The look and feel are at 
your discretion if the application feature requirements are met. This should function like an address 
book

**Tech Stack**
- Microsoft .NET 8 MVC Web Application
- Microsoft SQL Server
- jQuery & Bootstrap

**Requirements**
- Use Entity Framework Core to interface with a Microsoft SQL Server database
    - Code First (No EDMX)
    - Seed at least one initial value
- Ajax requests should be used whenever possible
- Front end libraries other than jQuery & Bootstrap need to be approved prior to use
- Git based source control with meaningful and frequent commit messages
- Include at least one Unit Test


**What we have done**

We have developed a software called \"Contact Manager Software\" that
enables users to create, update, and delete contacts. **Requirements**

-   Use Entity Framework Core to interface with a Microsoft SQL Server
    database

    -   The database will be created automatically when the software is
        run and will already contain 3 records.

    -   Note: Ensure the correct connection string is used in the
        appsettings.json under the ContactManager.Service project.

**Software components created:**

**Backend Service**

ContactManager.Service, an API service that provides the following APIs
for contacts: Index, Create, GetByID, Update, Delete, and
SearchByCriteria.

> **Framework Use**

-   Asp dot Net Core

-   Net 8

> **Packages**

-   Microsoft.EntityFrameworkCore

-   Microsoft.EntityFrameworkCore.Design

-   Microsoft.EntityFrameworkCore.SqlServer

-   Microsoft.EntityFrameworkCore.SqlServer.Design

-   Swashbuckle.AspNetCore

-   gmaps-api-net

> **Functionalities**

-   GetAll -- list all contacts

-   GetById -- select a contact record by Id

-   AddContact -- create a new contact record

-   UpdateContact -- update a contact record

-   DeleteContact -- delete a contact record

-   GetContactMap -- get address location from google map

-   GetBySearchCriteria -- search in the different columns

> **FrontEnd**
>
> ContactManager.FE.Mvc is a web application for displaying, creating,
> updating, deleting, and searching for contacts.
>
> **Framework Use**

-   Asp Net Core Web APP Razor MVC

-   Net 8

> **Packages**

-   Newtonsoft.Json

> **Unit Test**
>
> ContactManager.Service.Test for unit testing to ensure all endpoints
> and APIs are working correctly.
>
> **Framework Use**

-   Asp Net Core APP

-   XUnit

-   Net 8

> **Packages**

-   Coverlet.collector

-   FluentAssertions

-   Microsoft.Entity.Core.InMemory

-   Microsoft.Net.Test.SDK

-   NSubtitute

-   Xunit

-   Xunit.runner.visualstudio

 
-   Unit Test Created for the repository

    -   GetAllTests

    -   GetByIdTest

    -   GetByAnySearchTest

    -   AddTest

    -   UpdateTest

    -   DeleteTest

-   Unit Test for Connection String Extension
