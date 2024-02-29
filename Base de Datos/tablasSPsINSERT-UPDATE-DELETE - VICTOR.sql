--Alumnos
CREATE PROCEDURE [Acade].[SP_tbAlumnos_INSERT]
(
	@Perso_Id INT,
	@CenEd_IdColegio INT,
	@CenEd_IdUniversidad INT,
	@Titul_Id INT,
	@Alumn_UsuarioCreacion INT,
	@Alumn_FechaCreacion DATETIME,
	@Alumn_Observaciones VARCHAR(150),
	@Alumn_FechaIngreso DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbAlumnos]
	(
		[Perso_Id],
		[CenEd_IdColegio],
		[CenEd_IdUniversidad],
		[Titul_Id],
		[Alumn_UsuarioCreacion],
		[Alumn_FechaCreacion],
		[Alumn_Estado],
		[Alumn_Observaciones],
		[Alumn_FechaIngreso]
	)
	VALUES
	(
		@Perso_Id,
		@CenEd_IdColegio,
		@CenEd_IdUniversidad,
		@Titul_Id,
		@Alumn_UsuarioCreacion,
		@Alumn_FechaCreacion,
		1,
		@Alumn_Observaciones,
		@Alumn_FechaIngreso
	)

END
GO

CREATE PROCEDURE [Acade].[SP_tbAlumnos_UPDATE]
(
	@Perso_Id INT,
	@CenEd_IdColegio INT,
	@CenEd_IdUniversidad INT,
	@Titul_Id INT,
	@Alumn_Observaciones VARCHAR(150),
	@Alumn_FechaIngreso DATETIME,
	@Alumn_UsuarioModificacion INT,
	@Alumn_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbAlumnos]
	SET
		[CenEd_IdColegio] = @CenEd_IdColegio,
		[CenEd_IdUniversidad] = @CenEd_IdUniversidad,
		[Titul_Id] = @Titul_Id,
		[Alumn_Observaciones] = @Alumn_Observaciones,
		[Alumn_FechaIngreso] = @Alumn_FechaIngreso,
		[Alumn_UsuarioModificacion] = @Alumn_UsuarioModificacion,
		[Alumn_FechaModificacion] = @Alumn_FechaModificacion
	WHERE
		[Perso_Id] = @Perso_Id

END
GO

CREATE PROCEDURE [Acade].[SP_tbAlumnos_DELETE]
(
	@Perso_Id INT,
	@Alumn_UsuarioModificacion INT,
	@Alumn_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbAlumnos]
	SET
		[Alumn_Estado] = 0,
		[Alumn_UsuarioModificacion] = @Alumn_UsuarioModificacion,
		[Alumn_FechaModificacion] = @Alumn_FechaModificacion
	WHERE
		[Perso_Id] = @Perso_Id

END
GO
--categorias
CREATE PROCEDURE [Acade].[SP_tbCategorias_INSERT] (
	@Categ_Nombre VARCHAR(30),
	@Categ_UsuarioCreacion INT,
	@Categ_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbCategorias] (
		[Categ_Nombre],
		[Categ_UsuarioCreacion],
		[Categ_FechaCreacion],
		[Categ_Estado]
	)
	VALUES (
		@Categ_Nombre,
		@Categ_UsuarioCreacion,
		@Categ_FechaCreacion,
		1 -- Default value for Categ_Estado
	)

END

GO

CREATE PROCEDURE [Acade].[SP_tbCategorias_UPDATE] (
	@Categ_Id INT,
	@Categ_Nombre VARCHAR(30),
	@Categ_UsuarioModificacion INT,
	@Categ_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbCategorias]
	SET
		[Categ_Nombre] = @Categ_Nombre,
		[Categ_UsuarioModificacion] = @Categ_UsuarioModificacion,
		[Categ_FechaModificacion] = @Categ_FechaModificacion
	WHERE
		[Categ_Id] = @Categ_Id

END

GO

CREATE PROCEDURE [Acade].[SP_tbCategorias_DELETE] (
	@Categ_Id INT,
	@Categ_UsuarioModificacion INT,
	@Categ_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbCategorias]
	SET
		[Categ_Estado] = 0,
		[Categ_UsuarioModificacion] = @Categ_UsuarioModificacion,
		[Categ_FechaModificacion] = @Categ_FechaModificacion
	WHERE
		[Categ_Id] = @Categ_Id

END
GO
--cursos
CREATE PROCEDURE [Acade].[SP_tbCursos_INSERT] (
	@Curso_Nombre VARCHAR(30),
	@Categ_Id INT,
	@Curso_UsuarioCreacion INT,
	@Curso_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbCursos] (
		[Curso_Nombre],
		[Categ_Id],
		[Curso_UsuarioCreacion],
		[Curso_FechaCreacion],
		[Curso_Estado]
	)
	VALUES (
		@Curso_Nombre,
		@Categ_Id,
		@Curso_UsuarioCreacion,
		@Curso_FechaCreacion,
		1 -- Default value for Curso_Estado
	)

END

GO

CREATE PROCEDURE [Acade].[SP_tbCursos_UPDATE] (
	@Curso_Id INT,
	@Curso_Nombre VARCHAR(30),
	@Categ_Id INT,
	@Curso_UsuarioModificacion INT,
	@Curso_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbCursos]
	SET
		[Curso_Nombre] = @Curso_Nombre,
		[Categ_Id] = @Categ_Id,
		[Curso_UsuarioModificacion] = @Curso_UsuarioModificacion,
		[Curso_FechaModificacion] = @Curso_FechaModificacion
	WHERE
		[Curso_Id] = @Curso_Id

