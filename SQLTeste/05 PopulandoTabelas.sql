USE [GFT]
GO

INSERT INTO [dbo].[Portfolio]([Nome]) VALUES ('Teste')

INSERT INTO [dbo].[Categoria] ([NomeCategoria]) VALUES ('LowRisk')
INSERT INTO [dbo].[Categoria] ([NomeCategoria]) VALUES ('MediumRisk')
INSERT INTO [dbo].[Categoria] ([NomeCategoria]) VALUES ('HighRisk')


INSERT INTO [dbo].[SetorCliente] ([NomeSetorCliente])VALUES ('Private')
INSERT INTO [dbo].[SetorCliente] ([NomeSetorCliente])VALUES ('Public')

GO


