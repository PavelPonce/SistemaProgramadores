USE Intermedio_I

CREATE TABLE GEOGRAFIA_D(
	TIENDA VARCHAR(20) PRIMARY KEY,
	REGION VARCHAR(20),
	PAIS VARCHAR(20)
)
GO
CREATE TABLE VENTAS_H(
	TIENDA VARCHAR(20),
	PRODUCTO VARCHAR(20),
	VENTAS NUMERIC(8,2),
	PRIMARY KEY (TIENDA, PRODUCTO),
	CONSTRAINT FK1 FOREIGN KEY (TIENDA) REFERENCES GEOGRAFIA_D(TIENDA)
)
GO
INSERT INTO GEOGRAFIA_D 
VALUES	('RIVAS','SUR','ESPAÑA'),
		('ALCORCON','NORTE','FRANCIA'),
		('LAS ROZAS','NORTE','ESPAÑA'),
		('MAJADAHONDA','NORTE','ESPAÑA')
GO
INSERT INTO VENTAS_H
VALUES	('ALCORCON','MESAS JARDIN',150),
		('ALCORCON','MUEBLES BAÑO',60),
		('LAS ROZAS','MESAS JARDIN',200),
		('LAS ROZAS','MUEBLES BAÑO',50),
		('MAJADAHONDA','MESAS JARDIN',50),
		('MAJADAHONDA','MUEBLES BAÑO',90),
		('RIVAS','MESAS JARDIN',90),
		('RIVAS','MUEBLES BAÑO',150)


--grouping set
SELECT TIENDA, PRODUCTO, SUM(VENTAS) AS SUMVENTAS
FROM VENTAS_H
GROUP BY GROUPING SETS(TIENDA, (PRODUCTO,VENTAS))

SELECT TIENDA, PRODUCTO, SUM(VENTAS) AS SUMVENTAS
FROM VENTAS_H
GROUP BY TIENDA, PRODUCTO,VENTAS

--CUBE
SELECT TIENDA, PRODUCTO, SUM(VENTAS) AS SUMVENTAS
FROM VENTAS_H
GROUP BY CUBE (TIENDA, PRODUCTO,VENTAS)

--JERARQUIA
SELECT TIENDA, SUM(VENTAS) AS SUMVENTAS
FROM VENTAS_H
GROUP BY ROLLUP (TIENDA, VENTAS) 

SELECT *
FROM VENTAS
PIVOT

CREATE TABLE tbCursos(
	Curso NVARCHAR(20),
	Año INT,
	Valor NUMERIC(8,2)
)
GO
INSERT INTO tbCursos
VALUES	('.NET',2012,15000),
		('JAVA',2012,15000),
		('.NET',2015,35000),
		('.NET',2020,50000),
		('JAVA',2014,20000),
		('.NET',2012,35000)

SELECT *
FROM tbCursos
PIVOT (SUM(Valor) FOR Curso IN ([.NET],JAVA)) AS tbPivot

UPDATE VENTAS_H
SET PRODUCTO = 'MUEBLESBAÑO'
WHERE PRODUCTO = 'MUEBLES BAÑO'

SELECT *, MESASJARDIN + MUEBLESBAÑO AS Total FROM (
SELECT *
FROM VENTAS_H
PIVOT(SUM(VENTAS) FOR PRODUCTO IN (MESASJARDIN, MUEBLESBAÑO)) AS tbVENTASPivot) AS ast

----------------------EJERCICIO 1------------------------------
CREATE TABLE tbClientes(
	Cli_Id INT IDENTITY(1,1),
	Cli_Nombre VARCHAR(60) not null,
	Cli_Apellido VARCHAR(60) NOT NULL,
	Cli_Registro DATETIME
)
ALTER TABLE tbClientes
ADD CONSTRAINT PK_tbClientes_Cli_Id PRIMARY KEY(Cli_Id)
GO
CREATE TABLE tbServicios(
	Ser_Id INT IDENTITY(1,1),
	Cli_Id INT NOT NULL,
	Ser_Nombre VARCHAR(60) NOT NULL,
	Ser_Entradas INT NOT NULL,
	Ser_Registro DATETIME,
	CONSTRAINT FK_tbServicios_tbClientes_IdCliente FOREIGN KEY(Cli_Id) REFERENCES tbClientes(Cli_Id)
)
ALTER TABLE tbServicios
ADD CONSTRAINT PK_tbServicios_Ser_Id PRIMARY KEY(Ser_Id)
GO
INSERT INTO tbClientes
VALUES	('Joseph Arquimedes','Collado Tineo','2015-01-01'),
		('Haden Yasser','Molina','2015-02-04'),
		('Juana Maria','Perez','2015-06-05'),
		('Briant','Rowland','2016-02-04')