END

GO

CREATE PROCEDURE [Acade].[SP_tbCursos_DELETE] (
	@Curso_Id INT,
	@Curso_UsuarioModificacion INT,
	@Curso_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbCursos]
	SET
		[Curso_Estado] = 0,
		[Curso_UsuarioModificacion] = @Curso_UsuarioModificacion,
		[Curso_FechaModificacion] = @Curso_FechaModificacion
	WHERE
		[Curso_Id] = @Curso_Id

END
GO
--cursosporgeneraciones
CREATE PROCEDURE [Acade].[SP_tbCursosPorGeneracion_INSERT] (
	@Curso_Id INT,
	@Gener_Id INT,
	@CuGen_UsuarioCreacion INT,
	@CuGen_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbCursosPorGeneracion] (
		[Curso_Id],
		[Gener_Id],
		[CuGen_UsuarioCreacion],
		[CuGen_FechaCreacion],
		[CuGen_Estado]
	)
	VALUES (
		@Curso_Id,
		@Gener_Id,
		@CuGen_UsuarioCreacion,
		@CuGen_FechaCreacion,
		1 -- Default value for CuGen_Estado
	)

END

GO

CREATE PROCEDURE [Acade].[SP_tbCursosPorGeneracion_UPDATE] (
	@CuGen_Id INT,
	@Curso_Id INT,
	@Gener_Id INT,
	@CuGen_UsuarioModificacion INT,
	@CuGen_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbCursosPorGeneracion]
	SET
		[Curso_Id] = @Curso_Id,
		[Gener_Id] = @Gener_Id,
		[CuGen_UsuarioModificacion] = @CuGen_UsuarioModificacion,
		[CuGen_FechaModificacion] = @CuGen_FechaModificacion
	WHERE
		[CuGen_Id] = @CuGen_Id

END

GO

CREATE PROCEDURE [Acade].[SP_tbCursosPorGeneracion_DELETE] (
	@CuGen_Id INT,
	@CuGen_UsuarioModificacion INT,
	@CuGen_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbCursosPorGeneracion]
	SET
		[CuGen_Estado] = 0,
		[CuGen_UsuarioModificacion] = @CuGen_UsuarioModificacion,
		[CuGen_FechaModificacion] = @CuGen_FechaModificacion
	WHERE
		[CuGen_Id] = @CuGen_Id

END

GO
--generaciones

GO

CREATE PROCEDURE [Acade].[SP_tbGeneraciones_INSERT] (
	@Gener_Nombre VARCHAR(30),
	@Gener_Anhio INT,
	@Gener_UsuarioCreacion INT,
	@Gener_FechaCreacion DATETIME,
	@Gener_FechaInicio DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbGeneraciones] (
		[Gener_Nombre],
		[Gener_Anhio],
		[Gener_UsuarioCreacion],
		[Gener_FechaCreacion],
		[Gener_Estado],
		[Gener_FechaInicio]
	)
	VALUES (
		@Gener_Nombre,
		@Gener_Anhio,
		@Gener_UsuarioCreacion,
		@Gener_FechaCreacion,
		1, -- Default value for Gener_Estado
		@Gener_FechaInicio
	)

END

GO

CREATE PROCEDURE [Acade].[SP_tbGeneraciones_UPDATE] (
	@Gener_Id INT,
	@Gener_Nombre VARCHAR(30),
	@Gener_Anhio INT,
	@Gener_UsuarioModificacion INT,
	@Gener_FechaModificacion DATETIME,
	@Gener_FechaInicio DATETIME,
	@Gener_FechaFin DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbGeneraciones]
	SET
		[Gener_Nombre] = @Gener_Nombre,
		[Gener_Anhio] = @Gener_Anhio,
		[Gener_UsuarioModificacion] = @Gener_UsuarioModificacion,
		[Gener_FechaModificacion] = @Gener_FechaModificacion,
		[Gener_FechaInicio] = @Gener_FechaInicio,
		[Gener_FechaFin] = @Gener_FechaFin
	WHERE
		[Gener_Id] = @Gener_Id

END

GO

CREATE PROCEDURE [Acade].[SP_tbGeneraciones_DELETE] (
	@Gener_Id INT,
	@Gener_UsuarioModificacion INT,
	@Gener_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbGeneraciones]
	SET
		[Gener_Estado] = 0,
		[Gener_UsuarioModificacion] = @Gener_UsuarioModificacion,
		[Gener_FechaModificacion] = @Gener_FechaModificacion
	WHERE
		[Gener_Id] = @Gener_Id

END

GO
--instructores

GO

CREATE PROCEDURE [Acade].[SP_tbInstructores_INSERT] (
	@Perso_Id INT,
	@Titul_Id INT,
	@CenEd_Id INT,
	@Instr_UsuarioCreacion INT,
	@Instr_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbInstructores] (
		[Perso_Id],
		[Titul_Id],
		[CenEd_Id],
		[Instr_UsuarioCreacion],
		[Instr_FechaCreacion],
		[Instr_Estado]
	)
	VALUES (
		@Perso_Id,
		@Titul_Id,
		@CenEd_Id,
		@Instr_UsuarioCreacion,
		@Instr_FechaCreacion,
		1 -- Default value for Instr_Estado
	)

END

GO

