/* **************************************************************************************************
   ***************************** DDL (LENGUAJE DE DEFINICI�N DE DATOS) ******************************
   ************************************************************************************************** */
USE MASTER
GO

/* ********************************************************************
					    CREACI�N DE LA BASE DE DATOS
   ******************************************************************** */
/*IF EXISTS (SELECT * 
				FROM SYSDATABASES
				WHERE NAME = 'BDSistema_Tutoria')
	DROP DATABASE db_a7878d_BDSistemaTutoria
GO*/
CREATE DATABASE db_a7878d_BDSistemaTutoria
GO

use db_a7878d_BDSistemaTutoria

-- Crear tipos de datos para las claves primarias
USE db_a7878d_BDSistemaTutoria
	EXEC SP_ADDTYPE tyCodEscuelaP,		'VARCHAR(4)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodEstudiante,	'VARCHAR(6)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodDocente,		'VARCHAR(5)', 'NOT NULL'
	EXEC SP_ADDTYPE tyCodTutoria,		'VARCHAR(5)', 'NOT NULL'
GO 

/* ********************************************************************
					        CREACI�N DE TABLAS
   ******************************************************************** */
USE db_a7878d_BDSistemaTutoria
GO

/* *************************** TABLA ESCUELA PROFESIONAL *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TEscuela_Profesional')
	DROP TABLE TEscuela_Profesional
GO
CREATE TABLE TEscuela_Profesional
(
	-- Lista de atributos
	CodEscuelaP tyCodEscuelaP,
	Nombre VARCHAR(40) NOT NULL,

	-- Determinar las claves 
	PRIMARY KEY (CodEscuelaP)
);
GO

/* *************************** TABLA DOCENTE *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TDocente')
	DROP TABLE TDocente
GO
CREATE TABLE TDocente
(
	-- Lista de atributos
	Perfil VARBINARY(MAX) NOT NULL,
	CodDocente tyCodDocente,
	APaterno VARCHAR(15) NOT NULL,
	AMaterno VARCHAR(15) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Telefono VARCHAR(15) NOT NULL,
	Categoria VARCHAR(10) NOT NULL CHECK (Categoria IN ('NOMBRADO', 
														'CONTRATADO')),
	Subcategoria VARCHAR(9) NOT NULL CHECK (Subcategoria IN ('PRINCIPAL', 
															 'ASOCIADO', 
															 'AUXILIAR', 
															 'A1',
															 'A2',
															 'A3',
															 'B1',
															 'B2',
															 'B3')),
	Regimen VARCHAR(20) NOT NULL CHECK (Regimen IN ('TIEMPO COMPLETO', 
													'DEDICACI�N EXCLUSIVA',
													'TIEMPO PARCIAL')),
	CodEscuelaP tyCodEscuelaP,
	Horario VARCHAR(150),

	-- Determinar las claves 
	PRIMARY KEY (CodDocente),
	CONSTRAINT FK_CodEscuelaPD 
		FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuela_Profesional
		ON UPDATE CASCADE
);
GO

/* *************************** TABLA ESTUDIANTE *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TEstudiante')
	DROP TABLE TEstudiante
GO
CREATE TABLE TEstudiante
(
	-- Lista de atributos
	Perfil VARBINARY(MAX) NOT NULL,
	CodEstudiante tyCodEstudiante,
	APaterno VARCHAR(15) NOT NULL,
	AMaterno VARCHAR(15) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Telefono VARCHAR(15) NOT NULL,
	CodEscuelaP tyCodEscuelaP,
	PersonaReferencia VARCHAR(20),
	TelefonoReferencia VARCHAR(15),
	InformacionPersonal VARCHAR(200), --Cifrado
	CodDocente VARCHAR(5), -- Tutor
	--EstadoFisico VARCHAR(40),
	--EstadoMental VARCHAR(40),

	-- Determinar las claves 
	PRIMARY KEY (CodEstudiante),
	CONSTRAINT FK_CodEscuelaPE FOREIGN KEY (CodEscuelaP)
		REFERENCES TEscuela_Profesional
		ON UPDATE CASCADE,
	CONSTRAINT FK_Tutor FOREIGN KEY (CodDocente)
		REFERENCES TDocente
		ON UPDATE NO ACTION
);
GO

/* *************************** TABLA TUTOR�A *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TTutoria')
	DROP TABLE TTutoria
GO
CREATE TABLE TTutoria
(
	-- Lista de atributos
	CodTutoria tyCodTutoria,
	CodDocente tyCodDocente,
	CodEstudiante tyCodEstudiante,

	-- Determinar las claves 
	PRIMARY KEY (CodTutoria),
	CONSTRAINT FK_CodDocente 
		FOREIGN KEY (CodDocente)
		REFERENCES TDocente(CodDocente),
	CONSTRAINT FK_CodEstudiante 
		FOREIGN KEY (CodEstudiante)
		REFERENCES TEstudiante(CodEstudiante)
);
GO

/* *************************** TABLA FICHA DE TUTOR�A *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TFichaTutoria')
	DROP TABLE TFichaTutoria
GO
CREATE TABLE TFichaTutoria
(
	-- Lista de atributos
	CodTutoria tyCodTutoria,
	Fecha DATETIME NOT NULL,
	Dimension VARCHAR(15) DEFAULT 'ACAD�MICA' CHECK (Dimension IN ('ACAD�MICA',
																   'PERSONAL',
																   'PROFESIONAL')),
	Descripcion VARCHAR(100),
	Referencia VARCHAR(100),
	Observaciones VARCHAR(100),

	-- Determinar las claves
	CONSTRAINT FK_CodTutoria 
		FOREIGN KEY (CodTutoria)
		REFERENCES TTutoria
		ON UPDATE CASCADE
		ON DELETE CASCADE
);
GO

/* *************************** TABLA USUARIO *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'TUsuario')
	DROP TABLE TUsuario
GO
CREATE TABLE TUsuario
(
	-- Lista de atributos
	Perfil VARBINARY(MAX) NOT NULL,
	Usuario VARCHAR(6) NOT NULL,
	Contraseña VARCHAR(20) NOT NULL,
	Acceso VARCHAR(20) NOT NULL,
	Datos VARCHAR(53) NOT NULL,

	-- Definir la clave primaria
	PRIMARY KEY(Usuario)	
)
GO

/* *************************** TABLA HISTORIAL *************************** */
IF EXISTS (SELECT * 
				FROM SYSOBJECTS
				WHERE NAME = 'Historial')
	DROP TABLE Historial
GO
CREATE TABLE Historial
(
	-- Lista de atributos
	IdHistorial INT IDENTITY(1,1),
	Fecha DATETIME,
	Tabla VARCHAR(30),
	Operacion VARCHAR(15),
	IdRegistroAfectado VARCHAR(20),
	ValorAnterior VARCHAR(400),
	ValorPosterior VARCHAR(400),

	-- Definir la clave primaria
	PRIMARY KEY(IdHistorial)	
)
GO

/* **************************************************************************************************
   ******************* FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS********************
   ************************************************************************************************** */
USE db_a7878d_BDSistemaTutoria
GO

/* ************************** FUNCI�N PARA GENERAR UNA CONTRASE�A ************************** */

CREATE VIEW viAleatorio
AS
	-- Generar un n�mero aleatorio
	SELECT RAND() AS ValorAleatorio
GO 

CREATE FUNCTION fnGenerarContraseña ()
RETURNS VARCHAR(8)
AS
BEGIN
	-- Declarar las variables necesarias
	DECLARE @Indice INT;
    DECLARE @Contador INT;
    DECLARE @Caracteres VARCHAR(37);      
    DECLARE @Contraseña VARCHAR(8);

	-- Establecer los valores iniciales
	SET @Contador = 0
	SET @Caracteres = 'ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789'
	SET @Contraseña = ''
    
	-- Tomar un �ndice aleatorio de los caracteres para generar una contrase�a
    WHILE (@Contador < 8)
    BEGIN
        SET @Indice = CEILING((SELECT ValorAleatorio FROM viAleatorio) * (LEN(@Caracteres)))
        SET @Contraseña = @Contraseña + SUBSTRING(@Caracteres, @Indice, 1)
        SET @Contador = @Contador + 1
    END;

	-- Retornar una contrase�a de 8 caracteres
    RETURN (@Contraseña);
END;
GO

/* ************************** FUNCI�N PARA GENERAR UNA C�DIGO DE TUTOR�A ************************** */

CREATE FUNCTION fnGenerarCodTutoria ()
RETURNS VARCHAR(8)
AS
BEGIN
	-- Declarar un contador
	DECLARE @Contador INT;

	-- Determinar el valor del contador con el valor maximo en la tabla TTutoria
	SELECT @Contador = RIGHT(MAX(CodTutoria), 4) + 1
		FROM TTutoria

	-- Verificar si la tabla este vacia
	IF (@Contador IS NULL)
	BEGIN
		SET @Contador = 1
	END;

	-- Retornar el valor de la clave primaria a partir del contador
    RETURN (CONCAT('T', RIGHT(CONCAT('000', @Contador), 4)));
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESCUELA PROFESIONAL ****************** */

-- Crear un procedimiento para mostrar escuelas profesionales
CREATE PROCEDURE spuMostrarEscuelas
AS
BEGIN
	-- Mostrar la tabla de TEscuela_Profesional
	SELECT *
		FROM TEscuela_Profesional
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESTUDIANTE ****************** */

-- Crear un procedimiento para mostrar estudiantes
CREATE PROCEDURE spuMostrarEstudiantes @CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Mostrar la tabla de TEstudiante
	SELECT Perfil1 = ET.Perfil, Perfil2 = ET.Perfil, ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre,
		   Estudiante = (ET.APaterno + ' ' + 
						 ET.AMaterno + ', ' + 
						 ET.Nombre),
		   ET.Email, ET.Direccion, ET.Telefono, ET.CodEscuelaP,
		   EscuelaProfesional = EP.Nombre, ET.PersonaReferencia, 
		   --ET.TelefonoReferencia, ET.EstadoFisico, ET.EstadoMental
		   ET.TelefonoReferencia, ET.InformacionPersonal, CodTutor = ET.CodDocente
		FROM TEstudiante ET INNER JOIN TEscuela_Profesional EP ON
			 ET.CodEscuelaP = EP.CodEscuelaP
	    WHERE EP.CodEscuelaP = @CodEscuelaP
