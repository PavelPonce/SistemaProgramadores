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
END
GO

CREATE PROCEDURE Mante.SP_Titulos_DropDownList
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
