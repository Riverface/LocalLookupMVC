# Independent Project - Local Lookup MVC

## Description

Allows the viewer to Create, Read, Edit, and Delete things in the database through the API.

Use with Local Lookup API!

`Pagination` and Authentication with `User` Accounts are supported.

## Setup/Installation Requirements

* Clone or Download repo to a directory.
* Open LocalLookupAPI.
* Open Terminal.
* Navigate to main project folder
* Get and follow instructions for [LocalLookupAPI](https://github.com/Riverface/LocalLookupAPI)
* Run in terminal:
```
dotnet ef database update
dotnet run
```

# Further Exploration

## Content Pages

Pages of `Businesses` and `Cities` are split up depending on the`User`'s selection of 10, 50, or 100.

The program retains information between content pages so that the`User` is always seeing the same amount of content.

## Proprietary Class Definitions (PCDs)

### `Pagination`

#### Frontend

> >`page` in the `pagination` class is The Current Page.
> >
> >`pageCount` in the `pagination` class is how many items are on the page. 
> 
> Both variables can be changed in each Index through Views and Controllers.
>
>`Pagination` model is generic, salvage it for your own project if you want :^J

#### `User`

>>Page: Int that controls what page you're on
>>
>>PageCount: Int that controls how many entries of `business` or `city` are on each page.

## Identity/Authentication

>`Users` can Register and Log In.
>
>Unregistered `Users` can Read entries.
>
>Registered `Users` can `Create`, `Read`, `Update`, and `Delete` entries.

## Endpoints
#### All endpoints send requests to the API.

### ` Businesses`

#### Create

>Allows creation of a ` Businesses`.
>
>`/Businesses/create`
>
>Sends a POST request to `/api/Businesses`.

#### Read/Details

>Allows Viewing of Business entries and their details.
>
>`/Businesses/{id}`
>
>Sends a GET request to `/api/Businesses`.

#### Update

>Allows editing of ` Businesses`.
>
>`Businesses/{id}/edit`
>
>Sends a PUT request to `/api/Businesses`.


####  Delete

>Deletes entries of ` Businesses`.
>
>`Businesses/{id}/delete`
>
>Sends a DELETE request to `/api/Businesses`.

### `Cities`
#### Create

>Allows creation of a cities.
>
>`/cities/create`
>
>Sends a POST request to `/api/cities`.

#### Read/Details

>Allows Viewing of Business entries and their details.
>
>`/cities/{id}`
>
>Sends a GET request to `/api/cities`.

#### Update

>Allows editing of cities.
>
>`cities/{id}/edit`
>
>Sends a PUT request to `/api/cities`.

####  Delete

>Deletes entries of cities.
>
>`cities/{id}/delete`
>
>Sends a DELETE request to `/api/cities`.

### Accounts

>#### Register
>
>Allows the `User` to `Register` an `account`.

>#### Login
>
>Allows the`User` to Log into an existing account.

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