END;
GO

-- Crear un procedimiento para mostrar estudiantes sin tutor
CREATE PROCEDURE spuMostrarEstudiantesSinTutor @CodEscuelaP VARCHAR(4),
											   @Filas INT
AS
BEGIN
	-- Mostrar la tabla de TEstudiante
	SELECT TOP(@Filas) ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre
		FROM TEstudiante ET, TEscuela_Profesional EP
		WHERE ET.CodEscuelaP = EP.CodEscuelaP AND ET.CodEscuelaP = @CodEscuelaP AND ET.CodDocente IS NULL
END;
GO

-- Crear un procedimiento para buscar un estudiante.
CREATE PROCEDURE spuBuscarEstudiante @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Mostrar la tabla de TEstudiante por el texto que se desea buscar
	SELECT Perfil1 = ET.Perfil, Perfil2 = ET.Perfil, ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre,
		   Estudiante = (ET.APaterno + ' ' + 
						 ET.AMaterno + ', ' + 
						 ET.Nombre),
		   ET.Email, ET.Direccion, ET.Telefono, ET.CodEscuelaP,
		   EscuelaProfesional = EP.Nombre, ET.PersonaReferencia, 
		   ET.TelefonoReferencia, ET.InformacionPersonal, CodTutor = ET.CodDocente
		FROM TEstudiante ET INNER JOIN TEscuela_Profesional EP ON
			 ET.CodEscuelaP = EP.CodEscuelaP
		WHERE ET.CodEstudiante = @CodEstudiante
END;
GO

-- Crear un procedimiento para buscar estudiantes por cualquier atributo
CREATE PROCEDURE spuBuscarEstudiantes @CodEscuelaP VARCHAR(4),
									  @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla de TEstudiante por el texto que se desea buscar
	SELECT Perfil1 = ET.Perfil, Perfil2 = ET.Perfil, ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre,
		   Estudiante = (ET.APaterno + ' ' + 
						 ET.AMaterno + ', ' + 
						 ET.Nombre),
		   ET.Email, ET.Direccion, ET.Telefono, ET.CodEscuelaP,
		   EscuelaProfesional = EP.Nombre, ET.PersonaReferencia, 
		   --ET.TelefonoReferencia, ET.EstadoFisico, ET.EstadoMental
		   ET.TelefonoReferencia, ET.InformacionPersonal, CodTutor = ET.CodDocente
		FROM TEstudiante ET INNER JOIN TEscuela_Profesional EP ON
			 ET.CodEscuelaP = EP.CodEscuelaP
		WHERE ET.CodEstudiante LIKE (@Texto + '%') OR
			  ET.APaterno LIKE (@Texto + '%') OR
			  ET.AMaterno LIKE (@Texto + '%') OR
			  ET.Nombre LIKE (@Texto + '%') OR
			  ET.Email LIKE (@Texto + '%') OR
			  ET.Direccion LIKE (@Texto + '%') OR
			  ET.Telefono LIKE (@Texto + '%') OR
			  EP.Nombre LIKE (@Texto + '%') OR
			  ET.PersonaReferencia LIKE (@Texto + '%') OR
			  ET.TelefonoReferencia LIKE (@Texto + '%') OR
			  --ET.EstadoFisico LIKE (@Texto + '%') OR
			  --ET.EstadoMental LIKE (@Texto + '%')
			  ET.InformacionPersonal LIKE (@Texto + '%')
END;
GO

-- Crear un procedimiento para buscar estudiantes sin tutor por cualquier atributo
CREATE PROCEDURE spuBuscarEstudiantesSinTutor @CodEscuelaP VARCHAR(4),
										      @Texto VARCHAR(20),
											  @Filas INT
AS
BEGIN
	-- Mostrar la tabla de TEstudiante por el texto que se desea buscar
	SELECT TOP(@Filas) ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre
		FROM TEstudiante ET, TEscuela_Profesional EP
		WHERE ET.CodEscuelaP = EP.CodEscuelaP AND ET.CodDocente IS NULL AND
			 (ET.CodEstudiante LIKE (@Texto + '%') OR
			  ET.APaterno LIKE (@Texto + '%') OR
			  ET.AMaterno LIKE (@Texto + '%') OR
			  ET.Nombre LIKE (@Texto + '%'))
END;
GO

-- Crear un procedimiento para insertar un estudiante
CREATE PROCEDURE spuInsertarEstudiante @Perfil VARBINARY(MAX),
									   @CodEstudiante VARCHAR(6),
									   @APaterno VARCHAR(15),
									   @AMaterno VARCHAR(15),
									   @Nombre VARCHAR(20),
									   @Email VARCHAR(50),
									   @Direccion VARCHAR(50),
									   @Telefono VARCHAR(15),
									   @CodEscuelaP VARCHAR(4),
									   @PersonaReferencia VARCHAR(20),
									   @TelefonoReferencia VARCHAR(15),
									   @InformacionPersonal VARCHAR(200)
									   --@EstadoFisico VARCHAR(40),
									   --@EstadoMental VARCHAR(40)
AS
BEGIN
	-- Insertar un estudiante en la tabla de TEstudiante
	INSERT INTO TEstudiante
		VALUES (@Perfil, @CodEstudiante, @APaterno, @AMaterno, @Nombre, @Email, 
				@Direccion, @Telefono, @CodEscuelaP, @PersonaReferencia, 
				@TelefonoReferencia, @InformacionPersonal, NULL)--@EstadoFisico, @EstadoMental)

	-- Insertar un usuario con el c�digo del estudiante en la tabla de TUsuario
	INSERT INTO TUsuario
		VALUES (@Perfil, @CodEstudiante, DBO.fnGenerarContraseña(), 'Estudiante', 
				@APaterno + ' ' + @AMaterno + ', ' + @Nombre)
END;
GO

-- Crear un procedimiento para actualizar un estudiante
CREATE PROCEDURE spuActualizarEstudiante @Perfil VARBINARY(MAX),
										 @CodEstudiante VARCHAR(6),
										 @APaterno VARCHAR(15),
										 @AMaterno VARCHAR(15),
										 @Nombre VARCHAR(20),
										 @Email VARCHAR(50),
										 @Direccion VARCHAR(50),
										 @Telefono VARCHAR(15),
										 @CodEscuelaP VARCHAR(4),
										 @PersonaReferencia VARCHAR(20),
										 @TelefonoReferencia VARCHAR(15),
										 @InformacionPersonal VARCHAR(200)
										 --@EstadoFisico VARCHAR(40),
										 --@EstadoMental VARCHAR(40)					
AS
BEGIN
	-- Actualizar un estudiante de la tabla de TEstudiante
	UPDATE TEstudiante
		SET Perfil = @Perfil, CodEstudiante = @CodEstudiante, APaterno = @APaterno, AMaterno = @AMaterno, 
			Nombre = @Nombre, Email = @Email, Direccion = @Direccion, Telefono = @Telefono,
			CodEscuelaP = @CodEscuelaP, PersonaReferencia = @PersonaReferencia, 
			TelefonoReferencia = @TelefonoReferencia, --EstadoFisico = @EstadoFisico, 
			InformacionPersonal = @InformacionPersonal
			--EstadoMental = @EstadoMental
		WHERE CodEstudiante = @CodEstudiante

	-- Actualizar un estudiante de la tabla de TTutoria
	UPDATE TTutoria
		SET CodEstudiante = @CodEstudiante
		WHERE CodEstudiante = @CodEstudiante

	-- Actualizar un estudiante de la tabla de TUsuario
	UPDATE TUsuario
		SET Perfil = @Perfil, Usuario = @CodEstudiante, 
			Datos = @APaterno + ' ' + @AMaterno + ', ' + @Nombre
		WHERE Usuario = @CodEstudiante
END;
GO

-- Crear un procedimiento para eliminar un estudiante
CREATE PROCEDURE spuEliminarEstudiante @CodEstudiante VARCHAR(6)					
AS
BEGIN
	-- Eliminar un estudiante de la tabla de TEstudiante
	DELETE FROM TEstudiante
		WHERE CodEstudiante = @CodEstudiante

	-- Eliminar un usuario relacionado con un estudiante
	DELETE FROM TUsuario
		WHERE Usuario = @CodEstudiante
END;
GO

-- Crear un procedimiento para asignar un tutor a un estudiante
CREATE PROCEDURE spuAsignarTutor @CodEstudiante VARCHAR(6),
								 @CodDocente VARCHAR(5)
AS
BEGIN
	-- Actualizar un estudiante de la tabla de TEstudiante
	UPDATE TEstudiante
		SET CodDocente = @CodDocente
		WHERE CodEstudiante = @CodEstudiante
END;
GO

-- Crear un procedimiento para eliminar el tutor de un estudiante
CREATE PROCEDURE spuEliminarTutor @CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Actualizar un estudiante de la tabla de TEstudiante
	UPDATE TEstudiante
		SET CodDocente = NULL
		WHERE CodEstudiante = @CodEstudiante
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA DOCENTE ****************** */

-- Crear un procedimiento para mostrar docentes
CREATE PROCEDURE spuMostrarDocentes @CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Mostrar la tabla de TDocente
	SELECT Perfil1 = D.Perfil, Perfil2 = D.Perfil, D.CodDocente, D.APaterno, D.AMaterno, D.Nombre, 
		   Docente = (D.APaterno + ' ' + 
					  D.AMaterno + ', ' + 
					  D.Nombre),
		   D.Email, D.Direccion, D.Telefono,
		   D.Categoria, D.Subcategoria, D.Regimen, D.CodEscuelaP,
		   EscuelaProfesional = E.Nombre, D.Horario
		FROM TDocente D INNER JOIN TEscuela_Profesional E ON
			 D.CodEscuelaP = E.CodEscuelaP
	    WHERE D.CodEscuelaP = @CodEscuelaP
END;
GO

-- Crear un procedimiento para mostrar tutores
CREATE PROCEDURE spuMostrarTutores @CodEscuelaP VARCHAR(4)
AS
BEGIN
	-- Mostrar la tabla de Tutores
	SELECT D.CodDocente, D.APaterno, D.AMaterno, D.Nombre, TotalTutorados = COUNT(TE.CodDocente)
		FROM ((TDocente D INNER JOIN TEscuela_Profesional E ON
			   D.CodEscuelaP = E.CodEscuelaP) LEFT JOIN TEstudiante TE ON
			   D.CodDocente = TE.CodDocente)
		WHERE D.CodEscuelaP = @CodEscuelaP AND D.Subcategoria IN ('PRINCIPAL','ASOCIADO','AUXILIAR','A1','A2','A3') AND D.Regimen IN ('TIEMPO COMPLETO','DEDICACIÓN EXCLUSIVA')
		GROUP BY D.CodDocente, D.APaterno, D.AMaterno, D.Nombre
