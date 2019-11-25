/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DELETE FROM JusRecords;
DELETE FROM JusCustomer;
DELETE FROM JusInterest;
DELETE FROM JusSale;

INSERT INTO JusRecords (RecordID, Title, Performer) VALUES 
('PF002', 'The Dark Side of the Moon', 'Pink Floyd')
,('PF003', 'The Wall', 'Pink Floyd')
,('PF004', 'The Endless River', 'Pink Floyd')
,('PF006', 'Wish You Were Here', 'Pink Floyd')
,('PF007', 'The Division Bell', 'Pink Floyd')
,('IX002', 'Kick', 'INXS')
,('IX005', 'Shabooh Shoobah', 'INXS')
,('SP069', 'Never Mind the Bollocks', 'Sex Pistols')
,('SP070', 'Floggin a Dead Horse', 'Sex Pistols')
,('SP075', 'Agents of Anarchy', 'Sex Pistols');

INSERT INTO JusInterest (InterestCode, InterestDesc) VALUES 
('RR', 'Rock and Roll')
,('JA', 'Jazz')
,('RB', 'Rhythm and Blues');

INSERT INTO JusCustomer (CustNo, InterestCode, CustName, CustAddress, CustPcode) VALUES 
(123, 'RR', 'Jimmy Barnes', '1 Sesame Street', 3000)
,(456, 'JA', 'Ian Moss', '10 Downing Street', 4000)
,(789, 'RB', 'Don Walker', '221B Baker Street', 5000)
,(234, 'RR', 'Steve Prestwich', 'LG1 College Cres, Parkville', 6000)
,(567, 'RB', 'Phil Small', '1 Adelaide Avenue', 7000);

INSERT INTO JusSale (DateOrdered, RecordID, CustNo, Price, InterestCode)
VALUES ('01-Dec-15', 'PF003', 123, 30.00, 'RR')
,('01-Dec-15', 'IX002', 123, 29.95, 'RR')
,('02-Dec-15', 'SP069', 123, 12.45, 'RR')
,('05-Dec-15', 'IX002', 123, 30.00, 'RR')
,('01-Dec-15', 'PF002', 456, 31.00, 'JA')
,('03-Dec-15', 'IX005', 456, 28.95, 'JA')
,('06-Dec-15', 'SP070', 456, 13.45, 'JA')
,('02-Dec-15', 'PF004', 789, 29.00, 'RB')
,('05-Dec-15', 'IX002', 789, 29.95, 'RB')
,('01-Dec-15', 'PF006', 234, 45.00, 'RR')
,('04-Dec-15', 'SP075', 234, 5.67, 'RR')
,('03-Dec-15', 'PF007', 567, 9.95, 'RB');

