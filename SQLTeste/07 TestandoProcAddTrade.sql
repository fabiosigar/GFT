DECLARE @Portfolio VARCHAR(MAX)
Exec SP_AddTrade '2000000;Private|400000;Public|500000;Public|3000000;Public', @Portfolio

--SELECT * FROM [dbo].[View_Trade]