CREATE PROCEDURE [Acade].[SP_tbInstructores_UPDATE] (
	@Perso_Id INT,
	@Titul_Id INT,
	@CenEd_Id INT,
	@Instr_UsuarioModificacion INT,
	@Instr_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbInstructores]
	SET
		[Titul_Id] = @Titul_Id,
		[CenEd_Id] = @CenEd_Id,
		[Instr_UsuarioModificacion] = @Instr_UsuarioModificacion,
		[Instr_FechaModificacion] = @Instr_FechaModificacion
	WHERE
		[Perso_Id] = @Perso_Id

END

GO

CREATE PROCEDURE [Acade].[SP_tbInstructores_DELETE] (
	@Perso_Id INT,
	@Instr_UsuarioModificacion INT,
	@Instr_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbInstructores]
	SET
		[Instr_Estado] = 0,
		[Instr_UsuarioModificacion] = @Instr_UsuarioModificacion,
		[Instr_FechaModificacion] = @Instr_FechaModificacion
	WHERE
		[Perso_Id] = @Perso_Id

END

GO
--instructoresporcursoporgeneraciones

GO

CREATE PROCEDURE [Acade].[SP_tbInstructoresPorCursoPorGeneracion_INSERT] (
	@Instr_Id INT,
	@CuGen_Id INT,
	@InsCG_UsuarioCreacion INT,
	@InsCG_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acade].[tbInstructoresPorCursoPorGeneracion] (
		[Instr_Id],
		[CuGen_Id],
		[InsCG_UsuarioCreacion],
		[InsCG_FechaCreacion],
		[InsCG_Estado]
	)
	VALUES (
		@Instr_Id,
		@CuGen_Id,
		@InsCG_UsuarioCreacion,
		@InsCG_FechaCreacion,
		1 -- Default value for InsCG_Estado
	)

END

GO

CREATE PROCEDURE [Acade].[SP_tbInstructoresPorCursoPorGeneracion_UPDATE] (
	@InsCG_Id INT,
	@Instr_Id INT,
	@CuGen_Id INT,
	@InsCG_UsuarioModificacion INT,
	@InsCG_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbInstructoresPorCursoPorGeneracion]
	SET
		[Instr_Id] = @Instr_Id,
		[CuGen_Id] = @CuGen_Id,
		[InsCG_UsuarioModificacion] = @InsCG_UsuarioModificacion,
		[InsCG_FechaModificacion] = @InsCG_FechaModificacion
	WHERE
		[InsCG_Id] = @InsCG_Id

END

GO

CREATE PROCEDURE [Acade].[SP_tbInstructoresPorCursoPorGeneracion_DELETE] (
	@InsCG_Id INT,
	@InsCG_UsuarioModificacion INT,
	@InsCG_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acade].[tbInstructoresPorCursoPorGeneracion]
	SET
		[InsCG_Estado] = 0,
		[InsCG_UsuarioModificacion] = @InsCG_UsuarioModificacion,
		[InsCG_FechaModificacion] = @InsCG_FechaModificacion
	WHERE
		[InsCG_Id] = @InsCG_Id

END

GO
--pantallas

GO

CREATE PROCEDURE [Acces].[SP_tbPantallas_INSERT] (
	@Panta_Descripcion VARCHAR(30),
	@Panta_UsuarioCreacion INT,
	@Panta_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acces].[tbPantallas] (
		[Panta_Descripcion],
		[Panta_UsuarioCreacion],
		[Panta_FechaCreacion],
		[Panta_Estado]
	)
	VALUES (
		@Panta_Descripcion,
		@Panta_UsuarioCreacion,
		@Panta_FechaCreacion,
		1 -- Default value for Panta_Estado
	)

END

GO

CREATE PROCEDURE [Acces].[SP_tbPantallas_UPDATE] (
	@Panta_Id INT,
	@Panta_Descripcion VARCHAR(30),
	@Panta_UsuarioModificacion INT,
	@Panta_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbPantallas]
	SET
		[Panta_Descripcion] = @Panta_Descripcion,
		[Panta_UsuarioModificacion] = @Panta_UsuarioModificacion,
		[Panta_FechaModificacion] = @Panta_FechaModificacion
	WHERE
		[Panta_Id] = @Panta_Id

END

GO

CREATE PROCEDURE [Acces].[SP_tbPantallas_DELETE] (
	@Panta_Id INT,
	@Panta_UsuarioModificacion INT,
	@Panta_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbPantallas]
	SET
		[Panta_Estado] = 0,
		[Panta_UsuarioModificacion] = @Panta_UsuarioModificacion,
		[Panta_FechaModificacion] = @Panta_FechaModificacion
	WHERE
		[Panta_Id] = @Panta_Id

END

GO

GO

CREATE PROCEDURE [Acces].[SP_tbPantallasPorRoles_INSERT] (
	@Panta_Id INT,
	@Roles_Id INT,
	@Papro_UsuarioCreacion INT,
	@Papro_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acces].[tbPantallasPorRoles] (
		[Panta_Id],
		[Roles_Id],
		[Papro_UsuarioCreacion],
		[Papro_FechaCreacion],
		[Papro_Estado]
	)
	VALUES (
		@Panta_Id,
		@Roles_Id,
		@Papro_UsuarioCreacion,
		@Papro_FechaCreacion,
		1 -- Default value for Papro_Estado
	)

END

GO

