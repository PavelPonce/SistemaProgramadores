--Campos de auditoria

[Acces_UsuarioCreacion] [int] NOT NULL,
[Acces_FechaCreacion] [datetime] NOT NULL,
[Acces_UsuarioModificacion] [int] NULL,
[Acces_FechaModificacion] [datetime] NULL,
[Acces_Estado] [bit] DEFAULT 1,
CONSTRAINT FK_tablaPerteneciente_tbUsuarios_Acces_UsuarioCreacion FOREIGN KEY(Acces_UsuarioCreacion) REFERENCES Acces.tbUsuarios(Usuar_Id),
CONSTRAINT FK_tablaPerteneciente_tbUsuarios_Acces_UsuarioModificacion FOREIGN KEY(Acces_UsuarioModificacion) REFERENCES Acces.tbUsuarios(Usuar_Id)

--Campos de auditoria	