END;
GO

-- Crear un procedimiento para mostrar tutorados
CREATE PROCEDURE spuMostrarTutorados @CodDocente VARCHAR(5)
AS
BEGIN
	-- Mostrar la tabla de TEstudiante
	SELECT Perfil1 = ET.Perfil, Perfil2 = ET.Perfil, ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre,
		   Estudiante = (ET.APaterno + ' ' + 
						 ET.AMaterno + ', ' + 
						 ET.Nombre),
		   ET.Email, ET.Direccion, ET.Telefono, ET.CodEscuelaP,
		   EscuelaProfesional = EP.Nombre, ET.PersonaReferencia, 
		   --ET.TelefonoReferencia, ET.EstadoFisico, ET.EstadoMental
		   ET.TelefonoReferencia, ET.InformacionPersonal, CodTutor = ET.CodDocente
		FROM ((TTutoria T INNER JOIN TEstudiante ET ON 
			 T.CodEstudiante = ET.CodEstudiante) INNER JOIN 
			 TEscuela_Profesional EP ON ET.CodEscuelaP = EP.CodEscuelaP)
			 INNER JOIN TDocente D ON T.CodDocente = D.CodDocente
		WHERE T.CodDocente = @CodDocente AND ET.CodDocente = @CodDocente
END;
GO

-- Crear un procedimiento para buscar un docente
CREATE PROCEDURE spuBuscarDocente @CodDocente VARCHAR(5)
AS
BEGIN
	-- Mostrar la tabla de TDocente por el texto que se desea buscar
	SELECT Perfil1 = D.Perfil, Perfil2 = D.Perfil, D.CodDocente, D.APaterno, D.AMaterno, D.Nombre, 
		   Docente = (D.APaterno + ' ' + 
					  D.AMaterno + ', ' + 
					  D.Nombre),
		   D.Email, D.Direccion, D.Telefono,
		   D.Categoria, D.Subcategoria, D.Regimen, D.CodEscuelaP,
		   EscuelaProfesional = E.Nombre, D.Horario
		FROM TDocente D INNER JOIN TEscuela_Profesional E ON
			 D.CodEscuelaP = E.CodEscuelaP
		WHERE D.CodDocente = @CodDocente
END;
GO

-- Crear un procedimiento para buscar docentes por cualquier atributo
CREATE PROCEDURE spuBuscarDocentes @CodEscuelaP VARCHAR(4),
								   @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla de TDocente por el texto que se desea buscar
	SELECT Perfil1 = D.Perfil, Perfil2 = D.Perfil, D.CodDocente, D.APaterno, D.AMaterno, D.Nombre, 
		   Docente = (D.APaterno + ' ' + 
					  D.AMaterno + ', ' + 
					  D.Nombre),
		   D.Email, D.Direccion, D.Telefono,
		   D.Categoria, D.Subcategoria, D.Regimen, D.CodEscuelaP,
		   EscuelaProfesional = E.Nombre, D.Horario
		FROM TDocente D INNER JOIN TEscuela_Profesional E ON
			 D.CodEscuelaP = E.CodEscuelaP
		WHERE D.CodEscuelaP = @CodEscuelaP AND
			 (D.CodDocente LIKE (@Texto + '%') OR
			  D.APaterno LIKE (@Texto + '%') OR
			  D.AMaterno LIKE (@Texto + '%') OR
			  D.Nombre LIKE (@Texto + '%') OR
			  D.Email LIKE (@Texto + '%') OR
			  D.Direccion LIKE (@Texto + '%') OR
			  D.Telefono LIKE (@Texto + '%') OR
			  D.Categoria LIKE (@Texto + '%') OR
			  D.Subcategoria LIKE (@Texto + '%') OR
			  D.Regimen LIKE (@Texto + '%') OR
			  E.Nombre LIKE (@Texto + '%') OR
			  D.Horario LIKE (@Texto + '%'))
END;
GO

-- Crear un procedimiento para buscar un tutor
CREATE PROCEDURE spuBuscarTutor @CodEscuelaP VARCHAR(4),
							    @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla de Tutores
	SELECT D.CodDocente, D.APaterno, D.AMaterno, D.Nombre, TotalTutorados = COUNT(TE.CodDocente)
		FROM ((TDocente D INNER JOIN TEscuela_Profesional E ON
			   D.CodEscuelaP = E.CodEscuelaP) LEFT JOIN TEstudiante TE ON
			   D.CodDocente = TE.CodDocente)
		WHERE D.CodEscuelaP = @CodEscuelaP AND D.Subcategoria IN ('PRINCIPAL','ASOCIADO','AUXILIAR','A1','A2','A3') AND D.Regimen IN ('TIEMPO COMPLETO','DEDICACIÓN EXCLUSIVA') AND
		     (D.CodDocente LIKE (@Texto + '%') OR
			  D.APaterno LIKE (@Texto + '%') OR
			  D.AMaterno LIKE (@Texto + '%') OR
			  D.Nombre LIKE (@Texto + '%'))
		GROUP BY D.CodDocente, D.APaterno, D.AMaterno, D.Nombre
END;
GO

-- Crear un procedimiento para buscar estudiantes por cualquier atributo
CREATE PROCEDURE spuBuscarTutorados @CodDocente VARCHAR(5),
									@Texto VARCHAR(20),
									@Filas INT
AS
BEGIN
	-- Mostrar la tabla de TEstudiante por el texto que se desea buscar
	SELECT TOP(@Filas) Perfil1 = ET.Perfil, Perfil2 = ET.Perfil, ET.CodEstudiante, ET.APaterno, ET.AMaterno, ET.Nombre,
		   Estudiante = (ET.APaterno + ' ' + 
						 ET.AMaterno + ', ' + 
						 ET.Nombre),
		   ET.Email, ET.Direccion, ET.Telefono, ET.CodEscuelaP,
		   EscuelaProfesional = EP.Nombre, ET.PersonaReferencia, 
		   --ET.TelefonoReferencia, ET.EstadoFisico, ET.EstadoMental
		   ET.TelefonoReferencia, ET.InformacionPersonal, CodTutor = ET.CodDocente
		FROM TEstudiante ET, TEscuela_Profesional EP
		WHERE ET.CodEscuelaP = EP.CodEscuelaP AND ET.CodDocente = @CodDocente AND
			 (ET.CodEstudiante LIKE (@Texto + '%') OR
			  ET.APaterno LIKE (@Texto + '%') OR
			  ET.AMaterno LIKE (@Texto + '%') OR
			  ET.Nombre LIKE (@Texto + '%') OR
			  ET.Email LIKE (@Texto + '%') OR
			  ET.Direccion LIKE (@Texto + '%') OR
			  ET.Telefono LIKE (@Texto + '%') OR
			  ET.PersonaReferencia LIKE (@Texto + '%') OR
			  ET.TelefonoReferencia LIKE (@Texto + '%') OR
			  --ET.EstadoFisico LIKE (@Texto + '%') OR
			  --ET.EstadoMental LIKE (@Texto + '%')
			  ET.InformacionPersonal LIKE (@Texto + '%'))
END;
GO

-- Crear un procedimiento para insertar un docente
CREATE PROCEDURE spuInsertarDocente @Perfil VARBINARY(MAX),
									@CodDocente VARCHAR(5),
									@APaterno VARCHAR(15),
									@AMaterno VARCHAR(15),
									@Nombre VARCHAR(20),
									@Email VARCHAR(50),
									@Direccion VARCHAR(50),
									@Telefono VARCHAR(15),
									@Categoria VARCHAR(10),
									@Subcategoria VARCHAR(9),
									@Regimen VARCHAR(20),
									@CodEscuelaP VARCHAR(4),
									@Horario VARCHAR(150)
AS
BEGIN
	-- Insertar un docente en la tabla de TDocente
	INSERT INTO TDocente
		VALUES (@Perfil, @CodDocente, @APaterno, @AMaterno, @Nombre, @Email, 
				@Direccion, @Telefono, @Categoria, @Subcategoria, 
				@Regimen, @CodEscuelaP, @Horario)

	-- Insertar un usuario con el c�digo del docente en la tabla de TUsuario
	INSERT INTO TUsuario
		VALUES (@Perfil, @CodDocente, DBO.fnGenerarContraseña(), 'Docente', 
				@APaterno + ' ' + @AMaterno + ', ' + @Nombre)
END;
GO

-- Crear un procedimiento para actualizar un docente
CREATE PROCEDURE spuActualizarDocente @Perfil VARBINARY(MAX),
									  @CodDocente VARCHAR(5),
									  @APaterno VARCHAR(15),
									  @AMaterno VARCHAR(15),
									  @Nombre VARCHAR(20),
									  @Email VARCHAR(50),
									  @Direccion VARCHAR(50),
									  @Telefono VARCHAR(15),
									  @Categoria VARCHAR(10),
									  @Subcategoria VARCHAR(9),
									  @Regimen VARCHAR(20),
									  @CodEscuelaP VARCHAR(4),
									  @Horario VARCHAR(150)					
AS
BEGIN
	-- Actualizar un docente de la tabla de TDocente
	UPDATE TDocente
		SET Perfil = @Perfil, CodDocente = @CodDocente, APaterno = @APaterno, 
			AMaterno = @AMaterno, Nombre = @Nombre, Email = @Email, 
			Direccion = @Direccion, Telefono = @Telefono,
			Categoria = @Categoria, Subcategoria = @Subcategoria, 
			Regimen = @Regimen, CodEscuelaP = @CodEscuelaP, Horario = @Horario
		WHERE CodDocente = @CodDocente

	-- Actualizar un docente de la tabla de TTutoria
	UPDATE TTutoria
		SET CodDocente = @CodDocente
		WHERE CodDocente = @CodDocente

	-- Actualizar un docente de la tabla de TUsuario
	UPDATE TUsuario
		SET Perfil = @Perfil, Usuario = @CodDocente, 
			Datos = @APaterno + ' ' + @AMaterno + ', ' + @Nombre
		WHERE Usuario = @CodDocente
