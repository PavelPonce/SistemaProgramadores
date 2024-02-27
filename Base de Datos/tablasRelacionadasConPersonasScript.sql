GO
USE dbAcademiaProgramadores
GO
CREATE TABLE Acade.tbAlumnos(
	Perso_Id INT NOT NULL,
	Alumn_ColegioEgresion VARCHAR(30) NOT NULL,
	Alumn_Universidad VARCHAR(30),
	Alumn_Telefono VARCHAR(15),
	Alumn_CorreoElectronico VARCHAR(MAX),
	Alumn_TituloEgresion VARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_tbAlumnos_Perso_Id PRIMARY KEY(Perso_Id),
	CONSTRAINT FK_tbAlumnos_tbPersonas_Perso_Id FOREIGN KEY(Perso_Id) REFERENCES Mante.tbPersonas(Perso_Id),

	[Alumn_UsuarioCreacion] [int] NOT NULL,
	[Alumn_FechaCreacion] [datetime] NOT NULL,
	[Alumn_UsuarioModificacion] [int] NULL,
	[Alumn_FechaModificacion] [datetime] NULL,
	[Alumn_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbAlumnos_tbUsuarios_Alumn_UsuarioCreacion FOREIGN KEY(Alumn_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbAlumnos_tbUsuarios_Alumn_UsuarioModificacion FOREIGN KEY(Alumn_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)
)
GO
CREATE TABLE Acade.tbInstructores(
	Perso_Id INT NOT NULL,
	Instr_Telefono VARCHAR(15),
	Instr_CorreoElectronico VARCHAR(MAX),
	Instr_Pregrado VARCHAR(MAX) NOT NULL,
	Instr_Posgrado VARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_tbInstructores_Perso_Id PRIMARY KEY(Perso_Id),
	CONSTRAINT FK_bInstructores_tbPersonas_Perso_Id FOREIGN KEY(Perso_Id) REFERENCES Mante.tbPersonas(Perso_Id),

	[Instr_UsuarioCreacion] [int] NOT NULL,
	[Instr_FechaCreacion] [datetime] NOT NULL,
	[Instr_UsuarioModificacion] [int] NULL,
	[Instr_FechaModificacion] [datetime] NULL,
	[Instr_Estado] [bit] DEFAULT 1,
	CONSTRAINT FK_tbInstructores_tbUsuarios_Instr_UsuarioCreacion FOREIGN KEY(Instr_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
	CONSTRAINT FK_tbInstructores_tbUsuarios_Instr_UsuarioModificacion FOREIGN KEY(Instr_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)

)

GO 