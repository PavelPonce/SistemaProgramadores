CREATE DATABASE dbAcademiaProgramadores
GO
USE dbAcademiaProgramadores
GO
CREATE SCHEMA Acces
GO
CREATE SCHEMA Admin
GO
CREATE SCHEMA Mante
GO
CREATE TABLE [Man].[tbDepartamentos](
	Depto_Id [char](2) NOT NULL,
	Depto_Descripcion [varchar](50) NOT NULL,
	Acces_UsuarioCreacion [int] NOT NULL,
	Acces_FechaCreacion [datetime] NOT NULL,
	Acces_UsuarioModificacion [int] NULL,
	Acces_FechaModificacion [datetime] NULL,
	Acces_Estado [bit] DEFAULT(1) NOT NULL,
	CONSTRAINT PK_tbDepartamentos_Depto_Id PRIMARY KEY(Depto_Id),
	CONSTRAINT UQ_tbDepartamentos_Depto_Descripcion UNIQUE(Depto_Descripcion)
	)
GO

/****** Object:  Table [Man].[tbMunicipios]    Script Date: 26/2/2024 11:39:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Man].[tbMunicipios](
	[Mun_Id] [char](4) NOT NULL,
	[Mun_Descripcion] [varchar](50) NOT NULL,
	[Dep_Id] [char](2) NOT NULL,
	[Acc_UsuarioCreacion] [int] NOT NULL,
	[Acc_FechaCreacion] [datetime] NOT NULL,
	[Acc_UsuarioModificacion] [int] NULL,
	[Acc_FechaModificacion] [datetime] NULL,
	[Acc_Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tbMunicipios_Mun_Id] PRIMARY KEY CLUSTERED 
(
	[Mun_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Man].[tbMunicipios]  WITH CHECK ADD  CONSTRAINT [FK_tbMunicipios_tbDepartamentos_Dep_Id] FOREIGN KEY([Dep_Id])
REFERENCES [Man].[tbDepartamentos] ([Dep_Id])
GO

ALTER TABLE [Man].[tbMunicipios] CHECK CONSTRAINT [FK_tbMunicipios_tbDepartamentos_Dep_Id]
GO

ALTER TABLE [Man].[tbMunicipios]  WITH CHECK ADD  CONSTRAINT [FK_tbMunicipios_tbUsuarios_Acc_UsuarioCreacion] FOREIGN KEY([Acc_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usu_Id])
GO

ALTER TABLE [Man].[tbMunicipios] CHECK CONSTRAINT [FK_tbMunicipios_tbUsuarios_Acc_UsuarioCreacion]
GO

ALTER TABLE [Man].[tbMunicipios]  WITH CHECK ADD  CONSTRAINT [FK_tbMunicipios_tbUsuarios_Acc_UsuarioModificacion] FOREIGN KEY([Acc_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usu_Id])
GO

ALTER TABLE [Man].[tbMunicipios] CHECK CONSTRAINT [FK_tbMunicipios_tbUsuarios_Acc_UsuarioModificacion]
GO

