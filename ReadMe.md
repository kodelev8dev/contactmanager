

## Full Stack .NET Coding Challenge

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

# Functionalities


##  GetAll

 

**list all contacts**

```
Endpoint: GetAll
Route: api/ContactManager/getall
Method: GET
Payload: none
Result:  [
  {
    "id": 1,
    "name": "John Doe",
    "email": "iUqFP@example.com",
    "phone": "1234567890",
    "address": "123 Main St",
    "notes": "Test contact",
    "isDeleted": false,
    "created": "2024-06-18T17:04:36.643007",
    "lastUpdated": "2024-06-18T17:04:36.64301"
  }
]
```



##  GetById

 **select a contact record by Id**
```
Endpoint: GetById
Route: api/ContactManager/getbyid
Method: GET
Payload: Id
Payload Description: Id is an int, representing the Id of the Contact record being searched. To be passed as part of the query string.
Call Example: api/contacts/getbyid?id=1
Result:  

    {
      "id": 1,
      "name": "John Doe",
      "email": "iUqFP@example.com",
      "phone": "1234567890",
      "address": "123 Main St",
      "notes": "Test contact",
      "isDeleted": false,
      "created": "2024-06-18T17:04:36.643007",
      "lastUpdated": "2024-06-18T17:04:36.64301"
    }

``` 


 

##  AddContact

 **create a new contact record**
```
Endpoint: AddContact
Route: api/ContactManager/AddContact
Method: Post
Payload: Contact Object
Payload Description:  Information details of Contacts 
Call Example: api/contacts/addcontact
Request body:

    POST /api/ContactManager/AddContact HTTP/1.1
    Host: localhost:5001
    Content-Type: application/json
    Content-Length: 236
    {
      "id": 1,
      "name": "John Doe",
      "email": "iUqFP@example.com",
      "phone": "1234567890",
      "address": "123 Main St",
      "notes": "Test contact",
      "isDeleted": false,
      "created": "2024-06-18T17:04:36.643007",
      "lastUpdated": "2024-06-18T17:04:36.64301"
    }

Result: Status Code 200
```

##  UpdateContact 
****update a contact record****
```

Endpoint: UpdateContact 
Route: api/ContactManager	/updatecontact
Method: POST
Payload: Id
Payload Descitpion: Id is an int, representing the Id of the Contact record being searched. To be passed as part of query string.
Call Example: api/contacts/getbyid?id=1
Request body:

    POST /api/ContactManager/updatecontact HTTP/1.1
    Host: localhost:5001
    Content-Type: application/json
    Content-Length: 235
    
    {
      "id":1,
     "name": "John Doe",
     "email": "iUqFP@example.com",
     "phone": "1234567890",
     "address": "123 Main St",
     "notes": "Test contact",
     "isDeleted": false,
     "created": "2024-06-18T17:04:36.643007",
     "lastUpdated": "2024-06-18T17:04:36.64301"
    }

Result: Status Code 200

```


##  DeleteContact

 **delete a contact record**

```
Endpoint: DeleteContact
Route: api/ContactManager/DeleteContact
Method: POST
Payload: Id
Payload Description: Id is an int, representing the Id of the Contact record being searched. To be passed as part of the query string.
Call Example: api/ContactManager/DeleteContact?id=3
Result: Status Code 200

``` 

  

## GetContactMap

 **get address location from google map**
```
Endpoint: GetContactMap
Route: api/ContactManager/GetContactMap
Method: GET
Payload: Id
Payload Description: Id is an int, representing the Id of the Contact record being searched. To be passed as part of the query string.
Call Example: api/ContactManager/GetContactMap?id=3
Result: Status Code 200 / image/png

``` 


##  GetBySearchCriteria

 **search in the different columns**
```
Endpoint: GetBySearchCriteria
Route: api/ContactManager/GetBySearchCriteria
Method: GET
Payload: searchString
Payload Description: Id is an int, representing the Id of the Contact record being searched. To be passed as part of the query string.
Call Example: api/ContactManager/GetBySearchCriteria?searchString=John
Result: 
 

    {
          "id": 1,
          "name": "John Doe",
          "email": "iUqFP@example.com",
          "phone": "1234567890",
          "address": "123 Main St",
          "notes": "Test contact",
          "isDeleted": false,
          "created": "2024-06-18T17:04:36.643007",
          "lastUpdated": "2024-06-18T17:04:36.64301"
        }

``` 

## FrontEnd

>
>ContactManager.FE.Mvc is an application created to consume the api exposed by the service. It is writing in C# using asp.net core web framework
>
