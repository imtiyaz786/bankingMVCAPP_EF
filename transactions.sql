use bankingDB_VB

create table transactionInfo
(
		trId int primary key,
		trFromAccount int,
		trToAccount int,
		trAmount int
)

insert into transactionInfo values(301, 1011235, 134413, 470000)
insert into transactionInfo values(302, 1011232, 193039, 930000)
insert into transactionInfo values(303, 11212, 093934, 74000320)
insert into transactionInfo values(304, 233735, 194441, 74000340)
insert into transactionInfo values(305, 139393, 194400, 7060040)
insert into transactionInfo values(306, 16614, 14411, 700600)
insert into transactionInfo values(307, 737373, 13344, 7043000)

select * from transactionInfo