END;
GO

-- Crear un procedimiento para eliminar un docente
CREATE PROCEDURE spuEliminarDocente @CodDocente VARCHAR(5)					
AS
BEGIN
	-- Eliminar un docente de la tabla de TDocente
	DELETE FROM TDocente
		WHERE CodDocente = @CodDocente

	-- Eliminar un usuario relacionado con un estudiante
	DELETE FROM TUsuario
		WHERE Usuario = @CodDocente
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA TUTOR�A ****************** */

-- Crear un procedimiento para mostrar tutor�as
CREATE PROCEDURE spuMostrarTutorias
AS
BEGIN
	-- Mostrar la tabla de TTutoria
	SELECT T.CodTutoria, T.CodDocente, Docente = (D.APaterno + ' ' + 
												  D.AMaterno + ', ' + 
												  D.Nombre),
		   T.CodEstudiante, Estudiante = (E.APaterno + ' ' + 
										  E.AMaterno + ', ' + 
										  E.Nombre)
		FROM (TTutoria T INNER JOIN TDocente D ON
			 T.CodDocente = D.CodDocente) INNER JOIN
			 TEstudiante E ON T.CodEstudiante = E.CodEstudiante
END;
GO

-- Crear un procedimiento para buscar tutor�as por cualquier atributo
CREATE PROCEDURE spuBuscarTutorias @Texto VARCHAR(20)
AS
BEGIN
	-- Mostrar la tabla de TTutoria por el texto que se desea buscar
	SELECT T.CodTutoria, T.CodDocente, Docente = (D.APaterno + ' ' + 
												  D.AMaterno + ', ' + 
												  D.Nombre),
		   T.CodEstudiante, Estudiante = (E.APaterno + ' ' + 
										  E.AMaterno + ', ' + 
										  E.Nombre)
		FROM (TTutoria T INNER JOIN TDocente D ON
			 T.CodDocente = D.CodDocente) INNER JOIN
			 TEstudiante E ON T.CodEstudiante = E.CodEstudiante
		WHERE T.CodTutoria LIKE (@Texto + '%') OR
			  D.APaterno LIKE (@Texto + '%') OR
			  D.AMaterno LIKE (@Texto + '%') OR
			  D.Nombre LIKE (@Texto + '%') OR
			  E.APaterno LIKE (@Texto + '%') OR
			  E.AMaterno LIKE (@Texto + '%') OR
			  E.Nombre LIKE (@Texto + '%')
END;
GO

-- Crear un procedimiento para insertar una tutor�a
CREATE PROCEDURE spuInsertarTutoria @CodTutoria VARCHAR(5) = NULL OUTPUT,
									@CodDocente VARCHAR(5),
									@CodEstudiante VARCHAR(6)
AS
BEGIN
	-- Declarar la clave primar�a de tutor�a
	DECLARE @CodTutoriaGenerado VARCHAR(5);
	SET @CodTutoriaGenerado = DBO.fnGenerarCodTutoria();

	-- Insertar una tutor�a en la tabla de TTutoria
	INSERT INTO TTutoria
		VALUES (@CodTutoriaGenerado, @CodDocente, @CodEstudiante)

	-- Actualizar el valor de CodTutoria
	SET @CodTutoria = @CodTutoriaGenerado;
END;
GO

-- Crear un procedimiento para actualizar una tutor�a
CREATE PROCEDURE spuActualizarTutoria @CodTutoria VARCHAR(5),
									  @CodDocente VARCHAR(5),
									  @CodEstudiante VARCHAR(6)				
AS
BEGIN
	-- Actualizar una tutor�a de la tabla de TTutoria
	UPDATE TTutoria
		SET CodDocente = @CodDocente, CodEstudiante = CodEstudiante
		WHERE CodTutoria = @CodTutoria
END;
GO

-- Crear un procedimiento para eliminar una tutor�a
CREATE PROCEDURE spuEliminarTutoria @CodTutoria VARCHAR(5)					
AS
BEGIN
	-- Eliminar una tutor�a de la tabla de TTutoria
	DELETE FROM TTutoria
		WHERE CodTutoria = @CodTutoria
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA FICHA DE TUTOR�A ****************** */

-- Crear un procedimiento para insertar una tutor�a
CREATE PROCEDURE spuInsertarFichaTutoria @CodTutoria VARCHAR(5),
										 @Fecha DATETIME,
										 @Dimension VARCHAR(15),
										 @Descripcion VARCHAR(100),
										 @Referencia VARCHAR(100),
										 @Observaciones VARCHAR(100)
AS
BEGIN
	-- Insertar una tutor�a en la tabla de TTutoria
	INSERT INTO TFichaTutoria
		VALUES (@CodTutoria, @Fecha, @Dimension, @Descripcion, @Referencia, @Observaciones)
END;
GO

/* ****************** PROCEDIMIENTOS ALMACENADOS PARA LA TABLA USUARIO ****************** */

CREATE PROCEDURE spuIniciarSesion @Usuario VARCHAR(6), @Contraseña VARCHAR(20)
AS
BEGIN
	-- Seleccionar los datos del usuario v�lido
	SELECT *
		FROM TUsuario
		WHERE Usuario = @Usuario AND Contraseña = @Contraseña
END;
GO

-- Crear un procedimiento para actualizar la contrase�a de un usuario
--CREATE PROCEDURE spuActualizarContrase�a @Usuario VARCHAR(7), @Contrase�a VARCHAR(20)				
--AS
--BEGIN
--	-- Actualizar la contrase�a de un usuario de la tabla de TUsuario
--	UPDATE TUsuario
--		SET Contrase�a = @Contrase�a
--		WHERE Usuario = @Usuario
--END;
--GO

/* **************************************************************************************************
   ********************************** TRIGGERS DE LA BASE DE DATOS **********************************
   ************************************************************************************************** */
USE db_a7878d_BDSistemaTutoria
GO

/* *************************** TRIGGERS PARA LA TABLA ESCUELA PROFESIONAL *************************** */

-- Crear un disparador para guardar el registro de inserci�n de la tabla TEscuela_Profesional en la tabla Historial
CREATE TRIGGER trEscuela_ProfesionalInsercion
	ON TEscuela_Profesional
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		CodEscuelaP VARCHAR(4),
		Nombre VARCHAR(40)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el numero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estaran los atributos de la tabla #INSERTED
		DECLARE @CodEscuelaP VARCHAR(4);
		DECLARE @Nombre VARCHAR(40);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodEscuelaP = CodEscuelaP,
			   @Nombre = Nombre
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TEscuela_Profesional','INSERT',@CodEscuelaP,NULL, 
					  @Nombre);
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el numero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de eliminaci�n de la tabla TEscuela_Profesional en la tabla Historial
CREATE TRIGGER trEscuela_ProfesionalEliminacion
	ON TEscuela_Profesional
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		CodEscuelaP VARCHAR(4),
		Nombre VARCHAR(40)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el numero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estaran los atributos de la tabla #DELETED
		DECLARE @CodEscuelaP VARCHAR(4);
		DECLARE @Nombre VARCHAR(40);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodEscuelaP = CodEscuelaP,
			   @Nombre = Nombre
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TEscuela_Profesional','DELETE',@CodEscuelaP, 
					  @Nombre,NULL);
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de actualizaci�n de la tabla TEscuela_Profesional en la tabla Historial
CREATE TRIGGER trEscuela_ProfesionalActualizacion
	ON TEscuela_Profesional
	FOR UPDATE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		CodEscuelaP VARCHAR(4),
		Nombre VARCHAR(40)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		CodEscuelaP VARCHAR(4),
		Nombre VARCHAR(40)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #DELETED = #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED = #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED (ANTES)
		DECLARE @CodEscuelaPAntes VARCHAR(4);
		DECLARE @NombreAntes VARCHAR(40);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodEscuelaPAntes = CodEscuelaP,
			   @NombreAntes = Nombre
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED (DESPU�S)
		DECLARE @CodEscuelaPDespues VARCHAR(4);
		DECLARE @NombreDespues VARCHAR(40);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodEscuelaPDespues = CodEscuelaP,
			   @NombreDespues = Nombre
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Declarar e inicializar el IdRegistroAfectado
		DECLARE @IdRegistroAfectado VARCHAR(20);
		SET @IdRegistroAfectado = NULL

		-- Declarar e inicializar el ValorAnterior
		DECLARE @ValorAnterior VARCHAR(400);
		SET @ValorAnterior = NULL;

		-- Declarar e inicializar el ValorPosterior
		DECLARE @ValorPosterior VARCHAR(400);
		SET @ValorPosterior = NULL;

		-- Verificar si el cambio fue en CodEscuelaP
		IF @CodEscuelaPAntes != @CodEscuelaPDespues
		BEGIN
			SET @ValorAnterior = @CodEscuelaPAntes;
			SET @ValorPosterior = @CodEscuelaPDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEscuela_Profesional','UPDATE',@CodEscuelaPAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Nombre
		IF @NombreAntes != @NombreDespues
		BEGIN
			SET @ValorAnterior = @NombreAntes;
			SET @ValorPosterior = @NombreDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEscuela_Profesional','UPDATE',@CodEscuelaPAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Eliminar las tuplas ya evaluadas de las tablas #DELETED y #INSERTED 
		DELETE TOP (1) FROM #DELETED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

/* *************************** TRIGGERS PARA LA TABLA ESTUDIANTE *************************** */

