# bankingMVCAPP_EF

An ASP.NET MVC Core Project with Entity Framework Core.

- It is an asp.net core mvc project for banking management.
- The application uses entity framework core in order to work with the database.

Steps:
- Create a database "bankdb" and select it.
- Once selected, create three tables branchInfo, accountsInfo and transactionInfo
  ```sql
  branchInfo
    branchId int primary key,
		branchName varchar(20)
		branchCity varchar(20)
    (add 5 branches here)
  
  accountsInfo
		accNo int primary key,
		accName varchar(20),
		accType varchar(20),
		accBalance int,
		accBranch int
	  constraint fk_accNo foreign key(accBranch) references branchInfo
    (add 15 records here, for different branches randomly)
  
  transactionInfo
		trId int primary key,
		trFromAccount int,
		trToAccount int
		trAmount int
    (add some data here)

- Now, create an asp.net core mvc project.
- Select target framework 5.0.
- Once, the project is loaded, go to Tools and select Manage Nuget and open console.
- Now Fire Scaffold DbContext commands with connections strings, directory detail and provider names like this:
  - Scaffold-DbContext "server=<servername>;database=<dbname>;integrated security=true" -OutputDir Models\EF -Provider Microsoft.EntityFrameworkCore.SqlServer
    - Within EF folder under Model, this will generate model classes/entity classes mapping to the database objects. In our case, it will be BranchInfoes, AccountsInfoes and TransactionInfoes with their respective properties.
    - DbContext class that will act as a bridge between .Net code and database
- Right click on controller folder and select Add Controller.
- Select MVC Controller with Views using Entity Frameworlk
- Select Model class and Data Context class name for which you want to create controller with CRUD actions and generate view for that.
- In our case, it will be BranchInfoesController, AccountsInfoesController and TransactionInfoesController.
- In all the controllers, instantiate DbContext class object and comment out the code for constructor as we are not going to use it for now.
- Open _Layout.cshtml under shared folder,
  ```html
  <li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="AccountsInfoes" asp-action="Index">Accounts</a>
  </li>
  <li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="BranchInfoes" asp-action="Index">Branches</a>
  </li>
  <li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="TransactionInfo" asp-action="Index">Transaction</a>
  </li>
  ```
    - This will update navigation bar for Accounts, Branches and Transaction on the Home Page of the application.
- Now, build and run the application.
- Hurray! We'are done with our MVC application responsible for products and customers management.
 