CREATE PROCEDURE [Acces].[SP_tbPantallasPorRoles_UPDATE] (
	@Papro_Id INT,
	@Panta_Id INT,
	@Roles_Id INT,
	@Papro_UsuarioModificacion INT,
	@Papro_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbPantallasPorRoles]
	SET
		[Panta_Id] = @Panta_Id,
		[Roles_Id] = @Roles_Id,
		[Papro_UsuarioModificacion] = @Papro_UsuarioModificacion,
		[Papro_FechaModificacion] = @Papro_FechaModificacion
	WHERE
		[Papro_Id] = @Papro_Id

END

GO

CREATE PROCEDURE [Acces].[SP_tbPantallasPorRoles_DELETE] (
	@Papro_Id INT,
	@Papro_UsuarioModificacion INT,
	@Papro_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbPantallasPorRoles]
	SET
		[Papro_Estado] = 0,
		[Papro_UsuarioModificacion] = @Papro_UsuarioModificacion,
		[Papro_FechaModificacion] = @Papro_FechaModificacion
	WHERE
		[Papro_Id] = @Papro_Id

END

GO

GO

CREATE PROCEDURE [Acces].[SP_tbRoles_INSERT] (
	@Roles_Descripcion VARCHAR(30),
	@Roles_UsuarioCreacion INT,
	@Roles_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Acces].[tbRoles] (
		[Roles_Descripcion],
		[Roles_UsuarioCreacion],
		[Roles_FechaCreacion],
		[Roles_Estado]
	)
	VALUES (
		@Roles_Descripcion,
		@Roles_UsuarioCreacion,
		@Roles_FechaCreacion,
		1 -- Default value for Roles_Estado
	)

END

GO

CREATE PROCEDURE [Acces].[SP_tbRoles_UPDATE] (
	@Roles_Id INT,
	@Roles_Descripcion VARCHAR(30),
	@Roles_UsuarioModificacion INT,
	@Roles_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbRoles]
	SET
		[Roles_Descripcion] = @Roles_Descripcion,
		[Roles_UsuarioModificacion] = @Roles_UsuarioModificacion,
		[Roles_FechaModificacion] = @Roles_FechaModificacion
	WHERE
		[Roles_Id] = @Roles_Id

END

GO

CREATE PROCEDURE [Acces].[SP_tbRoles_DELETE] (
	@Roles_Id INT,
	@Roles_UsuarioModificacion INT,
	@Roles_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbRoles]
	SET
		[Roles_Estado] = 0,
		[Roles_UsuarioModificacion] = @Roles_UsuarioModificacion,
		[Roles_FechaModificacion] = @Roles_FechaModificacion
	WHERE
		[Roles_Id] = @Roles_Id

END

GO

GO

CREATE PROCEDURE [Acces].[SP_tbUsuarios_INSERT] (
	@Usuar_Usuario VARCHAR(50) ,
	@Usuar_Contrasena NVARCHAR(MAX) , -- Use NVARCHAR for better password storage
	@Instr_Id INT ,
	@Roles_Id INT ,
	@Usuar_Admin BIT ,
	@Usuar_UsuarioCreacion INT ,
	@Usuar_FechaCreacion DATETIME
)
AS
BEGIN

	-- Hash the password before storing it in the database
	DECLARE @HashedPassword VARBINARY(MAX);
	SET @HashedPassword = HASHBYTES('SHA2_512', @Usuar_Contrasena);

	INSERT INTO [Acces].[tbUsuarios] (
		[Usuar_Usuario],
		[Usuar_Contrasena], -- Store the hashed password
		[Instr_Id],
		[Roles_Id],
		[Usuar_Admin],
		[Usuar_UsuarioCreacion],
		[Usuar_FechaCreacion],
		[Usuar_Estado]
	)
	VALUES (
		@Usuar_Usuario,
		@HashedPassword,
		@Instr_Id,
		@Roles_Id,
		@Usuar_Admin,
		@Usuar_UsuarioCreacion,
		@Usuar_FechaCreacion,
		1 -- Default value for Usuar_Estado
	)

END

GO

CREATE PROCEDURE [Acces].[SP_tbUsuarios_UPDATE] (
	@Usuar_Id INT,
	@Usuar_Usuario VARCHAR(50),
	@New_Usuar_Contrasena NVARCHAR(MAX), -- Use NVARCHAR for password
	@Instr_Id INT,
	@Roles_Id INT,
	@Usuar_Admin BIT,
	@Usuar_UsuarioModificacion INT,
	@Usuar_FechaModificacion DATETIME
)
AS
BEGIN

	DECLARE @HashedPassword NVARCHAR(MAX);

	-- If a new password is provided, hash it before updating
	IF @New_Usuar_Contrasena IS NOT NULL
	BEGIN
		SET @HashedPassword = HASHBYTES('SHA2_512', @New_Usuar_Contrasena);
	END
	ELSE
	BEGIN
		-- If no new password is provided, avoid unnecessary updates
		SELECT @HashedPassword = Usuar_Contrasena FROM [Acces].[tbUsuarios] WHERE Usuar_Id = @Usuar_Id;
	END

	UPDATE [Acces].[tbUsuarios]
	SET
		[Usuar_Usuario] = @Usuar_Usuario,
		[Usuar_Contrasena] = @HashedPassword, -- Update with hashed password
		[Instr_Id] = @Instr_Id,
		[Roles_Id] = @Roles_Id,
		[Usuar_Admin] = @Usuar_Admin,
		[Usuar_UsuarioModificacion] = @Usuar_UsuarioModificacion,
		[Usuar_FechaModificacion] = @Usuar_FechaModificacion
	WHERE
		[Usuar_Id] = @Usuar_Id