-- Crear un disparador para guardar el registro de inserci�n de la tabla TEstudiante en la tabla Historial
CREATE TRIGGER trEstudianteInsercion
	ON TEstudiante
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		Perfil VARBINARY(MAX),
		CodEstudiante VARCHAR(6),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		CodEscuelaP VARCHAR(4),
		PersonaReferencia VARCHAR(20),
		TelefonoReferencia VARCHAR(15),
		InformacionPersonal VARCHAR(200),
		--EstadoFisico VARCHAR(40),
		--EstadoMental VARCHAR(40),
		CodDocente VARCHAR(5)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED
		DECLARE @Perfil VARBINARY(MAX);
		DECLARE @CodEstudiante VARCHAR(6);
		DECLARE @APaterno VARCHAR(15);
		DECLARE @AMaterno VARCHAR(15);
		DECLARE @Nombre VARCHAR(20);
		DECLARE @Email VARCHAR(50);
		DECLARE @Direccion VARCHAR(50);
		DECLARE @Telefono VARCHAR(15);
		DECLARE @CodEscuelaP VARCHAR(4);
		DECLARE @PersonaReferencia VARCHAR(20);
		DECLARE @TelefonoReferencia VARCHAR(15);
		DECLARE @InformacionPersonal VARCHAR(200);
		--DECLARE @EstadoFisico VARCHAR(40);
		--DECLARE @EstadoMental VARCHAR(40);
		DECLARE @CodDocente VARCHAR(5);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @Perfil = Perfil,
			   @CodEstudiante = CodEstudiante,
			   @APaterno = APaterno,
			   @AMaterno = AMaterno,
			   @Nombre = Nombre,
			   @Email = Email,
			   @Direccion = Direccion,
			   @Telefono = Telefono,
			   @CodEscuelaP = CodEscuelaP,
			   @PersonaReferencia = PersonaReferencia,
			   @TelefonoReferencia = TelefonoReferencia,
			   @InformacionPersonal = InformacionPersonal,
			   --@EstadoFisico = EstadoFisico,
			   --@EstadoMental = EstadoMental,
			   @CodDocente = CodDocente
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','INSERT',@CodEstudiante,NULL, 
					  CONVERT(VARCHAR(10), @Perfil, 2) + ' ; ' + @APaterno + ' ; ' + @AMaterno + ' ; ' + @Nombre + ' ; ' + 
					  @Email + ' ; ' + @Direccion + ' ; ' + @Telefono + ' ; ' +
					  @CodEscuelaP + ' ; ' + @PersonaReferencia + ' ; ' + 
					  @TelefonoReferencia + ' ; ' + @InformacionPersonal + ' ; ' + @CodDocente); --@EstadoFisico + ' ; ' + @EstadoMental);
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de eliminaci�n de la tabla TEstudiante en la tabla Historial
CREATE TRIGGER trEstudianteEliminacion
	ON TEstudiante
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		Perfil VARBINARY(MAX),
		CodEstudiante VARCHAR(6),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		CodEscuelaP VARCHAR(4),
		PersonaReferencia VARCHAR(20),
		TelefonoReferencia VARCHAR(15),
		InformacionPersonal VARCHAR(200),
		--EstadoFisico VARCHAR(40),
		--EstadoMental VARCHAR(40),
		CodDocente VARCHAR(5)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el n�mero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED
		DECLARE @Perfil VARBINARY(MAX);
		DECLARE @CodEstudiante VARCHAR(6);
		DECLARE @APaterno VARCHAR(15);
		DECLARE @AMaterno VARCHAR(15);
		DECLARE @Nombre VARCHAR(20);
		DECLARE @Email VARCHAR(50);
		DECLARE @Direccion VARCHAR(50);
		DECLARE @Telefono VARCHAR(15);
		DECLARE @CodEscuelaP VARCHAR(4);
		DECLARE @PersonaReferencia VARCHAR(20);
		DECLARE @TelefonoReferencia VARCHAR(15);
		DECLARE @InformacionPersonal VARCHAR(200);
		--DECLARE @EstadoFisico VARCHAR(40);
		--DECLARE @EstadoMental VARCHAR(40);
		DECLARE @CodDocente VARCHAR(5);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @Perfil = Perfil,
			   @CodEstudiante = CodEstudiante,
			   @APaterno = APaterno,
			   @AMaterno = AMaterno,
			   @Nombre = Nombre,
			   @Email = Email,
			   @Direccion = Direccion,
			   @Telefono = Telefono,
			   @CodEscuelaP = CodEscuelaP,
			   @PersonaReferencia = PersonaReferencia,
			   @TelefonoReferencia = TelefonoReferencia,
			   @InformacionPersonal = InformacionPersonal,
			   --@EstadoFisico = EstadoFisico,
			   --@EstadoMental = EstadoMental,
			   @CodDocente = CodDocente
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','DELETE',@CodEstudiante, 
					  CONVERT(VARCHAR(10), @Perfil, 2) + ' ; ' + @APaterno + ' ; ' + @AMaterno + ' ; ' + @Nombre + ' ; ' + 
					  @Email + ' ; ' + @Direccion + ' ; ' + @Telefono + ' ; ' +
					  @CodEscuelaP + ' ; ' + @PersonaReferencia + ' ; ' + 
					  @TelefonoReferencia + ' ; '+ @InformacionPersonal + ' ; ' + @CodDocente, NULL); --@EstadoFisico + ' ; ' + @EstadoMental,NULL);
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de actualizaci�n de la tabla TEstudiante en la tabla Historial
CREATE TRIGGER trEstudianteActualizacion
	ON TEstudiante
	FOR UPDATE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		Perfil VARBINARY(MAX),
		CodEstudiante VARCHAR(6),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		CodEscuelaP VARCHAR(4),
		PersonaReferencia VARCHAR(20),
		TelefonoReferencia VARCHAR(15),
		InformacionPersonal VARCHAR(200),
		--EstadoFisico VARCHAR(40),
		--EstadoMental VARCHAR(40),
		CodDocente VARCHAR(5)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		Perfil VARBINARY(MAX),
		CodEstudiante VARCHAR(6),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		CodEscuelaP VARCHAR(4),
		PersonaReferencia VARCHAR(20),
		TelefonoReferencia VARCHAR(15),
		InformacionPersonal VARCHAR(200),
		--EstadoFisico VARCHAR(40),
		--EstadoMental VARCHAR(40),
		CodDocente VARCHAR(5)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #DELETED = #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED = #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED (ANTES)
		DECLARE @PerfilAntes VARBINARY(MAX);
		DECLARE @CodEstudianteAntes VARCHAR(6);
		DECLARE @APaternoAntes VARCHAR(15);
		DECLARE @AMaternoAntes VARCHAR(15);
		DECLARE @NombreAntes VARCHAR(20);
		DECLARE @EmailAntes VARCHAR(50);
		DECLARE @DireccionAntes VARCHAR(50);
		DECLARE @TelefonoAntes VARCHAR(15);
		DECLARE @CodEscuelaPAntes VARCHAR(4);
		DECLARE @PersonaReferenciaAntes VARCHAR(4);
		DECLARE @TelefonoReferenciaAntes VARCHAR(4);
		DECLARE @InformacionPersonalAntes VARCHAR(200);
		--DECLARE @EstadoFisicoAntes VARCHAR(40);
		--DECLARE @EstadoMentalAntes VARCHAR(40);
		DECLARE @CodDocenteAntes VARCHAR(5);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @PerfilAntes = Perfil,
			   @CodEstudianteAntes = CodEstudiante,
			   @APaternoAntes = APaterno,
			   @AMaternoAntes = AMaterno,
			   @NombreAntes = Nombre,
			   @EmailAntes = Email,
			   @DireccionAntes = Direccion,
			   @TelefonoAntes = Telefono,
			   @CodEscuelaPAntes = CodEscuelaP,
			   @PersonaReferenciaAntes = PersonaReferencia,
			   @TelefonoReferenciaAntes = TelefonoReferencia,
			   @InformacionPersonalAntes = InformacionPersonal,
			   --@EstadoFisicoAntes = EstadoFisico,
			   --@EstadoMentalAntes = EstadoMental,
			   @CodDocenteAntes = CodDocente
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED (DESPU�S)
		DECLARE @PerfilDespues VARBINARY(MAX);
		DECLARE @CodEstudianteDespues VARCHAR(6);
		DECLARE @APaternoDespues VARCHAR(15);
		DECLARE @AMaternoDespues VARCHAR(15);
		DECLARE @NombreDespues VARCHAR(20);
		DECLARE @EmailDespues VARCHAR(50);
		DECLARE @DireccionDespues VARCHAR(50);
		DECLARE @TelefonoDespues VARCHAR(15);
		DECLARE @CodEscuelaPDespues VARCHAR(4);
		DECLARE @PersonaReferenciaDespues VARCHAR(4);
		DECLARE @TelefonoReferenciaDespues VARCHAR(4);
		DECLARE @InformacionPersonalDespues VARCHAR(200);
		--DECLARE @EstadoFisicoDespues VARCHAR(40);
		--DECLARE @EstadoMentalDespues VARCHAR(40);
		DECLARE @CodDocenteDespues VARCHAR(5);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @PerfilDespues = Perfil,
			   @CodEstudianteDespues = CodEstudiante,
			   @APaternoDespues = APaterno,
			   @AMaternoDespues = AMaterno,
			   @NombreDespues = Nombre,
			   @EmailDespues = Email,
			   @DireccionDespues = Direccion,
			   @TelefonoDespues = Telefono,
			   @CodEscuelaPDespues = CodEscuelaP,
			   @PersonaReferenciaDespues = PersonaReferencia,
			   @TelefonoReferenciaDespues = TelefonoReferencia,
			   @InformacionPersonalDespues = InformacionPersonal,
			   --@EstadoFisicoDespues = EstadoFisico,
			   --@EstadoMentalDespues = EstadoMental,
			   @CodDocenteDespues = CodDocente
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Declarar e inicializar el IdRegistroAfectado
		DECLARE @IdRegistroAfectado VARCHAR(20);
		SET @IdRegistroAfectado = NULL

		-- Declarar e inicializar el ValorAnterior
		DECLARE @ValorAnterior VARCHAR(400);
		SET @ValorAnterior = NULL;

		-- Declarar e inicializar el ValorPosterior
		DECLARE @ValorPosterior VARCHAR(400);
		SET @ValorPosterior = NULL;

		-- Verificar si el cambio fue en Perfil
		IF @PerfilAntes != @PerfilDespues
		BEGIN
			SET @ValorAnterior = CONVERT(VARCHAR(10), @PerfilAntes, 2);
			SET @ValorPosterior = CONVERT(VARCHAR(10), @PerfilDespues, 2);

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodEstudiante
		IF @CodEstudianteAntes != @CodEstudianteDespues
		BEGIN
			SET @ValorAnterior = @CodEstudianteAntes;
			SET @ValorPosterior = @CodEstudianteDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en APaterno
		IF @APaternoAntes != @APaternoDespues
		BEGIN
			SET @ValorAnterior = @APaternoAntes;
			SET @ValorPosterior = @APaternoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en AMaterno
		IF @AMaternoAntes != @AMaternoDespues
		BEGIN
			SET @ValorAnterior = @AMaternoAntes;
			SET @ValorPosterior = @AMaternoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Nombre
		IF @NombreAntes != @NombreDespues
		BEGIN
			SET @ValorAnterior = @NombreAntes;
			SET @ValorPosterior = @NombreDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Email
		IF @EmailAntes != @EmailDespues
		BEGIN
			SET @ValorAnterior = @EmailAntes;
			SET @ValorPosterior = @EmailDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Direccion
		IF @DireccionAntes != @DireccionDespues
		BEGIN
			SET @ValorAnterior = @DireccionAntes;
			SET @ValorPosterior = @DireccionDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Telefono
		IF @TelefonoAntes != @TelefonoDespues
		BEGIN
			SET @ValorAnterior = @TelefonoAntes;
			SET @ValorPosterior = @TelefonoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodEscuelaP
		IF @CodEscuelaPAntes != @CodEscuelaPDespues
		BEGIN
			SET @ValorAnterior = @CodEscuelaPAntes;
			SET @ValorPosterior = @CodEscuelaPDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en PersonaReferencia
		IF @PersonaReferenciaAntes != @PersonaReferenciaDespues
		BEGIN
			SET @ValorAnterior = @PersonaReferenciaAntes;
			SET @ValorPosterior = @PersonaReferenciaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en TelefonoReferencia
		IF @TelefonoReferenciaAntes != @TelefonoReferenciaDespues
		BEGIN
			SET @ValorAnterior = @TelefonoReferenciaAntes;
			SET @ValorPosterior = @TelefonoReferenciaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en EstadoFisico
		--IF @EstadoFisicoAntes != @EstadoFisicoDespues
		--BEGIN
		--	SET @ValorAnterior = @EstadoFisicoAntes;
		--	SET @ValorPosterior = @EstadoFisicoDespues;

		--	-- Insertar a la tabla Historial, la tupla con el cambio realizado
		--	INSERT INTO Historial
		--	   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
		--	          @ValorAnterior,@ValorPosterior);

		--	---- Incrementar el IdHistorial en 1
		--	--SET @IdHistorial = @IdHistorial + 1;
		--END;

		-- Verificar si el cambio fue en InformacionPersonal
		--IF @EstadoMentalAntes != @EstadoMentalDespues
		IF @InformacionPersonalAntes != @InformacionPersonalDespues
		BEGIN
			SET @ValorAnterior = @InformacionPersonalAntes; --@EstadoMentalAntes;
			SET @ValorPosterior = @InformacionPersonalDespues; --@EstadoMentalDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodTutor
		IF @CodDocenteAntes != @CodDocenteDespues
		BEGIN
			SET @ValorAnterior = @CodDocenteAntes;
			SET @ValorPosterior = @CodDocenteDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TEstudiante','UPDATE',@CodEstudianteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Eliminar las tuplas ya evaluadas de las tablas #DELETED y #INSERTED 
		DELETE TOP (1) FROM #DELETED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

