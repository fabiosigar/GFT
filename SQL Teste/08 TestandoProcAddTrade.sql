USE GFT
GO
DECLARE @Portfolio VARCHAR(MAX)
Exec SP_AddTrade 'Trade1 {Value = 2000000; ClientSector = "Private"} 
Trade2 {Value = 400000; ClientSector = "Public"} 
Trade3 {Value = 500000; ClientSector = "Public"} 
Trade4 {Value = 3000000; ClientSector = "Public"} ', @Portfolio

--SELECT * FROM [GFT].[dbo].[View_Trade]