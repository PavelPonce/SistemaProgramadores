GO
USE dbAcademiaProgramadores
GO
CREATE SCHEMA Mante
GO
CREATE TABLE Mante.tbDepartamentos(
	[Depar_Id] [char](2) NOT NULL,
	[Depar_Descripcion] [varchar](50) NOT NULL,
	CONSTRAINT PK_tbDepartamentos_Depar_Id UNIQUE(Depar_Id),
	CONSTRAINT UQ_tbDepartamentos_Depar_Descripcion UNIQUE(Depar_Descripcion),

	[Acces_UsuarioCreacion] [int] NOT NULL,
	[Acces_FechaCreacion] [datetime] NOT NULL,
	[Acces_UsuarioModificacion] [int] NULL,
	[Acces_FechaModificacion] [datetime] NULL,
	[Acces_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbDepartamentos_tbUsuarios_Acces_UsuarioCreacion FOREIGN KEY(Acces_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbDepartamentos_tbUsuarios_Acces_UsuarioModificacion FOREIGN KEY(Acces_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
CREATE TABLE Mante.tbMunicipios(
	[Munic_Id] [char](4) NOT NULL,
	[Munic_Descripcion] [varchar](50) NOT NULL,
	[Depar_Id] [char](2) NOT NULL,
	CONSTRAINT PK_tbMunicipios_Munic_Id PRIMARY KEY(Munic_Id),
	CONSTRAINT FK_tbMunicipios_tbDepartamentos_Depar_Id FOREIGN KEY(Depar_Id) REFERENCES Mante.tbDepartamentos(Depar_Id),

	[Acces_UsuarioCreacion] [int] NOT NULL,
	[Acces_FechaCreacion] [datetime] NOT NULL,
	[Acces_UsuarioModificacion] [int] NULL,
	[Acces_FechaModificacion] [datetime] NULL,
	[Acces_Estado] [bit] DEFAULT 1
	CONSTRAINT FK_tbMunicipios_tbUsuarios_Acces_UsuarioCreacion FOREIGN KEY(Acces_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbMunicipios_tbUsuarios_Acces_UsuarioModificacion FOREIGN KEY(Acces_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
CREATE TABLE Mante.tbEstadosCiviles(
	[Estci_Id] [int] IDENTITY(1,1) NOT NULL,
	[Estci_Descripcion] [varchar](30) NOT NULL,
	CONSTRAINT PK_tbEstadosCiviles_Estci_Id PRIMARY KEY(Estci_Id),
	CONSTRAINT UQ_tbEstadosCiviles_Estci_Descripcion UNIQUE(Estci_Descripcion),

	[Acces_UsuarioCreacion] [int] NOT NULL,
	[Acces_FechaCreacion] [datetime] NOT NULL,
	[Acces_UsuarioModificacion] [int] NULL,
	[Acces_FechaModificacion] [datetime] NULL,
	[Acces_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbEstadosCiviles_tbUsuarios_Acces_UsuarioCreacion FOREIGN KEY(Acces_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbEstadosCiviles_tbUsuarios_Acces_UsuarioModificacion FOREIGN KEY(Acces_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)

GO