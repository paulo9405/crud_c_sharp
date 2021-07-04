create database  veiculos

USE [veiculos]
GO

/****** Object:  Table [dbo].[cad_veiculo]    Script Date: 02/07/2021 12:11:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cad_veiculos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[placa] [varchar](7) NOT NULL,
	[marca] [varchar](20) NOT NULL,
	[modelo] [varchar](20) NOT NULL,
	[ano_fabricacao] [varchar](4) NOT NULL,
	[ano_modelo] [varchar](4) NULL,
	[cliente_nome] [varchar](100) NULL,
	[documento] [varchar](4) NULL,
	[numero_documento] [nchar](15) NULL,
 CONSTRAINT [PK_cad_veiculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