/* *************************** TRIGGERS PARA LA TABLA DOCENTE *************************** */

-- Crear un disparador para guardar el registro de inserci�n de la tabla TDocente en la tabla Historial
CREATE TRIGGER trDocenteInsercion
	ON TDocente
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		Perfil VARBINARY(MAX),
		CodDocente VARCHAR(5),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		Categoria VARCHAR(10),
		Subcategoria VARCHAR(9),
		Regimen VARCHAR(20),
		CodEscuelaP VARCHAR(4),
		Horario VARCHAR(150)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED
		DECLARE @Perfil VARBINARY(MAX);
		DECLARE @CodDocente VARCHAR(5);
		DECLARE @APaterno VARCHAR(15);
		DECLARE @AMaterno VARCHAR(15);
		DECLARE @Nombre VARCHAR(20);
		DECLARE @Email VARCHAR(50);
		DECLARE @Direccion VARCHAR(50);
		DECLARE @Telefono VARCHAR(15);
		DECLARE @Categoria VARCHAR(10);
		DECLARE @Subcategoria VARCHAR(9);
		DECLARE @Regimen VARCHAR(20);
		DECLARE @CodEscuelaP VARCHAR(4);
		DECLARE @Horario VARCHAR(150);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @Perfil = Perfil,
			   @CodDocente = CodDocente,
			   @APaterno = APaterno,
			   @AMaterno = AMaterno,
			   @Nombre = Nombre,
			   @Email = Email,
			   @Direccion = Direccion,
			   @Telefono = Telefono,
			   @Categoria = Categoria,
			   @Subcategoria = Subcategoria,
			   @Regimen = Regimen,
			   @CodEscuelaP = CodEscuelaP,
			   @Horario = Horario
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','INSERT',@CodDocente,NULL, 
					  CONVERT(VARCHAR(10), @Perfil, 2) + ' ; ' + @APaterno + ' ; ' + @AMaterno + ' ; ' + @Nombre + ' ; ' + 
					  @Email + ' ; ' + @Direccion + ' ; ' + @Telefono + ' ; ' + 
					  @Categoria + ' ; ' + @Subcategoria + ' ; ' + @Regimen + ' ; ' + 
					  @CodEscuelaP + ' ; ' + @Horario);
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de eliminaci�n de la tabla TDocente en la tabla Historial
CREATE TRIGGER trDocenteEliminacion
	ON TDocente
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		Perfil VARBINARY(MAX),
		CodDocente VARCHAR(5),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		Categoria VARCHAR(10),
		Subcategoria VARCHAR(9),
		Regimen VARCHAR(20),
		CodEscuelaP VARCHAR(4),
		Horario VARCHAR(150)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el n�mero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED
		DECLARE @Perfil VARBINARY(MAX);
		DECLARE @CodDocente VARCHAR(5);
		DECLARE @APaterno VARCHAR(15);
		DECLARE @AMaterno VARCHAR(15);
		DECLARE @Nombre VARCHAR(20);
		DECLARE @Email VARCHAR(50);
		DECLARE @Direccion VARCHAR(50);
		DECLARE @Telefono VARCHAR(15);
		DECLARE @Categoria VARCHAR(10);
		DECLARE @Subcategoria VARCHAR(9);
		DECLARE @Regimen VARCHAR(20);
		DECLARE @CodEscuelaP VARCHAR(4);
		DECLARE @Horario VARCHAR(150);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @Perfil = Perfil,
			   @CodDocente = CodDocente,
			   @APaterno = APaterno,
			   @AMaterno = AMaterno,
			   @Nombre = Nombre,
			   @Email = Email,
			   @Direccion = Direccion,
			   @Telefono = Telefono,
			   @Categoria = Categoria,
			   @Subcategoria = Subcategoria,
			   @Regimen = Regimen,
			   @CodEscuelaP = CodEscuelaP,
			   @Horario = Horario
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','DELETE',@CodDocente, 
					  CONVERT(VARCHAR(10), @Perfil, 2) + ' ; ' + @APaterno + ' ; ' + @AMaterno + ' ; ' + @Nombre + ' ; ' + 
					  @Email + ' ; ' + @Direccion + ' ; ' + @Telefono + ' ; ' + 
					  @Categoria + ' ; ' + @Subcategoria + ' ; ' + @Regimen + ' ; ' + 
					  @CodEscuelaP + ' ; ' + @Horario,NULL);
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de actualizaci�n de la tabla TDocente en la tabla Historial
CREATE TRIGGER trDocenteActualizacion
	ON TDocente
	FOR UPDATE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		Perfil VARBINARY(MAX),
		CodDocente VARCHAR(5),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		Categoria VARCHAR(10),
		Subcategoria VARCHAR(9),
		Regimen VARCHAR(20),
		CodEscuelaP VARCHAR(4),
		Horario VARCHAR(150)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		Perfil VARBINARY(MAX),
		CodDocente VARCHAR(5),
		APaterno VARCHAR(15),
		AMaterno VARCHAR(15),
		Nombre VARCHAR(20),
		Email VARCHAR(50),
		Direccion VARCHAR(50),
		Telefono VARCHAR(15),
		Categoria VARCHAR(10),
		Subcategoria VARCHAR(9),
		Regimen VARCHAR(20),
		CodEscuelaP VARCHAR(4),
		Horario VARCHAR(150)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #DELETED = #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED = #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED (ANTES)
		DECLARE @PerfilAntes VARBINARY(MAX);
		DECLARE @CodDocenteAntes VARCHAR(5);
		DECLARE @APaternoAntes VARCHAR(15);
		DECLARE @AMaternoAntes VARCHAR(15);
		DECLARE @NombreAntes VARCHAR(20);
		DECLARE @EmailAntes VARCHAR(50);
		DECLARE @DireccionAntes VARCHAR(50);
		DECLARE @TelefonoAntes VARCHAR(15);
		DECLARE @CategoriaAntes VARCHAR(10);
		DECLARE @SubcategoriaAntes VARCHAR(9);
		DECLARE @RegimenAntes VARCHAR(20);
		DECLARE @CodEscuelaPAntes VARCHAR(4);
		DECLARE @HorarioAntes VARCHAR(150);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @PerfilAntes = Perfil,
			   @CodDocenteAntes = CodDocente,
			   @APaternoAntes = APaterno,
			   @AMaternoAntes = AMaterno,
			   @NombreAntes = Nombre,
			   @EmailAntes = Email,
			   @DireccionAntes = Direccion,
			   @TelefonoAntes = Telefono,
			   @CategoriaAntes = Categoria,
			   @SubcategoriaAntes = Subcategoria,
			   @RegimenAntes = Regimen,
			   @CodEscuelaPAntes = CodEscuelaP,
			   @HorarioAntes = Horario
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED (DESPU�S)
		DECLARE @PerfilDespues VARBINARY(MAX);
		DECLARE @CodDocenteDespues VARCHAR(5);
		DECLARE @APaternoDespues VARCHAR(15);
		DECLARE @AMaternoDespues VARCHAR(15);
		DECLARE @NombreDespues VARCHAR(20);
		DECLARE @EmailDespues VARCHAR(50);
		DECLARE @DireccionDespues VARCHAR(50);
		DECLARE @TelefonoDespues VARCHAR(15);
		DECLARE @CategoriaDespues VARCHAR(10);
		DECLARE @SubcategoriaDespues VARCHAR(9);
		DECLARE @RegimenDespues VARCHAR(20);
		DECLARE @CodEscuelaPDespues VARCHAR(4);
		DECLARE @HorarioDespues VARCHAR(150);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @PerfilDespues = Perfil,
			   @CodDocenteDespues = CodDocente,
			   @APaternoDespues = APaterno,
			   @AMaternoDespues = AMaterno,
			   @NombreDespues = Nombre,
			   @EmailDespues = Email,
			   @DireccionDespues = Direccion,
			   @TelefonoDespues = Telefono,
			   @CategoriaDespues = Categoria,
			   @SubcategoriaDespues = Subcategoria,
			   @RegimenDespues = Regimen,
			   @CodEscuelaPDespues = CodEscuelaP,
			   @HorarioDespues = Horario
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Declarar e inicializar el IdRegistroAfectado
		DECLARE @IdRegistroAfectado VARCHAR(20);
		SET @IdRegistroAfectado = NULL

		-- Declarar e inicializar el ValorAnterior
		DECLARE @ValorAnterior VARCHAR(400);
		SET @ValorAnterior = NULL;

		-- Declarar e inicializar el ValorPosterior
		DECLARE @ValorPosterior VARCHAR(400);
		SET @ValorPosterior = NULL;

		-- Verificar si el cambio fue en Perfil
		IF @PerfilAntes != @PerfilDespues
		BEGIN
			SET @ValorAnterior = CONVERT(VARCHAR(10), @PerfilAntes, 2);
			SET @ValorPosterior = CONVERT(VARCHAR(10), @PerfilDespues, 2);

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodDocente
		IF @CodDocenteAntes != @CodDocenteDespues
		BEGIN
			SET @ValorAnterior = @CodDocenteAntes;
			SET @ValorPosterior = @CodDocenteDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en APaterno
		IF @APaternoAntes != @APaternoDespues
		BEGIN
			SET @ValorAnterior = @APaternoAntes;
			SET @ValorPosterior = @APaternoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en AMaterno
		IF @AMaternoAntes != @AMaternoDespues
		BEGIN
			SET @ValorAnterior = @AMaternoAntes;
			SET @ValorPosterior = @AMaternoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Nombre
		IF @NombreAntes != @NombreDespues
		BEGIN
			SET @ValorAnterior = @NombreAntes;
			SET @ValorPosterior = @NombreDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Email
		IF @EmailAntes != @EmailDespues
		BEGIN
			SET @ValorAnterior = @EmailAntes;
			SET @ValorPosterior = @EmailDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Direccion
		IF @DireccionAntes != @DireccionDespues
		BEGIN
			SET @ValorAnterior = @DireccionAntes;
			SET @ValorPosterior = @DireccionDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Telefono
		IF @TelefonoAntes != @TelefonoDespues
		BEGIN
			SET @ValorAnterior = @TelefonoAntes;
			SET @ValorPosterior = @TelefonoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Categoria
		IF @CategoriaAntes != @CategoriaDespues
		BEGIN
			SET @ValorAnterior = @CategoriaAntes;
			SET @ValorPosterior = @CategoriaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Subcategoria
		IF @SubcategoriaAntes != @SubcategoriaDespues
		BEGIN
			SET @ValorAnterior = @SubcategoriaAntes;
			SET @ValorPosterior = @SubcategoriaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Regimen
		IF @RegimenAntes != @RegimenDespues
		BEGIN
			SET @ValorAnterior = @RegimenAntes;
			SET @ValorPosterior = @RegimenDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodEscuelaP
		IF @CodEscuelaPAntes != @CodEscuelaPDespues
		BEGIN
			SET @ValorAnterior = @CodEscuelaPAntes;
			SET @ValorPosterior = @CodEscuelaPDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Horario
		IF @HorarioAntes != @HorarioDespues
		BEGIN
			SET @ValorAnterior = @HorarioAntes;
			SET @ValorPosterior = @HorarioDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TDocente','UPDATE',@CodDocenteAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Eliminar las tuplas ya evaluadas de las tablas #DELETED y #INSERTED 
		DELETE TOP (1) FROM #DELETED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

