USE BDSistema_Tutoria
GO

INSERT INTO TEscuela_Profesional VALUES('INIS','INGENIERÍA INFORMÁTICA Y DE SISTEMAS');
INSERT INTO TEscuela_Profesional VALUES('INEO','INGENIERÍA ELECTRÓNICA');
INSERT INTO TEscuela_Profesional VALUES('INCV','INGENIERÍA CIVIL');
INSERT INTO TEscuela_Profesional VALUES('CONT','CONTABILIDAD');
INSERT INTO TEscuela_Profesional VALUES('PSIC','PSICOLOGÍA');
INSERT INTO TEscuela_Profesional VALUES('INQM','INGENIERÍA QUÍMICA');
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
insert into TEstudiante values(convert(varbinary(max), ''), '12345', 'AP', 'AM', 'N', 'E', 'D', 'T', 'INIS', 'PR', 'TR', 'IP')
insert into TUsuario values (convert(varbinary(max), ''), '12345', '12345', 'Estudiante', '12345')
select * from TUsuario


INSERT INTO TUsuario (Usuario, Contraseña, Acceso, Datos, Perfil) 
SELECT 'ADMIN', 'ADMIN1234', 'Director de Escuela', 'ADMINISTRADOR', BulkColumn
	FROM Openrowset(Bulk 'C:\Users\Jeremylazm\Desktop\Documentos\Copia de Proyecto de DS I\Proyecto Final\AppSistemaTutoria\CapaPresentaciones\Iconos\Perfil.png', Single_Blob) as PerfilAdmin
GO

select * from TEstudiante

