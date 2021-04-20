# Farfetch-TESTE
Farfetch - TESTE - .NET Software Engineer Intern

# Installation

1. In the `DB.cs` change the database connection info.
2. In `appsettings` change the ConnectionStrings.

# API Methods

## Itens to WishList
### Add Item to WishList
  `POST https://{server}:{port}/api/WishLists/{id}/Itens/{id}`

### Delete Item from WishList
  `DELETE https://{server}:{port}/api/WishLists/{id}/Itens/{id}`

### Get Item from WishList
  `GET https://{server}:{port}/api/WishLists/{id}/Itens/{id}`

### Get All Itens from WishList
  `GET https://{server}:{port}/api/WishLists/{id}/Itens`


## WishList
### Create WishList
  `POST https://{server}:{port}/api/WishLists`

### Edit WishList
  `PUT https://{server}:{port}/api/WishLists/{id}`

### Delete WishList
  `DELETE https://{server}:{port}/api/WishLists/{id}`

### Get WishList
  `GET https://{server}:{port}/api/WishLists/{id}`

### Get All WishLists
  `GET https://{server}:{port}/api/WishLists`


## Item
### Create Item
  `POST https://{server}:{port}/api/Itens`

### Edit Item
  `PUT https://{server}:{port}/api/Itens/{id}`

### Delete Item
  `DELETE https://{server}:{port}/api/Itens/{id}`

### Get Item
  `GET https://{server}:{port}/api/Itens/{id}`

### Get All Itens
  `GET https://{server}:{port}/api/Itens`
  
  
# DataBase Structure
```
create table Itens (
ItemId int not null  IDENTITY(0,1),
Name varchar(50),
Material varchar(50),
BrandName varchar(50),
Designer varchar(50),
Color varchar(50),
Season varchar(50)
primary key(ItemId)
)


create table  WishLists (
WishId int not null  IDENTITY(0,1),
Name varchar(50),
primary key(WishId),
)


create table  List (
ItemId int not null,
WishId int not null,
FOREIGN KEY (ItemId) REFERENCES Itens(ItemId),
FOREIGN KEY (WishId) REFERENCES WishLists(WishId)
)
```