END

GO

CREATE PROCEDURE [Acces].[SP_tbUsuarios_DELETE] (
	@Usuar_Id INT,
	@Usuar_UsuarioModificacion INT,
	@Usuar_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Acces].[tbUsuarios]
	SET
		[Usuar_Estado] = 0,
		[Usuar_UsuarioModificacion] = @Usuar_UsuarioModificacion,
		[Usuar_FechaModificacion] = @Usuar_FechaModificacion
	WHERE
		[Usuar_Id] = @Usuar_Id

END

GO

GO

CREATE PROCEDURE [Calif].[SP_tbActividades_INSERT] (
	@Activ_Nombre VARCHAR(30) ,
	@Activ_UsuarioCreacion INT ,
	@Activ_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Calif].[tbActividades] (
		[Activ_Nombre],
		[Activ_UsuarioCreacion],
		[Activ_FechaCreacion],
		[Activ_Estado]
	)
	VALUES (
		@Activ_Nombre,
		@Activ_UsuarioCreacion,
		@Activ_FechaCreacion,
		1 -- Default value for Activ_Estado
	)

END

GO

CREATE PROCEDURE [Calif].[SP_tbActividades_UPDATE] (
	@Activ_Id INT,
	@Activ_Nombre VARCHAR(30),
	@Activ_UsuarioModificacion INT,
	@Activ_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Calif].[tbActividades]
	SET
		[Activ_Nombre] = @Activ_Nombre,
		[Activ_UsuarioModificacion] = @Activ_UsuarioModificacion,
		[Activ_FechaModificacion] = @Activ_FechaModificacion
	WHERE
		[Activ_Id] = @Activ_Id

END

GO

CREATE PROCEDURE [Calif].[SP_tbActividades_DELETE] (
	@Activ_Id INT,
	@Activ_UsuarioModificacion INT,
	@Activ_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Calif].[tbActividades]
	SET
		[Activ_Estado] = 0,
		[Activ_UsuarioModificacion] = @Activ_UsuarioModificacion,
		[Activ_FechaModificacion] = @Activ_FechaModificacion
	WHERE
		[Activ_Id] = @Activ_Id

END

GO

GO

CREATE PROCEDURE [Calif].[SP_tbActividadesPorCursoPorGeneracion_INSERT] (
	@Activ_Id INT,
	@CuGen_Id INT,
	@ActCG_Nota NUMERIC(4, 2) ,
	@ActCG_UsuarioCreacion INT,
	@ActCG_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Calif].[tbActividadesPorCursoPorGeneracion] (
		[Activ_Id],
		[CuGen_Id],
		[ActCG_Nota],
		[ActCG_UsuarioCreacion],
		[ActCG_FechaCreacion],
		[ActCG_Estado]
	)
	VALUES (
		@Activ_Id,
		@CuGen_Id,
		@ActCG_Nota,
		@ActCG_UsuarioCreacion,
		@ActCG_FechaCreacion,
		1 -- Default value for ActCG_Estado
	)

END

GO

CREATE PROCEDURE [Calif].[SP_tbActividadesPorCursoPorGeneracion_UPDATE] (
	@ActCG_Id INT,
	@Activ_Id INT,
	@CuGen_Id INT,
	@ActCG_Nota NUMERIC(4, 2) ,
	@ActCG_UsuarioModificacion INT,
	@ActCG_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Calif].[tbActividadesPorCursoPorGeneracion]
	SET
		[Activ_Id] = @Activ_Id,
		[CuGen_Id] = @CuGen_Id,
		[ActCG_Nota] = @ActCG_Nota,
		[ActCG_UsuarioModificacion] = @ActCG_UsuarioModificacion,
		[ActCG_FechaModificacion] = @ActCG_FechaModificacion
	WHERE
		[ActCG_Id] = @ActCG_Id

END

GO

CREATE PROCEDURE [Calif].[SP_tbActividadesPorCursoPorGeneracion_DELETE] (
	@ActCG_Id INT,
	@ActCG_UsuarioModificacion INT,
	@ActCG_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Calif].[tbActividadesPorCursoPorGeneracion]
	SET
		[ActCG_Estado] = 0,
		[ActCG_UsuarioModificacion] = @ActCG_UsuarioModificacion,
		[ActCG_FechaModificacion] = @ActCG_FechaModificacion
	WHERE
		[ActCG_Id] = @ActCG_Id

END

GO

GO

-- SP_tbCalificaciones_INSERT
CREATE PROCEDURE [Calif].[SP_tbCalificaciones_INSERT] (
	@CuGen_Id INT,
	@Alumn_Id INT,
	@Calif_Nota NUMERIC(4, 2) ,
	@Calif_UsuarioCreacion INT,
	@Calif_FechaCreacion DATETIME
)
AS
BEGIN

	INSERT INTO [Calif].[tbCalificaciones] (
		[CuGen_Id],
		[Alumn_Id],
		[Calif_Nota],
		[Calif_UsuarioCreacion],
		[Calif_FechaCreacion],
		[Calif_Estado]
	)
	VALUES (
		@CuGen_Id,
		@Alumn_Id,
		@Calif_Nota,
		@Calif_UsuarioCreacion,
		@Calif_FechaCreacion,
		1 -- Default value for Calif_Estado
	)

END

GO

