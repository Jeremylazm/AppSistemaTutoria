# **<center> Aplicación de Escritorio con un Sistema de Tutorías para la UNSAAC </center>**

## Creado por estudiantes de la Universidad Nacional de San Antonio Abad del Cusco

### Datos Académicos 📖

- **:** Universidad Nacional de San Antonio Abad del Cusco
- **Facultad:** Facultad de Ingeniería Eléctrica, Electrónica, Informática y Mecánica
- **Escuela Prof:** Ingeniería Informática y de Sistemas

#### Docente:

- **Roxana Quintanilla Portugal** - _Docente_ - [Concytec](http://directorio.concytec.gob.pe/appDirectorioCTI/VerDatosInvestigador.do;jsessionid=a64a00668b861c4a52fdead99791?id_investigador=40930).

#### Trabajo:

- Realizar un Sistemas de Tutorías para la Universidad Nacional de San Antonio Abad del Cusco.

## Descripción
- El Sistema de Tutorías es un programa para facilitar la organización y distribución de docentes tutores en la Universidad Nacional de San Antonio Abad del Cusco.

#### Autores:✒️

- **Castillo Lopez Ricardo Jorge** - _Estudiante_ - [RicardoJorge](https://github.com/rjcastillolopez)
- **Cuyo Ttito Denis Omar** - _Estudiante_ - [DenisOmar](https://github.com/denisomarcuyottito)
- **Estrella Vilca James Kevin** - _Estudiante_ - [JamesKevin](https://github.com/JamesKevinStar)
- **Huaman Mendoza Elvis Jorge** - _Estudiante_ - [ElvisJorge](https://github.com/ElvisJorge17)
- **Huaman Mendoza Johan Wilfredo** - _Estudiante_ - [JohanWilfredo](https://github.com/jhn-cde)
- **Lazo Mendoza Jeremy Axl** - _Estudiante_ - [JeremyAxl](https://github.com/Jeremylazm)
- **Peña Luque Raisa Melina** - _Estudiante_ - [RaisaMelina](https://github.com/Raisa18)
- **Usucachi Ano Isac Anderson** - _Estudiante_ - [IsacAnderson](https://github.com/isacanderson)
- **Villasante León Amaru** - _Estudiante_ - [Amaru](https://github.com/AmaruVL)
---

## Empezamos... 🚀

# APLICACIÓN DE ESCRITORIO PARA UN SISTEMA DE TUTORÍAS DE LA UNSAAC.
Este proyecto desarrolla un sistema de tutorías para una universidad.
El sistema realizado fue diseñado con el fin de tratar de facilitar el proceso de las tutorías que se lleva a cabo en la UNSAAC actualmente, no obstante el objetivo que se persigue es que los procesos se realicen en forma más rápida y precisa.
Para lograr este objetivo hemos organizado los formularios al que puede acceder cada usuario, de tal manera que se facilite la utilización del sistema y que los datos que se proporcionen al mismo estén seguros.
Para la realización de este sistema se decidió que se tuvieron 3 tipos de usuario con privilegios y roles particulares:
* Director de Escuela
* Tutor
* Estudiante

Inicialmente el sistema contiene una pantalla de inicio que es para el Inicio de sesión de cualquier usuario, adicionalmente se tiene una opción para recuperar la contraseña de un usuario.
Cada usuario definido tiene una serie de funcionalidades particulares que tienen como finalidad, todos unidos, lograr el propósito del sistema y lograr el objetivo esperado.

# MODELO RELACIONAL DE LA BASE DE DATOS.
![Base de datos](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/BaseDatos.jpeg)

# IMPLEMENTACIÓN DEL SISTEMA.
## ACTORES:
* DOCENTE: 

Este actor interactúa con el actor estudiante a través de las tutorías. Si cumple con los requisitos para ser tutor, las acciones que puede realizar es buscar, agregar, modificar y eliminar fichas de tutoría además de ver la relación de tutorados correspondientes.
* DIRECTOR DE ESCUELA: 

Este actor tiene las mismas características que el actor docente y además de las realizar las mismas acciones, tiene privilegios para administrar el sistema de tutorías y realizar operaciones de buscar, agregar, modificar y eliminar usuarios. Otras acciones incluyen la asignación de tutorados a los docentes que cumplen con los requisitos para ser tutores y ver un informe sobre las tutorías realizadas bajo diferentes criterios.
* ESTUDIANTE: 

Este actor interactúa con el actor docente que es tutora través de las tutorías. Puede solicitar tutorías.

# INTERFACES
## Formularios para todos los usuarios
* Form Inicio Sesión:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormsTodosUsuarios/InicioSesion.png)
* Form Recuperar Contraseña:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormsTodosUsuarios/RecuperarContraseña.png)
* Form Bienvenida:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormsTodosUsuarios/Bienvenida.png)
* Form Cambiar Contraseña:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormsTodosUsuarios/CambiarContraseña.png)
![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormsTodosUsuarios/CambiarContraseña2.png)
![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormsTodosUsuarios/CambiarContraseña3.png)

## Formularios en común para los usuarios Director de Escuela y Docente
* Form Editar Perfil Docente:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirectorDocente/EditarPerfilDocente.png)

* Form Tabla Tutorías:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirectorDocente/TablaTutorias.png)

* Form Ficha de Tutoría:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirectorDocente/FichaTutoria.png)

* Form Tabla Tutorados:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirectorDocente/Tutorados.png)

## Formularios exclusivos para usuario Director de Escuela:
* Form Tabla Docentes:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirector/TablaDocentes.png)
* Form Datos Docente (Agregar, Modificar):

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirector/DatosDocente.png)
* Form Tabla Tutores:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirector/TablaTutores.png)
* Form Tabla Estudiantes:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirector/TablaEstudiantes.png)
* Form Datos Estudiante (Agregar, Modificar):

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormDirector/DatosEstudiante.png)

## Formularios exclusivos para usuario Estudiante:
* Form Editar Perfil Estudiante:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormEstudiante/EditarPerfil.png)
* Form Información Tutor:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormEstudiante/InformacionTutor.png)
* Form Solicitar Cita:

![](https://raw.githubusercontent.com/Jeremylazm/AppSistemaTutoria/main/Screenshots/FormEstudiante/SolicitarCita.png)