/* *************************** TRIGGERS PARA LA TABLA TUTORIA *************************** */

-- Crear un disparador para guardar el registro de inserci�n de la tabla TTutoria en la tabla Historial
CREATE TRIGGER trTutoriaInsercion
	ON TTutoria
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		CodTutoria VARCHAR(5),
		CodDocente VARCHAR(5),
		CodEstudiante VARCHAR(6)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED
		DECLARE @CodTutoria VARCHAR(5);
		DECLARE @CodDocente VARCHAR(5);
		DECLARE @CodEstudiante VARCHAR(6);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoria = CodTutoria,
			   @CodDocente = CodDocente,
			   @CodEstudiante = CodEstudiante
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TTutoria','INSERT',@CodTutoria,NULL, 
					  @CodDocente + ' ; ' + @CodEstudiante);
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de eliminaci�n de la tabla TTutoriae en la tabla Historial
CREATE TRIGGER trTutoriaEliminacion
	ON TTutoria
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		CodTutoria VARCHAR(5),
		CodDocente VARCHAR(5),
		CodEstudiante VARCHAR(6)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el n�mero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED
		DECLARE @CodTutoria VARCHAR(5);
		DECLARE @CodDocente VARCHAR(5);
		DECLARE @CodEstudiante VARCHAR(6);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoria = CodTutoria,
			   @CodDocente = CodDocente,
			   @CodEstudiante = CodEstudiante
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TTutoria','DELETE',@CodTutoria, 
					  @CodDocente + ' ; ' + @CodEstudiante,NULL);
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de actualizaci�n de la tabla TTutoria en la tabla Historial
CREATE TRIGGER trTutoriaActualizacion
	ON TTutoria
	FOR UPDATE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		CodTutoria VARCHAR(5),
		CodDocente VARCHAR(5),
		CodEstudiante VARCHAR(6)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		CodTutoria VARCHAR(5),
		CodDocente VARCHAR(5),
		CodEstudiante VARCHAR(6)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #DELETED = #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED = #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED (ANTES)
		DECLARE @CodTutoriaAntes VARCHAR(5);
		DECLARE @CodDocenteAntes VARCHAR(5);
		DECLARE @CodEstudianteAntes VARCHAR(6);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoriaAntes = CodTutoria,
			   @CodDocenteAntes = CodDocente,
			   @CodEstudianteAntes = CodEstudiante
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED (DESPU�S)
		DECLARE @CodTutoriaDespues VARCHAR(5);
		DECLARE @CodDocenteDespues VARCHAR(5);
		DECLARE @CodEstudianteDespues VARCHAR(6);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoriaDespues = CodTutoria,
			   @CodDocenteDespues = CodDocente,
			   @CodEstudianteDespues = CodEstudiante
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Declarar e inicializar el IdRegistroAfectado
		DECLARE @IdRegistroAfectado VARCHAR(20);
		SET @IdRegistroAfectado = NULL

		-- Declarar e inicializar el ValorAnterior
		DECLARE @ValorAnterior VARCHAR(400);
		SET @ValorAnterior = NULL;

		-- Declarar e inicializar el ValorPosterior
		DECLARE @ValorPosterior VARCHAR(400);
		SET @ValorPosterior = NULL;

		-- Verificar si el cambio fue en CodTutoria
		IF @CodTutoriaAntes != @CodTutoriaDespues
		BEGIN
			SET @ValorAnterior = @CodTutoriaAntes;
			SET @ValorPosterior = @CodTutoriaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodDocente
		IF @CodDocenteAntes != @CodDocenteDespues
		BEGIN
			SET @ValorAnterior = @CodDocenteAntes;
			SET @ValorPosterior = @CodDocenteDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en CodEstudiante
		IF @CodEstudianteAntes != @CodEstudianteDespues
		BEGIN
			SET @ValorAnterior = @CodEstudianteAntes;
			SET @ValorPosterior = @CodEstudianteDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Eliminar las tuplas ya evaluadas de las tablas #DELETED y #INSERTED 
		DELETE TOP (1) FROM #DELETED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

/* *************************** TRIGGERS PARA LA TABLA FICHA DE TUTOR�A *************************** */

