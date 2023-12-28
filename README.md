# RegistroVisitantes
Este proyecto es una aplicación web desarrollada en ASP.NET para gestionar el registro de visitantes y su historial de ingreso y salida.
## Funcionalidades Principales

1. **Registro de Visitantes:**
   - Captura del nombre del visitante.
   - Selección del trabajador que se visita mediante un desplegable.

2. **Registro de Historial:**
   - Almacena la información de ingreso y salida de cada visitante.
   - Utiliza una base de datos SQL Server para almacenar la información.

## Requisitos del Sistema

- ASP.NET
- SQL Server
- ODBC Driver para SQL Server

## Configuración del Proyecto

1. **Base de Datos:**
   - Ejecutar el script SQL proporcionado (`Registro.sql`) para crear las tablas necesarias (`visitante`, `trabajador`, `historial`).

2. **Configuración de la Conexión a la Base de Datos:**
   - Modificar la cadena de conexión en la clase `ConexionBD` según las configuraciones específicas de tu entorno.

## Uso del Proyecto

1. **Ejecución:**
   - Compilar y ejecutar el proyecto en un entorno que admita ASP.NET.

2. **Acceso:**
   - Acceder a la página de registro (`Menu.aspx`) desde un navegador web.

3. **Menú:**
   - Hacer clic en el botón de "Ingreso" para acceder a la página de ingreso (`Ingreso.aspx`).
   - Hacer clic en el botón de "Egreso" para acceder a la página de egreso (`Egreso.aspx`).

4. **Registro de Visitantes:**
   - Ingresar el nombre del visitante.
   - Seleccionar el trabajador que se visita.
   - Hacer clic en el botón "Registrar".

5. **Registro de Salida:**
   - Ingresar el nombre del visitante.
   - Hacer clic en el botón "Registrar".

## Contribuciones

Si encuentras problemas o tienes sugerencias para mejorar el proyecto, no dudes en abrir un problema o enviar una solicitud de extracción.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para obtener más detalles.
