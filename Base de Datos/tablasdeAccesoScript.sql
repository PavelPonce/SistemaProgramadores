GO
USE dbAcademiaProgramadores
GO
CREATE SCHEMA Acces

GO
--ACCESO
CREATE TABLE Acces.tbPantallas(
	Panta_Id INT IDENTITY(1,1) NOT NULL,
	Panta_Descripcion VARCHAR(30) NOT NULL,
	CONSTRAINT PK_tbPantallas_Panta_Id PRIMARY KEY(Panta_Id),
	CONSTRAINT UQ_tbPantallas_Panta_Id UNIQUE(Panta_Descripcion),
)
GO
CREATE TABLE Acces.tbRoles(
	Roles_Id INT IDENTITY(1,1) NOT NULL,
	Roles_Descripcion VARCHAR(30) NOT NULL,
	CONSTRAINT PK_tbRoles_Roles_Descripcion PRIMARY KEY(Roles_Id),
	CONSTRAINT UQ_tbRoles_Roles_Descripcion UNIQUE(Roles_Descripcion)
)
GO
CREATE TABLE Acces.tbUsuarios(
	[Usuar_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuar_Usuario] [varchar](50) NOT NULL,
	[Usuar_Contrasena] [varchar](max) NOT NULL,
	[Usuar_Correo] [varchar](max) NULL,
	[Usuar_UltimaSesion] [datetime] NULL,
	[Instr_Id] [int] NULL,
	Roles_Id INT NOT NULL,
	Usuar_Admin BIT DEFAULT 0,
	CONSTRAINT PK_tbUsuarios_Usuar_Id PRIMARY KEY(Usuar_Id),
	CONSTRAINT UQ_tbUsuarios_Usuar_Usuario UNIQUE(Usuar_Usuario),
	CONSTRAINT FK_tbUsuarios_tbRoles_Roles_Id FOREIGN KEY(Roles_Id) REFERENCES Acces.tbRoles(Roles_Id)
)
GO
CREATE TABLE Acces.tbPantallasPorRoles(
	Papro_Id INT IDENTITY(1,1) NOT NULL,
	Panta_Id INT NOT NULL,
	Roles_Id INT NOT NULL,
	CONSTRAINT PK_tbPantallasPorRoles_Paxro_Id PRIMARY KEY(Papro_Id),
	CONSTRAINT FK_tbPantallasPorRoles_tbPantallas_Panta_Id FOREIGN KEY(Panta_Id) REFERENCES Acces.tbPantallas(Panta_Id),
	CONSTRAINT FK_tbPantallasPorRoles_tbRoles_Roles_Id FOREIGN KEY(Roles_Id) REFERENCES Acces.tbRoles(Roles_Id)
)
GO