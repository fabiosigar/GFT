USE [GFT]
GO

/****** Object:  View [dbo].[View_Trade]    Script Date: 02/03/2021 01:12:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('View_Trade') IS NOT NULL
	DROP VIEW View_Trade
GO

CREATE VIEW [dbo].[View_Trade]
AS
SELECT        T.Id, T.Valor, SC.NomeSetorCliente, C.NomeCategoria, P.Nome AS NomePortfolio
FROM            dbo.Trade AS T INNER JOIN
                         dbo.SetorCliente AS SC ON T.SetorClienteId = SC.Id INNER JOIN
                         dbo.Categoria AS C ON T.CategoriaId = C.Id INNER JOIN
                         dbo.Portfolio AS P ON T.PortifolioId = P.Id
GO


