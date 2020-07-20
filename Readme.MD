# Independent Project - Local Lookup MVC

## Description
Allows the viewer to Create, Read, Edit, and Delete things in the database through the API.
Use with Local Lookup API!

Pagination and Authentication with User Accounts are supported.

# Further Exploration

## Content Pages

Pages of Businesses and Cities are split up depending on the user's selection of 10, 50, or 100.

The program retains information between content pages so that the user is always seeing the same amount of content.

 `page` in the pagination class is The Current Page.
 
 `pageCount` in the pagination class is how many items are on the page. 
 
 Both variables can be changed in the Controllers and Views (Index).


## Identity/Authentication
Users can register and Log In.

Unregistered users can Read entries.
Registered users can Create, Read, Update, and Delete entries.

## Endpoints
#### All endpoints send requests to the API.

### Businesses

#### Create
Allows creation of a Businesses.
`/Businesses/create`
#### Read/Details
Allows Viewing of Business entries and their details.
`/Businesses/{id}`
#### Update
Allows editing of Businesses.
`Businesses/{id}/edit`
####  Delete
`Businesses/{id}/delete`
Deletes entries of Businesses.


### Cities

#### Create
Allows creation of a Cities.
`/cities/create`
#### Read/Details
Allows Viewing of entries and their details.
`/cities/{id}`
#### Update
Allows editing of Cities.
`cities/{id}/edit`
####  Delete
`cities/{id}/delete`
Deletes entries of Cities.

### Accounts

#### Register
Allows the user to Register an account.

#### Login
Allows the user to Log into an existing account.



## Setup/Installation Requirements

* Clone or Download repo to a directory.
* Open Terminal.
* Navigate to main project folder
* Input terminal commands:

```
dotnet ef database update
dotnet run
```

## Known Bugs

_None known_

## Support and contact details

_Robert Smith_

## Technologies Used
```
    ASP.NET
    Razor
    HTML
    C#
    Bootstrap
    Entity Framework
```

## Legal
Copyright (c) 2020 Robert Smith

This software is licensed under Creative Commons 0 license. Use however you want, in fact please do not credit me.
