USE BDSistema_Tutoria
GO

INSERT INTO TEscuela_Profesional VALUES('INIS','INGENIERÍA INFORMÁTICA Y DE SISTEMAS');
INSERT INTO TEscuela_Profesional VALUES('INEO','INGENIERÍA ELECTRÓNICA');
INSERT INTO TEscuela_Profesional VALUES('INCV','INGENIERÍA CIVIL');
INSERT INTO TEscuela_Profesional VALUES('CONT','CONTABILIDAD');
INSERT INTO TEscuela_Profesional VALUES('PSIC','PSICOLOGÍA');
INSERT INTO TEscuela_Profesional VALUES('INQM','INGENIERÍA QUÍMICA');
GO

INSERT INTO TUsuario (Usuario, Contraseña, Acceso, Datos, Perfil) 
SELECT 'ADMIN', 'ADMIN1234', 'Director de Escuela', 'ADMINISTRADOR', BulkColumn 
	FROM Openrowset(Bulk 'C:\Users\Jeremylazm\Desktop\Documentos\Copia de Proyecto de DS I\Proyecto Final\AppSistemaTutoria\CapaPresentaciones\Iconos\Perfil.png', Single_Blob) as PerfilAdmin
GO

SELECT * FROM TEscuela_Profesional
SELECT * FROM TEstudiante
SELECT * FROM TDocente
SELECT * FROM TUsuario
SELECT * FROM TTutoria
SELECT * FROM Historial
GO
