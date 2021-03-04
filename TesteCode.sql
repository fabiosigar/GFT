USE [GFT.TesteTecnico]
GO
SELECT TOP (1000) T.[Id]
      ,P.[NomePortfolio]
	  ,T.[Valor]
      ,SC.[NomeSetorCliente]
	  ,C.[NomeCategoria]
	  ,T.[DataTrade]
  FROM [GFT.TesteTecnico].[dbo].[Trades] T
  JOIN [GFT.TesteTecnico].[dbo].[Categorias] C ON T.CategoriaId = C.Id
  JOIN [GFT.TesteTecnico].[dbo].[Portfolios] P ON T.PortfolioId = P.Id
  JOIN [GFT.TesteTecnico].[dbo].[SetorClientes] SC ON T.SetorClienteId = SC.Id