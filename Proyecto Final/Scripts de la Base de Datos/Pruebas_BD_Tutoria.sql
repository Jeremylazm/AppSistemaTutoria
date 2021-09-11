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

INSERT INTO TEstudiante VALUES('','182940','Prueba','Prueba','Prueba','182940@unsaac.edu.pe','Prueba','923252133','INIS','PAPA','983213211','KAjRXU6RpqupX9zX4uMaQCHwg3GTyGbnW9MX3lWf70AE+u/4qy+7Ke6U0GtXIw/Vr50DSnKPbZwUc9EzFHXKxFqsZk4SFD+xWF6beHbXd21OhqHJKqoRpb4BDKiS+Gr19eGdniLOnaDVZmIqW4IbEaLx/QvKf5QxTwqbOW9OFLY=');