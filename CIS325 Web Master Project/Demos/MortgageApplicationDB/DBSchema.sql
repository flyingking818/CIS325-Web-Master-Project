USE jwang;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MortgageApplicationXML]') AND type in (N'U'))
DROP TABLE MortgageApplicationXML;

CREATE TABLE MortgageApplicationXML
(
AppID INT IDENTITY PRIMARY KEY,
CustomerName NVARCHAR (100) NOT NULL,
CustomerEmail NVARCHAR (100) NOT NULL,
CustomerSSN NVARCHAR (20) NOT NULL,
CustomerLoanAmount Money NOT NULL,
DataFormXML xml
);