-- Crear un disparador para guardar el registro de inserci�n de la tabla TFichaTutoria en la tabla Historial
CREATE TRIGGER trFichaTutoriaInsercion
	ON TFichaTutoria
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		CodTutoria VARCHAR(5),
		Fecha DATETIME,
		Dimension VARCHAR(15),
		Descripcion VARCHAR(100),
		Referencia VARCHAR(100),
		Observaciones VARCHAR(100)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED
		DECLARE @CodTutoria VARCHAR(5);
		DECLARE @Fecha DATETIME;
		DECLARE @Dimension VARCHAR(15);
		DECLARE @Descripcion VARCHAR(100);
		DECLARE @Referencia VARCHAR(100);
		DECLARE @Observaciones VARCHAR(100);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoria = CodTutoria,
			   @Fecha = Fecha,
			   @Dimension = Dimension,
			   @Descripcion = Descripcion,
			   @Referencia = Referencia,
			   @Observaciones = Observaciones
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','INSERT',@CodTutoria,NULL, 
					  CAST(@Fecha AS VARCHAR) + ' ; ' + @Dimension + ' ; ' + @Descripcion + ' ; ' + @Referencia + ' ; ' + @Observaciones);
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de eliminaci�n de la tabla TFichaTutoria en la tabla Historial
CREATE TRIGGER trFichaTutoriaEliminacion
	ON TFichaTutoria
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		CodTutoria VARCHAR(5),
		Fecha DATETIME,
		Dimension VARCHAR(15),
		Descripcion VARCHAR(100),
		Referencia VARCHAR(100),
		Observaciones VARCHAR(100)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el n�mero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED
		DECLARE @CodTutoria VARCHAR(5);
		DECLARE @Fecha DATETIME;
		DECLARE @Dimension VARCHAR(15);
		DECLARE @Descripcion VARCHAR(100);
		DECLARE @Referencia VARCHAR(100);
		DECLARE @Observaciones VARCHAR(100);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoria = CodTutoria,
			   @Fecha = Fecha,
			   @Dimension = Dimension,
			   @Descripcion = Descripcion,
			   @Referencia = Referencia,
			   @Observaciones = Observaciones
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','DELETE',@CodTutoria,
					  CAST(@Fecha AS VARCHAR) + ' ; ' + @Dimension + ' ; ' + @Descripcion + ' ; ' + @Referencia + ' ; ' + @Observaciones,NULL);
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de actualizaci�n de la tabla TFichaTutoria en la tabla Historial
CREATE TRIGGER trFichaTutoriaActualizacion
	ON TFichaTutoria
	FOR UPDATE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		CodTutoria VARCHAR(5),
		Fecha DATETIME,
		Dimension VARCHAR(15),
		Descripcion VARCHAR(100),
		Referencia VARCHAR(100),
		Observaciones VARCHAR(100)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		CodTutoria VARCHAR(5),
		Fecha DATETIME,
		Dimension VARCHAR(15),
		Descripcion VARCHAR(100),
		Referencia VARCHAR(100),
		Observaciones VARCHAR(100)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #DELETED = #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED = #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED (ANTES)
		DECLARE @CodTutoriaAntes VARCHAR(5);
		DECLARE @FechaAntes DATETIME;
		DECLARE @DimensionAntes VARCHAR(15);
		DECLARE @DescripcionAntes VARCHAR(100);
		DECLARE @ReferenciaAntes VARCHAR(100);
		DECLARE @ObservacionesAntes VARCHAR(100);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoriaAntes = CodTutoria,
			   @FechaAntes = Fecha,
			   @DimensionAntes = Dimension,
			   @DescripcionAntes = Descripcion,
			   @ReferenciaAntes = Referencia,
			   @ObservacionesAntes = Observaciones
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED (DESPU�S)
		DECLARE @CodTutoriaDespues VARCHAR(5);
		DECLARE @FechaDespues DATETIME;
		DECLARE @DimensionDespues VARCHAR(15);
		DECLARE @DescripcionDespues VARCHAR(100);
		DECLARE @ReferenciaDespues VARCHAR(100);
		DECLARE @ObservacionesDespues VARCHAR(100);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodTutoriaDespues = CodTutoria,
			   @FechaDespues = Fecha,
			   @DimensionDespues = Dimension,
			   @DescripcionDespues = Descripcion,
			   @ReferenciaDespues = Referencia,
			   @ObservacionesDespues = Observaciones
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Declarar e inicializar el IdRegistroAfectado
		DECLARE @IdRegistroAfectado VARCHAR(20);
		SET @IdRegistroAfectado = NULL

		-- Declarar e inicializar el ValorAnterior
		DECLARE @ValorAnterior VARCHAR(400);
		SET @ValorAnterior = NULL;

		-- Declarar e inicializar el ValorPosterior
		DECLARE @ValorPosterior VARCHAR(400);
		SET @ValorPosterior = NULL;

		-- Verificar si el cambio fue en CodTutoria
		IF @CodTutoriaAntes != @CodTutoriaDespues
		BEGIN
			SET @ValorAnterior = @CodTutoriaAntes;
			SET @ValorPosterior = @CodTutoriaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Fecha
		IF @FechaAntes != @FechaDespues
		BEGIN
			SET @ValorAnterior = CAST(@FechaAntes AS VARCHAR);
			SET @ValorPosterior = CAST(@FechaDespues AS VARCHAR);

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Dimension
		IF @DimensionAntes != @DimensionDespues
		BEGIN
			SET @ValorAnterior = @DimensionAntes;
			SET @ValorPosterior = @DimensionDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Descripcion
		IF @DescripcionAntes != @DescripcionDespues
		BEGIN
			SET @ValorAnterior = @DescripcionAntes;
			SET @ValorPosterior = @DescripcionDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Referencia
		IF @ReferenciaAntes != @ReferenciaDespues
		BEGIN
			SET @ValorAnterior = @ReferenciaAntes;
			SET @ValorPosterior = @ReferenciaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Observaciones
		IF @ObservacionesAntes != @ObservacionesDespues
		BEGIN
			SET @ValorAnterior = @ObservacionesAntes;
			SET @ValorPosterior = @ObservacionesDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TFichaTutoria','UPDATE',@CodTutoriaAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Eliminar las tuplas ya evaluadas de las tablas #DELETED y #INSERTED 
		DELETE TOP (1) FROM #DELETED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

/* *************************** TRIGGERS PARA LA TABLA USUARIO *************************** */

-- Crear un disparador para guardar el registro de inserci�n de la tabla TUsuario en la tabla Historial
CREATE TRIGGER trUsuarioInsercion
	ON TUsuario
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		Perfil VARBINARY(MAX),
		Usuario VARCHAR(6),
		Contraseña VARCHAR(20),
		Acceso VARCHAR(20),
		Datos VARCHAR(53)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED
		DECLARE @Perfil VARBINARY(MAX);
		DECLARE @Usuario VARCHAR(6);
		DECLARE @Contraseña VARCHAR(20);
		DECLARE @Acceso VARCHAR(20);
		DECLARE @Datos VARCHAR(53);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @Perfil = Perfil,
			   @Usuario = Usuario,
			   @Contraseña = Contraseña,
			   @Acceso = Acceso,
			   @Datos = Datos
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','INSERT',@Usuario,NULL, 
					  CONVERT(VARCHAR(10), @Perfil, 2) + ' ; ' + @Contraseña + ' ; ' + @Acceso + ' ; ' + @Datos);
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de eliminaci�n de la tabla TUsuario en la tabla Historial
CREATE TRIGGER trUsuarioEliminacion
	ON TUsuario
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		Perfil VARBINARY(MAX),
		Usuario VARCHAR(6),
		Contraseña VARCHAR(20),
		Acceso VARCHAR(20),
		Datos VARCHAR(53)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el n�mero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED
		DECLARE @Perfil VARBINARY(MAX);
		DECLARE @Usuario VARCHAR(6);
		DECLARE @Contraseña VARCHAR(20);
		DECLARE @Acceso VARCHAR(20);
		DECLARE @Datos VARCHAR(53);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @Perfil = Perfil,
			   @Usuario = Usuario,
			   @Contraseña = Contraseña,
			   @Acceso = Acceso,
			   @Datos = Datos
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','DELETE',@Usuario,
					  CONVERT(VARCHAR(10), @Perfil, 2) + ' ; ' + @Contraseña + ' ; ' + @Acceso + ' ; ' + @Datos,NULL);
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

-- Crear un disparador para guardar el registro de actualizaci�n de la tabla TUsuario en la tabla Historial
CREATE TRIGGER trUsuarioActualizacion
	ON TUsuario
	FOR UPDATE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		Perfil VARBINARY(MAX),
		Usuario VARCHAR(6),
		Contraseña VARCHAR(20),
		Acceso VARCHAR(20),
		Datos VARCHAR(53)
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		Perfil VARBINARY(MAX),
		Usuario VARCHAR(6),
		Contraseña VARCHAR(20),
		Acceso VARCHAR(20),
		Datos VARCHAR(53)
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el n�mero de tuplas de la tabla #DELETED = #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED = #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estar�n los atributos de la tabla #DELETED (ANTES)
		DECLARE @PerfilAntes VARBINARY(MAX);
		DECLARE @UsuarioAntes VARCHAR(6);
		DECLARE @ContraseñaAntes VARCHAR(20);
		DECLARE @AccesoAntes VARCHAR(20);
		DECLARE @DatosAntes VARCHAR(53);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @PerfilAntes = Perfil,
			   @UsuarioAntes = Usuario,
			   @ContraseñaAntes = Contraseña,
			   @AccesoAntes = Acceso,
			   @DatosAntes = Datos
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		-- Declarar variables donde estar�n los atributos de la tabla #INSERTED (DESPU�S)
		DECLARE @PerfilDespues VARBINARY(MAX);
		DECLARE @UsuarioDespues VARCHAR(6);
		DECLARE @ContraseñaDespues VARCHAR(20);
		DECLARE @AccesoDespues VARCHAR(20);
		DECLARE @DatosDespues VARCHAR(53);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @PerfilDespues = Perfil,
			   @UsuarioDespues = Usuario,
			   @ContraseñaDespues = Contraseña,
			   @AccesoDespues = Acceso,
			   @DatosDespues = Datos
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Declarar e inicializar el IdRegistroAfectado
		DECLARE @IdRegistroAfectado VARCHAR(20);
		SET @IdRegistroAfectado = NULL

		-- Declarar e inicializar el ValorAnterior
		DECLARE @ValorAnterior VARCHAR(400);
		SET @ValorAnterior = NULL;

		-- Declarar e inicializar el ValorPosterior
		DECLARE @ValorPosterior VARCHAR(400);
		SET @ValorPosterior = NULL;

		-- Verificar si el cambio fue en Perfil
		IF @PerfilAntes != @PerfilDespues
		BEGIN
			SET @ValorAnterior = CONVERT(VARCHAR(10), @PerfilAntes, 2);
			SET @ValorPosterior = CONVERT(VARCHAR(10), @PerfilDespues, 2);

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','UPDATE',@UsuarioAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Usuario
		IF @UsuarioAntes != @UsuarioDespues
		BEGIN
			SET @ValorAnterior = @UsuarioAntes;
			SET @ValorPosterior = @UsuarioDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','UPDATE',@UsuarioAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Contrase�a
		IF @ContraseñaAntes != @ContraseñaDespues
		BEGIN
			SET @ValorAnterior = @ContraseñaAntes;
			SET @ValorPosterior = @ContraseñaDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','UPDATE',@UsuarioAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Acceso
		IF @AccesoAntes != @AccesoDespues
		BEGIN
			SET @ValorAnterior = @AccesoAntes;
			SET @ValorPosterior = @AccesoDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','UPDATE',@UsuarioAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Verificar si el cambio fue en Datos
		IF @DatosAntes != @DatosDespues
		BEGIN
			SET @ValorAnterior = @DatosAntes;
			SET @ValorPosterior = @DatosDespues;

			-- Insertar a la tabla Historial, la tupla con el cambio realizado
			INSERT INTO Historial
			   VALUES(GETDATE(),'TUsuario','UPDATE',@UsuarioAntes,
			          @ValorAnterior,@ValorPosterior);

			---- Incrementar el IdHistorial en 1
			--SET @IdHistorial = @IdHistorial + 1;
		END;

		-- Eliminar las tuplas ya evaluadas de las tablas #DELETED y #INSERTED 
		DELETE TOP (1) FROM #DELETED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el n�mero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO

/* **************************************************************************************************
   **************************** DML (LENGUAJE DE MANIPULACI�N DE DATOS) *****************************
   ************************************************************************************************** */
USE db_a7878d_BDSistemaTutoria
GO

