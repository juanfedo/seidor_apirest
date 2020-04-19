USE [seidor]
GO

/****** Object:  Table [dbo].[vendedor]    Script Date: 19/04/2020 4:31:51 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[vendedor](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[numero_identificacion] [varchar](100) NULL,
	[codigo_ciudad] [int] NULL,
 CONSTRAINT [PK_vendedor] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[vendedor]  WITH CHECK ADD  CONSTRAINT [FK_vendedor_ciudad] FOREIGN KEY([codigo_ciudad])
REFERENCES [dbo].[ciudad] ([codigo])
GO

ALTER TABLE [dbo].[vendedor] CHECK CONSTRAINT [FK_vendedor_ciudad]
GO