-- SP_tbCalificaciones_UPDATE
CREATE PROCEDURE [Calif].[SP_tbCalificaciones_UPDATE] (
	@Calif_Id INT,
	@CuGen_Id INT,
	@Alumn_Id INT,
	@Calif_Nota NUMERIC(4, 2) ,
	@Calif_UsuarioModificacion INT,
	@Calif_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Calif].[tbCalificaciones]
	SET
		[CuGen_Id] = @CuGen_Id,
		[Alumn_Id] = @Alumn_Id,
		[Calif_Nota] = @Calif_Nota,
		[Calif_UsuarioModificacion] = @Calif_UsuarioModificacion,
		[Calif_FechaModificacion] = @Calif_FechaModificacion
	WHERE
		[Calif_Id] = @Calif_Id

END

GO

-- SP_tbCalificaciones_DELETE
CREATE PROCEDURE [Calif].[SP_tbCalificaciones_DELETE] (
	@Calif_Id INT,
	@Calif_UsuarioModificacion INT,
	@Calif_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Calif].[tbCalificaciones]
	SET
		[Calif_Estado] = 0,
		[Calif_UsuarioModificacion] = @Calif_UsuarioModificacion,
		[Calif_FechaModificacion] = @Calif_FechaModificacion
	WHERE
		[Calif_Id] = @Calif_Id

END

GO

GO

-- SP_tbCentrosEducativos_INSERT
CREATE PROCEDURE [Mante].[SP_tbCentrosEducativos_INSERT] (
	@CenEd_Nombre VARCHAR(30) ,
	@CenEd_Direccion VARCHAR(150) ,
	@CenEd_Tipo CHAR(1) ,
	@Munic_Id VARCHAR(4) ,
	@CenEd_UsuarioCreacion INT ,
	@CenEd_FechaCreacion DATETIME 
)
AS
BEGIN

	INSERT INTO [Mante].[tbCentrosEducativos] (
		[CenEd_Nombre],
		[CenEd_Direccion],
		[CenEd_Tipo],
		[Munic_Id],
		[CenEd_UsuarioCreacion],
		[CenEd_FechaCreacion],
		[CenEd_Estado]
	)
	VALUES (
		@CenEd_Nombre,
		@CenEd_Direccion,
		@CenEd_Tipo,
		@Munic_Id,
		@CenEd_UsuarioCreacion,
		@CenEd_FechaCreacion,
		1 -- Default value for CenEd_Estado
	)

END

GO

-- SP_tbCentrosEducativos_UPDATE
CREATE PROCEDURE [Mante].[SP_tbCentrosEducativos_UPDATE] (
	@CenEd_Id INT,
	@CenEd_Nombre VARCHAR(30) ,
	@CenEd_Direccion VARCHAR(150) ,
	@CenEd_Tipo CHAR(1) ,
	@Munic_Id VARCHAR(4) ,
	@CenEd_UsuarioModificacion INT,
	@CenEd_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbCentrosEducativos]
	SET
		[CenEd_Nombre] = @CenEd_Nombre,
		[CenEd_Direccion] = @CenEd_Direccion,
		[CenEd_Tipo] = @CenEd_Tipo,
		[Munic_Id] = @Munic_Id,
		[CenEd_UsuarioModificacion] = @CenEd_UsuarioModificacion,
		[CenEd_FechaModificacion] = @CenEd_FechaModificacion
	WHERE
		[CenEd_Id] = @CenEd_Id

END

GO

-- SP_tbCentrosEducativos_DELETE
CREATE PROCEDURE [Mante].[SP_tbCentrosEducativos_DELETE] (
	@CenEd_Id INT,
	@CenEd_UsuarioModificacion INT,
	@CenEd_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbCentrosEducativos]
	SET
		[CenEd_Estado] = 0,
		[CenEd_UsuarioModificacion] = @CenEd_UsuarioModificacion,
		[CenEd_FechaModificacion] = @CenEd_FechaModificacion
	WHERE
		[CenEd_Id] = @CenEd_Id

END

GO

GO

-- SP_tbDepartamentos_INSERT
CREATE PROCEDURE [Mante].[SP_tbDepartamentos_INSERT] (
	@Depar_Id CHAR(2) ,
	@Depar_Descripcion VARCHAR(50) ,
	@Depar_UsuarioCreacion INT ,
	@Depar_FechaCreacion DATETIME 
)
AS
BEGIN

	INSERT INTO [Mante].[tbDepartamentos] (
		[Depar_Id],
		[Depar_Descripcion],
		[Depar_UsuarioCreacion],
		[Depar_FechaCreacion],
		[Depar_Estado]
	)
	VALUES (
		@Depar_Id,
		@Depar_Descripcion,
		@Depar_UsuarioCreacion,
		@Depar_FechaCreacion,
		1 -- Default value for Depar_Estado
	)

END

GO

-- SP_tbDepartamentos_UPDATE
CREATE PROCEDURE [Mante].[SP_tbDepartamentos_UPDATE] (
	@Depar_Id CHAR(2) ,
	@Depar_Descripcion VARCHAR(50) ,
	@Depar_UsuarioModificacion INT,
	@Depar_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbDepartamentos]
	SET
		[Depar_Descripcion] = @Depar_Descripcion,
		[Depar_UsuarioModificacion] = @Depar_UsuarioModificacion,
		[Depar_FechaModificacion] = @Depar_FechaModificacion
	WHERE
		[Depar_Id] = @Depar_Id

END

GO

