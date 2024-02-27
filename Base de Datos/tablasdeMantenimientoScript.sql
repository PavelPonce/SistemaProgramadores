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

	[Depar_UsuarioCreacion] [int] NOT NULL,
	[Depar_FechaCreacion] [datetime] NOT NULL,
	[Depar_UsuarioModificacion] [int] NULL,
	[Depar_FechaModificacion] [datetime] NULL,
	[Depar_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbDepartamentos_tbUsuarios_Depar_UsuarioCreacion FOREIGN KEY(Depar_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbDepartamentos_tbUsuarios_Depar_UsuarioModificacion FOREIGN KEY(Depar_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
CREATE TABLE Mante.tbMunicipios(
	[Munic_Id] [char](4) NOT NULL,
	[Munic_Descripcion] [varchar](50) NOT NULL,
	[Depar_Id] [char](2) NOT NULL,
	CONSTRAINT PK_tbMunicipios_Munic_Id PRIMARY KEY(Munic_Id),
	CONSTRAINT FK_tbMunicipios_tbDepartamentos_Depar_Id FOREIGN KEY(Depar_Id) REFERENCES Mante.tbDepartamentos(Depar_Id),

	[Munic_UsuarioCreacion] [int] NOT NULL,
	[Munic_FechaCreacion] [datetime] NOT NULL,
	[Munic_UsuarioModificacion] [int] NULL,
	[Munic_FechaModificacion] [datetime] NULL,
	[Munic_Estado] [bit] DEFAULT 1
	CONSTRAINT FK_tbMunicipios_tbUsuarios_Munic_UsuarioCreacion FOREIGN KEY(Munic_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbMunicipios_tbUsuarios_Munic_UsuarioModificacion FOREIGN KEY(Munic_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
CREATE TABLE Mante.tbEstadosCiviles(
	[Estci_Id] [int] IDENTITY(1,1) NOT NULL,
	[Estci_Descripcion] [varchar](30) NOT NULL,
	CONSTRAINT PK_tbEstadosCiviles_Estci_Id PRIMARY KEY(Estci_Id),
	CONSTRAINT UQ_tbEstadosCiviles_Estci_Descripcion UNIQUE(Estci_Descripcion),

	[Estci_UsuarioCreacion] [int] NOT NULL,
	[Estci_FechaCreacion] [datetime] NOT NULL,
	[Estci_UsuarioModificacion] [int] NULL,
	[Estci_FechaModificacion] [datetime] NULL,
	[Estci_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbEstadosCiviles_tbUsuarios_Estci_UsuarioCreacion FOREIGN KEY(Estci_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbEstadosCiviles_tbUsuarios_Estci_UsuarioModificacion FOREIGN KEY(Estci_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
CREATE TABLE Mante.tbPersonas(
	Perso_Id INT IDENTITY(1,1) NOT NULL,
	Perso_Tipo CHAR(1),
	Perso_PrimerNombre VARCHAR(30) NOT NULL,
	Perso_SegundoNombre VARCHAR(30),
	Perso_PrimerApellido VARCHAR(30) NOT NULL,
	Perso_SegundoApellido VARCHAR(30),
	Perso_FechaNacimiento DATE NOT NULL,
	Perso_Sexo CHAR(1) NOT NULL,
	Estci_Id INT NOT NULL,
	Perso_Direccion VARCHAR(MAX) NOT NULL,
	Munic_Id CHAR(4) NOT NULL,
	CONSTRAINT PK_tbPersonas_Perso_Id PRIMARY KEY(Perso_Id),
	CONSTRAINT FK_tbPersonas_tbEstadosCiviles_Estci_Id FOREIGN KEY(Estci_Id) REFERENCES Mante.tbEstadosCiviles(Estci_Id),
	CONSTRAINT FK_tbPersonas_tbMunicipios_Munic_Id FOREIGN KEY(Munic_Id) REFERENCES Mante.tbMunicipios(Munic_Id),
	CONSTRAINT CK_tbPersonas_Perso_Sexo CHECK (Perso_Sexo IN ('M','F')),
	CONSTRAINT CK_tbPersonas_Perso_Tipo CHECK (Perso_Tipo IN ('A','I')),

	[Perso_UsuarioCreacion] [int] NOT NULL,
	[Perso_FechaCreacion] [datetime] NOT NULL,
	[Perso_UsuarioModificacion] [int] NULL,
	[Perso_FechaModificacion] [datetime] NULL,
	[Perso_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbPersonas_tbUsuarios_Perso_UsuarioCreacion FOREIGN KEY(Perso_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbPersonas_tbUsuarios_Perso_UsuarioModificacion FOREIGN KEY(Perso_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
