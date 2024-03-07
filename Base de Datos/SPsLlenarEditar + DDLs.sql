CREATE PROCEDURE Mante.SP_Departamentos_LlenarEditar
	@Depar_Id CHAR(2)
AS
BEGIN
	SELECT *
	FROM Mante.tbDepartamentos 
	WHERE Depar_Id = @Depar_Id
END
GO
CREATE PROCEDURE Mante.SP_Titulos_LlenarEditar
	@Titul_Id INT
AS
BEGIN
	SELECT *
	FROM Mante.tbTitulos
	WHERE Titul_Id = @Titul_Id
END
GO
CREATE PROCEDURE Mante.SP_Municipios_LlenarEditar
	@Munic_Id CHAR(4)
AS
BEGIN
	SELECT mun.*, dep.Depar_Descripcion
	FROM Mante.tbMunicipios AS mun INNER JOIN Mante.tbDepartamentos AS dep
	ON mun.Depar_Id = dep.Depar_Id
	WHERE Munic_Id = @Munic_Id
END
GO
CREATE PROCEDURE Mante.SP_EstadosCiviles_LlenarEditar
	@Estci_Id INT
AS
BEGIN
	SELECT *
	FROM Mante.tbEstadosCiviles 
	WHERE Estci_Id = @Estci_Id
END
GO

CREATE PROCEDURE Mante.SP_Titulos_DropDownListTipos
AS
BEGIN
	SELECT	T.Titul_Tipo,
			CASE Titul_Tipo WHEN 'DO' THEN 'Doctorado' WHEN 'PO' THEN 'Posgrado' WHEN 'PR' THEN 'Pregrado' ELSE 'Bachiller' END AS Titul_TipoDescripcion
	FROM(
		SELECT 'DO' AS Titul_Tipo
		UNION ALL
		SELECT 'PO' AS Titul_Tipo
		UNION ALL
		SELECT 'PR' AS Titul_Tipo
		UNION ALL
		SELECT 'BA' AS Titul_Tipo
	) AS T
END
GO
CREATE PROCEDURE Mante.SP_CentrosEducativos_LlenarEditar
	@CenEd_Id INT
AS
BEGIN
	SELECT ced.*, dep.Depar_Id
	FROM Mante.tbCentrosEducativos AS ced INNER JOIN Mante.tbMunicipios AS mun
	ON mun.Munic_Id = ced.Munic_Id INNER JOIN Mante.tbDepartamentos AS dep
	ON mun.Depar_Id = dep.Depar_Id
	WHERE CenEd_Id = @CenEd_Id
END
GO
CREATE PROCEDURE Mante.SP_Municipios_DropDownListMunicipios
	@Depar_Id CHAR(2)
AS
BEGIN
	SELECT *
	FROM Mante.tbMunicipios
	WHERE Depar_Id = @Depar_Id
END
GO
CREATE PROCEDURE Mante.SP_CentrosEducativos_DropDownListTipo
AS
BEGIN
	SELECT	T.CenEd_Tipo,
			CASE CenEd_Tipo WHEN 'C' THEN 'Colegio' WHEN 'U' THEN 'Universidad' ELSE 'N' END AS CenEd_TipoDescripcion
	FROM(
		SELECT 'N' AS CenEd_Tipo
		UNION ALL
		SELECT 'U' AS CenEd_Tipo
		UNION ALL
		SELECT 'C' AS CenEd_Tipo
	) AS T
END
GO
CREATE PROCEDURE Acade.SP_Categorias_LlenarEditar
	@Categ_Id INT
AS
BEGIN
	SELECT *
	FROM Acade.tbCategorias
	WHERE Categ_Id = @Categ_Id
END
CREATE PROCEDURE Acade.SP_Cursos_LlenarEditar
	@Curso_Id INT
AS
BEGIN
	SELECT *
	FROM Acade.tbCursos
	WHERE Curso_Id = @Curso_Id
END
CREATE PROCEDURE Acade.SP_Generaciones_LlenarEditar
	@Gener_Id INT
AS
BEGIN
	SELECT *
	FROM Acade.tbGeneraciones
	WHERE Gener_Id = @Gener_Id
END