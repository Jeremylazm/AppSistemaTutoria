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
