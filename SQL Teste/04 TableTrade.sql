USE [GFT]
GO

/****** Object:  Table [dbo].[Trade]    Script Date: 02/03/2021 00:51:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('Trade') IS NOT NULL
	DROP TABLE Trade
GO

CREATE TABLE [dbo].[Trade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[SetorClienteId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[PortifolioId] [int] NOT NULL,
	[DataTrade] [datetime] NOT NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO

ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_Categoria]
GO

ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_Portfolio] FOREIGN KEY([PortifolioId])
REFERENCES [dbo].[Portfolio] ([Id])
GO

ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_Portfolio]
GO

ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_SetorCliente] FOREIGN KEY([SetorClienteId])
REFERENCES [dbo].[SetorCliente] ([Id])
GO

ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_SetorCliente]
GO