-- SP_tbDepartamentos_DELETE
CREATE PROCEDURE [Mante].[SP_tbDepartamentos_DELETE] (
	@Depar_Id CHAR(2) ,
	@Depar_UsuarioModificacion INT,
	@Depar_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbDepartamentos]
	SET
		[Depar_Estado] = 0,
		[Depar_UsuarioModificacion] = @Depar_UsuarioModificacion,
		[Depar_FechaModificacion] = @Depar_FechaModificacion
	WHERE
		[Depar_Id] = @Depar_Id

END

GO

GO

-- SP_tbEstadosCiviles_INSERT
CREATE PROCEDURE [Mante].[SP_tbEstadosCiviles_INSERT] (
	@Estci_Descripcion VARCHAR(30) ,
	@Estci_UsuarioCreacion INT ,
	@Estci_FechaCreacion DATETIME 
)
AS
BEGIN

	INSERT INTO [Mante].[tbEstadosCiviles] (
		[Estci_Descripcion],
		[Estci_UsuarioCreacion],
		[Estci_FechaCreacion],
		[Estci_Estado]
	)
	VALUES (
		@Estci_Descripcion,
		@Estci_UsuarioCreacion,
		@Estci_FechaCreacion,
		1 -- Default value for Estci_Estado
	)

END

GO

-- SP_tbEstadosCiviles_UPDATE
CREATE PROCEDURE [Mante].[SP_tbEstadosCiviles_UPDATE] (
	@Estci_Id INT,
	@Estci_Descripcion VARCHAR(30) ,
	@Estci_UsuarioModificacion INT,
	@Estci_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbEstadosCiviles]
	SET
		[Estci_Descripcion] = @Estci_Descripcion,
		[Estci_UsuarioModificacion] = @Estci_UsuarioModificacion,
		[Estci_FechaModificacion] = @Estci_FechaModificacion
	WHERE
		[Estci_Id] = @Estci_Id

END

GO

-- SP_tbEstadosCiviles_DELETE
CREATE PROCEDURE [Mante].[SP_tbEstadosCiviles_DELETE] (
	@Estci_Id INT,
	@Estci_UsuarioModificacion INT,
	@Estci_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbEstadosCiviles]
	SET
		[Estci_Estado] = 0,
		[Estci_UsuarioModificacion] = @Estci_UsuarioModificacion,
		[Estci_FechaModificacion] = @Estci_FechaModificacion
	WHERE
		[Estci_Id] = @Estci_Id

END

GO

GO

-- SP_tbMunicipios_INSERT
CREATE PROCEDURE [Mante].[SP_tbMunicipios_INSERT] (
	@Munic_Id CHAR(4) ,
	@Munic_Descripcion VARCHAR(50) ,
	@Depar_Id CHAR(2) ,
	@Munic_UsuarioCreacion INT ,
	@Munic_FechaCreacion DATETIME 
)
AS
BEGIN

	INSERT INTO [Mante].[tbMunicipios] (
		[Munic_Id],
		[Munic_Descripcion],
		[Depar_Id],
		[Munic_UsuarioCreacion],
		[Munic_FechaCreacion],
		[Munic_Estado]
	)
	VALUES (
		@Munic_Id,
		@Munic_Descripcion,
		@Depar_Id,
		@Munic_UsuarioCreacion,
		@Munic_FechaCreacion,
		1 -- Default value for Munic_Estado
	)

END

GO

-- SP_tbMunicipios_UPDATE
CREATE PROCEDURE [Mante].[SP_tbMunicipios_UPDATE] (
	@Munic_Id CHAR(4) ,
	@Munic_Descripcion VARCHAR(50) ,
	@Depar_Id CHAR(2) ,
	@Munic_UsuarioModificacion INT,
	@Munic_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbMunicipios]
	SET
		[Munic_Descripcion] = @Munic_Descripcion,
		[Depar_Id] = @Depar_Id,
		[Munic_UsuarioModificacion] = @Munic_UsuarioModificacion,
		[Munic_FechaModificacion] = @Munic_FechaModificacion
	WHERE
		[Munic_Id] = @Munic_Id

END

GO

-- SP_tbMunicipios_DELETE
CREATE PROCEDURE [Mante].[SP_tbMunicipios_DELETE] (
	@Munic_Id CHAR(4) ,
	@Munic_UsuarioModificacion INT,
	@Munic_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbMunicipios]
	SET
		[Munic_Estado] = 0,
		[Munic_UsuarioModificacion] = @Munic_UsuarioModificacion,
		[Munic_FechaModificacion] = @Munic_FechaModificacion
	WHERE
		[Munic_Id] = @Munic_Id

END

GO

GO