GO
INSERT INTO tbServicios
VALUES	(1,'Remolque Vehiculo',3,'2015-09-16'),
		(4,'Revision de motor',5,'2015-09-15'),
		(2,'Chequeo A/C',1,'2015-09-16'),
		(3,'Cambio de bandas freno',6,'2015-04-04'),
		(1,'Revision de aceite',1,'2015-04-04'),
		(1,'Reparacion de transmision',8,'2015-10-06'),
		(3,'Revision de motor',2,'2015-09-16')

--------------------EJ1---------------
SELECT  Ser_Nombre, [1],[2],[3],[4]
FROM tbServicios AS ser
PIVOT (COUNT(Ser_Entradas) FOR Cli_Id IN ([1],[2],[3],[4])) AS tbServicioPivot

--------------------EJ2---------------
SELECT	Ser_Nombre,
		CASE [Joseph Arquimedes] WHEN 1 THEN 'Si' ELSE 'No' END AS [Joseph Arquimedes],
		CASE [Haden Yasser] WHEN 1 THEN 'Si' ELSE 'No' END AS [Haden Yasser],
		CASE [Juana Maria] WHEN 1 THEN 'Si' ELSE 'No' END AS [Juana Maria],
		CASE [Briant] WHEN 1 THEN 'Si' ELSE 'No' END AS [Briant]
FROM (
	SELECT ser.Ser_Nombre, ser.Ser_Entradas, cli.Cli_Nombre
	FROM tbClientes AS cli INNER JOIN tbServicios AS ser
	ON cli.Cli_Id = ser.Cli_Id
)AS tabla
PIVOT (COUNT(Ser_Entradas) FOR Cli_Nombre IN ([Joseph Arquimedes],[Haden Yasser],[Juana Maria],[Briant])) AS tbPivot

--------------------EJ3---------------
SELECT	Ser_Nombre,
		CASE WHEN [2015-09-16] IS NULL THEN 0 ELSE [2015-09-16] END AS [2015-09-16],
		CASE WHEN [2015-09-15] IS NULL THEN 0 ELSE [2015-09-15] END AS [2015-09-15],
		CASE WHEN [2015-04-04] IS NULL THEN 0 ELSE [2015-04-04] END AS [2015-04-04],
		CASE WHEN [2015-10-06] IS NULL THEN 0 ELSE [2015-10-06] END AS [2015-10-06]
FROM tbServicios
PIVOT (SUM(Ser_Entradas) FOR Ser_Registro IN ([2015-09-16],[2015-09-15],[2015-04-04],[2015-10-06])) AS tbPivot

