CREATE TABLE [dbo].[JusCustomer]
(
	[CustNo] INT NOT NULL, 
    [CustName] VARCHAR(50) NOT NULL, 
    [CustAddress] VARCHAR(50) NOT NULL, 
    [CustPcode] INT NOT NULL,

	[InterestCode] Varchar(50) NOT NULL,

	Primary Key (CustNo, InterestCode),
	Foreign Key (InterestCode) References JusInterest
)