-- SP_tbPersonas_INSERT
CREATE PROCEDURE [Mante].[SP_tbPersonas_INSERT] (
	@Perso_PrimerNombre VARCHAR(30) ,
	@Perso_SegundoNombre VARCHAR(30) NULL,
	@Perso_PrimerApellido VARCHAR(30) ,
	@Perso_SegundoApellido VARCHAR(30) NULL,
	@Perso_FechaNacimiento DATE ,
	@Perso_Sexo CHAR(1) ,
	@Estci_Id INT ,
	@Perso_Direccion VARCHAR(MAX) ,
	@Munic_Id CHAR(4) ,
	@Perso_Telefono VARCHAR(15) ,
	@Perso_CorreoElectronico VARCHAR(MAX) ,
	@Perso_UsuarioCreacion INT ,
	@Perso_FechaCreacion DATETIME 
)
AS
BEGIN

	INSERT INTO [Mante].[tbPersonas] (
		[Perso_PrimerNombre],
		[Perso_SegundoNombre],
		[Perso_PrimerApellido],
		[Perso_SegundoApellido],
		[Perso_FechaNacimiento],
		[Perso_Sexo],
		[Estci_Id],
		[Perso_Direccion],
		[Munic_Id],
		[Perso_Telefono],
		[Perso_CorreoElectronico],
		[Perso_UsuarioCreacion],
		[Perso_FechaCreacion],
		[Perso_Estado]
	)
	VALUES (
		@Perso_PrimerNombre,
		@Perso_SegundoNombre,
		@Perso_PrimerApellido,
		@Perso_SegundoApellido,
		@Perso_FechaNacimiento,
		@Perso_Sexo,
		@Estci_Id,
		@Perso_Direccion,
		@Munic_Id,
		@Perso_Telefono,
		@Perso_CorreoElectronico,
		@Perso_UsuarioCreacion,
		@Perso_FechaCreacion,
		1 -- Default value for Perso_Estado
	)

END

GO

-- SP_tbPersonas_UPDATE
CREATE PROCEDURE [Mante].[SP_tbPersonas_UPDATE] (
	@Perso_Id INT,
	@Perso_PrimerNombre VARCHAR(30) ,
	@Perso_SegundoNombre VARCHAR(30) NULL,
	@Perso_PrimerApellido VARCHAR(30) ,
	@Perso_SegundoApellido VARCHAR(30) NULL,
	@Perso_FechaNacimiento DATE ,
	@Perso_Sexo CHAR(1) ,
	@Estci_Id INT ,
	@Perso_Direccion VARCHAR(MAX) ,
	@Munic_Id CHAR(4) ,
	@Perso_Telefono VARCHAR(15) ,
	@Perso_CorreoElectronico VARCHAR(MAX) ,
	@Perso_UsuarioModificacion INT,
	@Perso_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbPersonas]
	SET
		[Perso_PrimerNombre] = @Perso_PrimerNombre,
		[Perso_SegundoNombre] = @Perso_SegundoNombre,
		[Perso_PrimerApellido] = @Perso_PrimerApellido,
		[Perso_SegundoApellido] = @Perso_SegundoApellido,
		[Perso_FechaNacimiento] = @Perso_FechaNacimiento,
		[Perso_Sexo] = @Perso_Sexo,
		[Estci_Id] = @Estci_Id,
		[Perso_Direccion] = @Perso_Direccion,
		[Munic_Id] = @Munic_Id,
		[Perso_Telefono] = @Perso_Telefono,
		[Perso_CorreoElectronico] = @Perso_CorreoElectronico,
		[Perso_UsuarioModificacion] = @Perso_UsuarioModificacion,
		[Perso_FechaModificacion] = @Perso_FechaModificacion
	WHERE
		[Perso_Id] = @Perso_Id

END

GO

-- SP_tbPersonas_DELETE
CREATE PROCEDURE [Mante].[SP_tbPersonas_DELETE] (
	@Perso_Id INT,
	@Perso_UsuarioModificacion INT,
	@Perso_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbPersonas]
	SET
		[Perso_Estado] = 0,
		[Perso_UsuarioModificacion] = @Perso_UsuarioModificacion,
		[Perso_FechaModificacion] = @Perso_FechaModificacion
	WHERE
		[Perso_Id] = @Perso_Id

END

GO

GO

-- SP_tbTitulos_INSERT
CREATE PROCEDURE [Mante].[SP_tbTitulos_INSERT] (
	@Titul_Nombre VARCHAR(60) ,
	@Titul_Tipo CHAR(2) ,
	@Titul_UsuarioCreacion INT ,
	@Titul_FechaCreacion DATETIME 
)
AS
BEGIN

	INSERT INTO [Mante].[tbTitulos] (
		[Titul_Nombre],
		[Titul_Tipo],
		[Titul_UsuarioCreacion],
		[Titul_FechaCreacion],
		[Titul_Estado]
	)
	VALUES (
		@Titul_Nombre,
		@Titul_Tipo,
		@Titul_UsuarioCreacion,
		@Titul_FechaCreacion,
		1 -- Default value for Titul_Estado
	)

END

GO

-- SP_tbTitulos_UPDATE
CREATE PROCEDURE [Mante].[SP_tbTitulos_UPDATE] (
	@Titul_Id INT,
	@Titul_Nombre VARCHAR(60) ,
	@Titul_Tipo CHAR(2) ,
	@Titul_UsuarioModificacion INT,
	@Titul_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbTitulos]
	SET
		[Titul_Nombre] = @Titul_Nombre,
		[Titul_Tipo] = @Titul_Tipo,
		[Titul_UsuarioModificacion] = @Titul_UsuarioModificacion,
		[Titul_FechaModificacion] = @Titul_FechaModificacion
	WHERE
		[Titul_Id] = @Titul_Id

END

GO

-- SP_tbTitulos_DELETE
CREATE PROCEDURE [Mante].[SP_tbTitulos_DELETE] (
	@Titul_Id INT,
	@Titul_UsuarioModificacion INT,
	@Titul_FechaModificacion DATETIME
)
AS
BEGIN

	UPDATE [Mante].[tbTitulos]
	SET
		[Titul_Estado] = 0,
		[Titul_UsuarioModificacion] = @Titul_UsuarioModificacion,
		[Titul_FechaModificacion] = @Titul_FechaModificacion
	WHERE
		[Titul_Id] = @Titul_Id

END

GO
v