USE db_a7878d_BDSistemaTutoria
GO

INSERT INTO TEscuela_Profesional VALUES('INIS','INGENIER�A INFORM�TICA Y DE SISTEMAS');
INSERT INTO TEscuela_Profesional VALUES('INEO','INGENIER�A ELECTR�NICA');
INSERT INTO TEscuela_Profesional VALUES('INCV','INGENIER�A CIVIL');
INSERT INTO TEscuela_Profesional VALUES('CONT','CONTABILIDAD');
INSERT INTO TEscuela_Profesional VALUES('PSIC','PSICOLOG�A');
INSERT INTO TEscuela_Profesional VALUES('INQM','INGENIER�A QU�MICA');
GO

--UPDATE TEscuela_Profesional SET CodEscuelaP = 'IPOL' WHERE CodEscuelaP = 'INEO'

--DELETE FROM TEscuela_Profesional
--DELETE FROM TEstudiante

--INSERT INTO TTutoria VALUES('T0001', '18291', '123456');
--INSERT INTO TTutoria VALUES('T0002', '09099', '182916');
--INSERT INTO TTutoria VALUES('T0003', '09099', '123456');

UPDATE TUsuario SET Acceso = 'Director de Escuela' WHERE Usuario = '182916'

SELECT * FROM TEscuela_Profesional
SELECT * FROM TEstudiante
SELECT * FROM TDocente
SELECT * FROM TUsuario
SELECT * FROM TTutoria
SELECT * FROM Historial

insert into TUsuario values (convert(varbinary(max), ''), '182906', '182906', 'Director de Escuela', '123')

select * from TUsuario


INSERT INTO TUsuario (Usuario, Contrase�a, Acceso, Datos, Perfil) 
SELECT 'ADMIN', 'ADMIN1234', 'Director de Escuela', 'ADMINISTRADOR', BulkColumn
	FROM Openrowset(Bulk 'C:\Users\Jeremylazm\Documents\GitHub\AppSistemaTutoria\Proyecto Final\AppSistemaTutoria\CapaPresentaciones\Iconos\Perfil.png', Single_Blob) as PerfilAdmin
GO

select * from TEstudiante