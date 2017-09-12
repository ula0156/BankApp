# BankApp1 http://juliabank.azurewebsites.net/

**1. Introduction**
-----
This project implements an online banking website where customers can create accounts, deposit and withdraw funds. 
Following features are available:

- Customer registration
- Create an account (saving, checking, loan)
- See all transactions
- Deposit and withdraw funds
	
**2. Tools and technologies used**:
-----
	- Visual Studio 2017
	- Web frameworks
		- Asp.NET MVC
		- Bootstrap
	- Database
		- Microsoft SQL Server
		- Entity Framework 6
	- Azure Web Apps
	
	
**3. Architecture**
----- 
**This solution consists of 2 projects: BankApp and BankWebUI.**
	
* **BankApp**

BankApp implements data models, data access and most of the business logic.

Following data models were implemented:
	
- Accounts model
- Transactions model

The factory method design pattern was used in order to be easy to change the database technologies without requiring significant changes to the rest of the code.
	
* **BankWebUI**

The web project contains the HTTP specific code: models, views and controllers.

- Models were created in BankApp project.
- Views: 
	- Accounts view, displays list of user's accounts.  
	- Transactions, display list of transactions for a specific account.
- Controllers:
	- Accounts controller. 
	- Transactions controller.


