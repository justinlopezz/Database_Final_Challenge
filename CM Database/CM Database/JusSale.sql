CREATE TABLE [dbo].[JusSale]
(
	[DateOrdered] DATE NOT NULL, 
    [Price] MONEY NOT NULL, 
    [RecordID] VARCHAR(50) NOT NULL, 
    [CustNo] INT NOT NULL, 
    [InterestCode] VARCHAR(50) NOT NULL,

	Primary key (DateOrdered, RecordID, CustNo, InterestCode),
	foreign key (RecordID) references JusRecords,
	foreign key (CustNo, InterestCode) references JusCustomer
)