--------------------EJ4---------------
	-----1-----
	SELECT	* 
	FROM(
		SELECT  Ser_Nombre, [1],[2],[3],[4]
		FROM tbServicios AS ser
		PIVOT (COUNT(Ser_Entradas) FOR Cli_Id IN ([1],[2],[3],[4])) AS tbServicioPivot) AS tbUnp1
	UNPIVOT(Ser_Entradas FOR Cli_Id IN ([1],[2],[3],[4])) AS tbUnpivot1
	-----2-----
	SELECT	*
	FROM(
		SELECT	Ser_Nombre,
				CASE [Joseph Arquimedes] WHEN 1 THEN 'Si' ELSE 'No' END AS [Joseph Arquimedes],
				CASE [Haden Yasser] WHEN 1 THEN 'Si' ELSE 'No' END AS [Haden Yasser],
				CASE [Juana Maria] WHEN 1 THEN 'Si' ELSE 'No' END AS [Juana Maria],
				CASE [Briant] WHEN 1 THEN 'Si' ELSE 'No' END AS [Briant]
		FROM (
			SELECT ser.Ser_Nombre, ser.Ser_Entradas, cli.Cli_Nombre
			FROM tbClientes AS cli INNER JOIN tbServicios AS ser
			ON cli.Cli_Id = ser.Cli_Id
		)AS tabla
		PIVOT (COUNT(Ser_Entradas) FOR Cli_Nombre IN ([Joseph Arquimedes],[Haden Yasser],[Juana Maria],[Briant])) AS tbPivot) AS tbUnp2
	UNPIVOT (Ser_Entradas FOR Cli_Nombre IN ([Joseph Arquimedes],[Haden Yasser],[Juana Maria],[Briant])) AS tbUnpivot2
	-----3-----
	SELECT *
	FROM(
		SELECT	Ser_Nombre,
				CASE WHEN [2015-09-16] IS NULL THEN 0 ELSE [2015-09-16] END AS [2015-09-16],
				CASE WHEN [2015-09-15] IS NULL THEN 0 ELSE [2015-09-15] END AS [2015-09-15],
				CASE WHEN [2015-04-04] IS NULL THEN 0 ELSE [2015-04-04] END AS [2015-04-04],
				CASE WHEN [2015-10-06] IS NULL THEN 0 ELSE [2015-10-06] END AS [2015-10-06]
		FROM tbServicios
		PIVOT (SUM(Ser_Entradas) FOR Ser_Registro IN ([2015-09-16],[2015-09-15],[2015-04-04],[2015-10-06])) AS tbPivot) AS tbUnp3
	UNPIVOT(Ser_Entradas FOR Ser_Registro IN ([2015-09-16],[2015-09-15],[2015-04-04],[2015-10-06])) AS tbUnpivot3

---=================================
CREATE TABLE tbEmpleados(
	Emp_Id INT PRIMARY KEY IDENTITY(1,1),
	Emp_Nombre VARCHAR(200),
	Emp_Departamento VARCHAR(100),
	Emp_Categoria CHAR(1),
	Emp_Salario NUMERIC(8,2)
)

INSERT INTO tbEmpleados
VALUES	('Bhavesh Patel','IT','A',10000),
		('Alpesh Patel','SALES','A',10000),
		('Kalpesh Thakor','IT','B',35000),
		('Jay Shah','SALES','B',8500),
		('Ram Nayak','IT','C',15000),
		('Jay Shaw','SALES','C',13000),
		('Mattew','SALES','C',13000)

----------EJERCICIO5--------
SELECT Emp_Departamento,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY Emp_Departamento 

----------EJERCICIO6--------
SELECT	Emp_Departamento,
		Emp_Categoria,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY Emp_Departamento, Emp_Categoria

----------EJERCICIO7--------
SELECT Emp_Departamento,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY Emp_Departamento HAVING SUM(Emp_Salario) = 13000

----------EJERCICIO8--------
SELECT	Emp_Departamento,
		Emp_Categoria,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY CUBE (Emp_Departamento, Emp_Categoria)

----------EJERCICIO9--------
SELECT	Emp_Departamento,
		Emp_Categoria,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY ROLLUP(Emp_Departamento,Emp_Categoria)

----------EJERCICIO10--------
SELECT	Emp_Departamento,
		Emp_Categoria,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY ROLLUP(Emp_Categoria, Emp_Departamento)

----------EJERCICIO11--------
SELECT	Emp_Categoria,
		Emp_Departamento,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY GROUPING SETS(Emp_Categoria,Emp_Departamento,(Emp_Categoria,Emp_Departamento))

----------EJERCICIO12--------
SELECT	Emp_Categoria,
		Emp_Departamento,
		SUM(Emp_Salario) AS 'Suma Salarios'
FROM tbEmpleados
GROUP BY GROUPING SETS((ROLLUP (Emp_Categoria),ROLLUP(Emp_Departamento)))
