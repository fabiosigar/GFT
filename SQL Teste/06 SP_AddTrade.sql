-- =============================================
-- Author:		Fábio Arruda
-- Create date: 01/03/2021
-- Description:	Procedure fará adição de novas trades na tabela, verificando as informações para vincular a Categoria correta.
-- Input Format: 'Trade1 {Value = 2000000; ClientSector = "Private"} 
--					Trade2 {Value = 400000; ClientSector = "Public"} 
--					Trade3 {Value = 500000; ClientSector = "Public"} 
--					Trade4 {Value = 3000000; ClientSector = "Public"}'
-- Output: Retorna a informação das categorias inseridas nas trades que chamaram a proc e inserem na tabela trade.
-- =============================================
USE GFT
GO
IF OBJECT_ID('SP_AddTrade') IS NOT NULL
	DROP PROCEDURE SP_AddTrade
GO

CREATE PROCEDURE SP_AddTrade
	@Entrada VARCHAR(MAX)
	,@Portfolio VARCHAR(MAX) OUTPUT
AS
BEGIN
	PRINT 'Iniciando Proc'
	CREATE TABLE #tmpTeste (
		Trade INT
		, Value DECIMAL(18,2)
		, ClientSector VARCHAR(50)
		, Categoria VARCHAR(50)
	)
	PRINT 'Tabela Temp Criada'
	
	SELECT 
		row_number() over (order by (select null)) as Id
		,REPLACE(REPLACE(SUBSTRING(value,0,CHARINDEX(';', value)), ';', ''), ' ', '') AS [Value] INTO #Valor 
	FROM string_split(@Entrada, '}')

	SELECT 
		row_number() over (order by (select null)) as Id
		,REPLACE(REPLACE(SUBSTRING(value,CHARINDEX(';', value),LEN(value)), ';', ''), ' ', '') AS [ClientSector] INTO #ClientSector 
	FROM string_split(@Entrada, '}')
	
	DECLARE @RowNumEnt INT
	SET @RowNumEnt = 0 

	DECLARE @IdEnt NCHAR(5)
	SET @IdEnt = (SELECT top 1 Id FROM #Valor)

	DECLARE @LenTempTable INT
	SET @LenTempTable = (SELECT COUNT(*) - 1 FROM #Valor);

	PRINT 'Inicio While Temp Entrada'
	WHILE @RowNumEnt < @LenTempTable
	BEGIN
		SET @RowNumEnt = @RowNumEnt + 1
		PRINT '@RowNumEnt =' + cast(@RowNumEnt AS CHAR(1))

		INSERT INTO #tmpTeste (Trade, Value, ClientSector, Categoria)
		SELECT 
			@RowNumEnt as Trade
			,(SELECT REPLACE(REPLACE(SUBSTRING(Value,CHARINDEX('=', Value),LEN(Value)), '=', ''), ' ', '') FROM #Valor WHERE Id = @IdEnt) AS [Value]
			,(SELECT REPLACE(REPLACE(REPLACE(SUBSTRING(ClientSector,CHARINDEX('=', ClientSector),LEN(ClientSector)), '"', ''), ' ', ''), '=', '') FROM #ClientSector WHERE Id = @IdEnt) AS [ClientSector]
			,NULL

		SET @IdEnt = (SELECT TOP 1 Id FROM #Valor WHERE Id > @IdEnt)
		PRINT '@IdEnt =' + cast(@IdEnt AS VARCHAR(50))
	END
	PRINT 'Fim While Temp Entrada'

	PRINT 'Tabela Temp Carregada com Entrada'
	
	DECLARE @RowNum INT
	SET @RowNum = 0 

	DECLARE @TradeId NCHAR(5)
	SET @TradeId = (SELECT top 1 Trade FROM #tmpTeste)

	DECLARE @LenTempTable2 INT
	SET @LenTempTable2 = (SELECT COUNT(*) FROM #tmpTeste);
	
	PRINT 'Inicio While Checar Categoria'
	WHILE @RowNum < @LenTempTable2
	BEGIN
		SET @RowNum = @RowNum + 1
		PRINT '@RowNum =' + cast(@RowNum AS CHAR(1))

		DECLARE @Valor DECIMAL(18,2)
		SET @Valor = (SELECT Value FROM #tmpTeste WHERE Trade = @TradeId)
		PRINT '@Valor =' + cast(@Valor AS VARCHAR(50))

		DECLARE @ClientSectorNome VARCHAR(50)
		SET @ClientSectorNome = (SELECT ClientSector FROM #tmpTeste WHERE Trade = @TradeId)
		PRINT '@ClientSectorNome =' + cast(@ClientSectorNome AS VARCHAR(50))

		DECLARE @CategoriaId INT
		DECLARE @ClientSectorId INT

		IF @Valor < 1000000
		BEGIN
			PRINT cast(@Valor AS VARCHAR(50)) + ' MENOR QUE 1 MILHAO'
			SET @CategoriaId = (SELECT Id FROM Categoria WHERE UPPER(NomeCategoria) = UPPER('LowRisk'))
			SET @ClientSectorId = (SELECT Id FROM SetorCliente WHERE UPPER(NomeSetorCliente) = UPPER('Public'))
			PRINT '@CategoriaId =' + cast(@CategoriaId AS VARCHAR(50))
			PRINT '@ClientSectorId =' + cast(@ClientSectorId AS VARCHAR(50))
		END
		ELSE IF @Valor > 1000000
		BEGIN
			IF @ClientSectorNome = 'Public'
			BEGIN
				PRINT cast(@Valor AS VARCHAR(50)) + ' MAIOR QUE 1 MILHAO E O ClientSector É ' + cast(@ClientSectorNome AS VARCHAR(50))
				SET @CategoriaId = (SELECT Id FROM Categoria WHERE UPPER(NomeCategoria) = UPPER('MediumRisk'))
				SET @ClientSectorId = (SELECT Id FROM SetorCliente WHERE UPPER(NomeSetorCliente) = UPPER('Public'))
				PRINT '@CategoriaId =' + cast(@CategoriaId AS VARCHAR(50))
				PRINT '@ClientSectorId =' + cast(@ClientSectorId AS VARCHAR(50))
			END
			ELSE
			BEGIN
				PRINT cast(@Valor AS VARCHAR(50)) + ' MAIOR QUE 1 MILHAO E O ClientSector É ' + cast(@ClientSectorNome AS VARCHAR(50))
				SET @CategoriaId = (SELECT Id FROM Categoria WHERE UPPER(NomeCategoria) = UPPER('HighRisk'))
				SET @ClientSectorId = (SELECT Id FROM SetorCliente WHERE UPPER(NomeSetorCliente) = UPPER('Private'))
				PRINT '@CategoriaId =' + cast(@CategoriaId AS VARCHAR(50))
				PRINT '@ClientSectorId =' + cast(@ClientSectorId AS VARCHAR(50))
			END
		END
		
		INSERT INTO Trade (Valor, SetorClienteId, CategoriaId, PortifolioId, DataTrade)
		SELECT Value, @ClientSectorId, @CategoriaId, 1, GETDATE() FROM #tmpTeste WHERE Trade = @TradeId
		
		IF @Portfolio IS NULL
			SET @Portfolio = CONCAT(@Portfolio, (SELECT NomeCategoria FROM Categoria WHERE Id = @CategoriaId))
		ELSE 
			SET @Portfolio = CONCAT(@Portfolio, ',',(SELECT NomeCategoria FROM Categoria WHERE Id = @CategoriaId))
		
		PRINT '@Portfolio =' + cast(@Portfolio AS VARCHAR(Max))

		SET @TradeId = (SELECT TOP 1 Trade FROM #tmpTeste WHERE Trade > @TradeId)
		PRINT '@TradeId =' + cast(@TradeId AS VARCHAR(50))
	END
	
	PRINT 'Fim While Checar Categoria'
	SET @Portfolio = CONCAT('{',UPPER(@Portfolio),'}')
	PRINT '@Portfolio =' + cast(@Portfolio AS VARCHAR(Max))
END
GO
