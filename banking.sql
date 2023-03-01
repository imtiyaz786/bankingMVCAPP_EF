create database bankDB
use bankDB

create table branchInfo
(
		branchId int primary key,
		branchName varchar(20),
		branchCity varchar(20)
)

insert into branchInfo values(101, 'Runkuta','Agra')
insert into branchInfo values(102, 'Pullawala','Ludhiana')
insert into branchInfo values(103, 'Rajapur','Allahabad')
insert into branchInfo values(104, 'Hinjewadi','Pune')
insert into branchInfo values(105, 'Thane','Mumbai')

select * from branchInfo

create table accountsInfo
(
		accNo int primary key,
		accName varchar(20),
		accType varchar(20),
		accBalance int,
		accBranch int
	constraint fk_accNo foreign key(accBranch) references branchInfo
)

insert into accountsInfo values(201, 'Imtiyaz','Savings', 75000, 102)
insert into accountsInfo values(202, 'Abhinav','Current', 85000, 102)
insert into accountsInfo values(203, 'Venugopal','PF', 95000, 103)
insert into accountsInfo values(204, 'Manoj','Savings', 175000, 104)
insert into accountsInfo values(205, 'Nikhil','PF', 72000, 105)
insert into accountsInfo values(206, 'Avinesh','Current', 73000, 102)
insert into accountsInfo values(207, 'Suraj','Savings', 74000, 103)
insert into accountsInfo values(208, 'Kavya','Current', 79000, 101)
insert into accountsInfo values(209, 'Vinoth','Savings', 45000, 103)
insert into accountsInfo values(210, 'Bhargav','Current', 25000, 104)
insert into accountsInfo values(211, 'Mustaq','PF', 35000, 105)
insert into accountsInfo values(212, 'Harish','Savings', 65000, 101)
insert into accountsInfo values(213, 'Rahul','Current', 15000, 102)
insert into accountsInfo values(214, 'Shubham','Savings', 75000, 102)
insert into accountsInfo values(215, 'Preeti','Savings', 75000, 105)

select * from accountsInfo
