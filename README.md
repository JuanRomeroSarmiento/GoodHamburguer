## GOOD HAMBURGUER BACKEND APPLICATION

  An API Service that allows you to handle orders and menu items.

 ### Technologies
  - .Net 8
  - C# 12
  - Asp.Net Core 8
  - Entity Framework 8
  - MediatR 12.2.0
  - Sqlite 8.0.4
  - XUnit 2.4.2
  - FluentAssertions 6.12.0
  - NetArchTest 1.3.2 

### Setup

  You just need to clone the project or download the code. No special configuration required.
  The database is a SQLite file with already Menu preloaded information. 

### Architectural and Design Patterns

  - Clean Architecture
  - CQRS
  - Decorator Pattern
  - Repository

### Tests

  Here is some usefull information to test the EndPoints of the application. You may find 
  some payloads for some test scenarios:

44DEC64B-A6A7-4083-80C1-962AE199169D --> MenuId

9D201113-7724-45F8-8129-CF66C4FB3920 --> Sandwich CategoryId

4ED27F3A-FA54-4E0B-A668-C541FBC50387 --> Extras CategoryId

C6CF893B-4AF8-422C-AB76-1B02B43DF73A --> X Burger

76240B4E-CEBE-41B9-BB48-87227DE07207 --> X Egg

F41ADB1C-7EF9-467A-9ED5-2F855A63B412 --> X Bacon

89E255D5-5184-49CF-B254-86968537D9D4 --> Fries

E6C48B6A-F10F-4B20-BEAC-1067763E2A22 --> Soft drink

#### NO VALID ORDERS

##### 1. NO ITEMS

	{
	  "clientName": "camilo",
	  "menuItems": [
	  ]
	}
	
##### 2. REPEATED ITEMS

	{
	  "clientName": "juancamilo",
	  "menuItems": [
		{
		  "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
		},
		{
		  "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
		}
	  ]
	}
	
#### VALID ORDERS

##### 1. NO DISCOUNT ONE ITEM

	{
	  "clientName": "juancamilo",
	  "menuItems": [
	    {
	      "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    }
	  ]
	} 
##### 2. NO DISCOUNT TWO ITEMS
	{
	  "clientName": "juancamilo",
	  "menuItems": [
	    {
	      "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    },
	    {
	      "id": "76240B4E-CEBE-41B9-BB48-87227DE07207",
		  "name": "X Egg",
		  "cost": 4.50,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    }
	  ]
	}

##### 2. 20% DISCOUNT

	{
	  "clientName": "juancamilo",
	  "menuItems": [
	    {
	      "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    },
	    {
	      "id": "89E255D5-5184-49CF-B254-86968537D9D4",
		  "name": "Fries",
		  "cost": 2.0,
		  "menuCategoryId": "4ED27F3A-FA54-4E0B-A668-C541FBC50387"
	    },
	    {
	      "id": "E6C48B6A-F10F-4B20-BEAC-1067763E2A22",
		  "name": "Soft drink",
		  "cost": 2.50,
		  "menuCategoryId": "4ED27F3A-FA54-4E0B-A668-C541FBC50387"
	    }
	  ]
	}

##### 3. 15% DISCOUNT

	{
	  "clientName": "juancamilo",
	  "menuItems": [
	    {
	      "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    },
	    {
	      "id": "E6C48B6A-F10F-4B20-BEAC-1067763E2A22",
		  "name": "Soft drink",
		  "cost": 2.50,
		  "menuCategoryId": "4ED27F3A-FA54-4E0B-A668-C541FBC50387"
	    }
	  ]
	}

##### 4. 10% DISCOUNT

	{
	  "clientName": "juancamilo",
	  "menuItems": [
	    {
	      "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    },
	    {
	      "id": "89E255D5-5184-49CF-B254-86968537D9D4",
		  "name": "Fries",
		  "cost": 2.0,
		  "menuCategoryId": "4ED27F3A-FA54-4E0B-A668-C541FBC50387"
	    }
	  ]
	}

##### UPDATE

	{
	  "id": "BAC78EDE-1F02-4B7F-BD56-5EB0E8B9B6AE",
	  "clientName": "jose daniel",
	  "menuItems": [
	    {
	      "id": "C6CF893B-4AF8-422C-AB76-1B02B43DF73A",
		  "name": "X Burger",
		  "cost": 5.0,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    },
	    {
	      "id": "76240B4E-CEBE-41B9-BB48-87227DE07207",
		  "name": "X Egg",
		  "cost": 4.50,
		  "menuCategoryId": "9D201113-7724-45F8-8129-CF66C4FB3920"
	    }
	  ]
	}





 
