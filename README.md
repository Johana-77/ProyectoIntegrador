# Huertos Sumaj Pacha - Sistema de seguimiento de huertos familiares

Aplicación de escritorio hecha en **C# (.NET 10 / Windows Forms)** con base de datos **SQL Server**, para la ONG **Yachay Chhalaku**. Sirve para registrar a las familias del proyecto Sumaj Pacha (Melga, Sacaba), sus parcelas, las entregas de plantines y abono y las visitas técnicas. Con eso el sistema calcula la supervivencia de las plantas y avisa cuando una parcela está en riesgo.

**Proyecto Integrador I - Grupo SolAndino**
Universidad Privada Franz Tamayo (UNIFRANZ) - Cochabamba, 2026

## Integrantes

| Nombre | Rol |
| :--- | :--- |
| Johana Cándida Granado Huarcaya | Coordinación / Líder |
| Mauricio Gabriel Terrazas Gómez | Comunicación con la institución |
| José Antonio Paco Almanza | Diseño / UX |
| Kevin René Vidal Pinto | Documentación / Analista |

## Funcionalidades

1. **Inicio de sesión y roles**
   - Usuario, contraseña y rol. Después de 3 intentos fallidos el sistema se cierra.
   - Roles: **Administrador** (todo), **Técnico** (registros y reportes) y **Consulta** (solo inicio y reportes).

2. **Familias y parcelas**
   - Búsqueda de familias y registro de parcelas (huerto familiar o sistema agroforestal).

3. **Entregas de insumos**
   - Registro de plantines (por unidad) y abono (en kg) para cada parcela.
   - Las entregas no se borran, solo el administrador las puede anular.

4. **Visitas técnicas**
   - Se registran las plantas vivas y los kg cosechados de cada cultivo.
   - Supervivencia = plantas vivas / plantines entregados x 100.
   - Si baja del 81% sale alerta media y si baja del 72% alerta alta.

5. **Panel principal**
   - Indicadores generales, alertas de supervivencia y próximas visitas (cada 15 días).

6. **Reportes**
   - Filtros por comunidad, sexo, edad y periodo. Se pueden exportar a Excel (CSV) y a PDF.

7. **Administración**
   - Usuarios (nuevo, editar, activar o desactivar), catálogo de cultivos y registros anulados.

## Estructura del proyecto

- `SumajPacha/Modelos/`: clases del sistema (`Usuario`, `Familia`, `Parcela`, `Cultivo`, `Insumo`, `Entrega`, `Visita`, `ResumenCultivo`).
- `SumajPacha/Datos/`: conexión a SQL Server (`Conexion`) y consultas a las tablas (`Datos`).
- `SumajPacha/Negocio/`: cálculos de supervivencia y alertas (`Calculos`), sesión del usuario (`Sesion`) y contraseñas (`Seguridad`).
- `SumajPacha/Formularios/`: pantallas (`FrmLogin`, `FrmPrincipal`, `FrmFamilias`, `FrmEntregas`, `FrmVisitas`, `FrmReportes`, `FrmAdministracion`, `FrmUsuario`).
- `database/`: scripts de la base de datos y el diagrama (`sumajpacha.dbml`, se abre en [dbdiagram.io](https://dbdiagram.io)).

## Cómo hacerlo funcionar

### 1. Crear la base de datos

En **SQL Server Management Studio** abrir y ejecutar (F5) los scripts de la carpeta `database` en este orden:

1. `01_crear_tablas.sql`: crea la base `SumajPachaDB` con sus 11 tablas.
2. `02_insertar_datos.sql`: carga las familias, parcelas, entregas, visitas y usuarios.

El `03_consultas.sql` tiene las consultas de los reportes y no hace falta para que el sistema funcione.

### 2. Revisar el nombre del servidor

En `SumajPacha/Datos/Conexion.cs` está el nombre del servidor:

```csharp
public const string SERVIDOR = @".\SQLEXPRESS";
```

Si en su computadora el servidor tiene otro nombre (por ejemplo `.\SQLEXPRESS02` o `localhost\SQLEXPRESS`), hay que cambiarlo ahí.

### 3. Ejecutar

Abrir `SumajPacha.sln` en Visual Studio y presionar **F5**.

## Usuarios

La base trae una cuenta inicial por cada rol. La contraseña de las tres es `1234`. En el login también se elige el rol.

| Usuario | Rol |
| :--- | :--- |
| `admin` | Administrador |
| `tecnico` | Técnico |
| `consulta` | Consulta |

Solo el administrador puede crear cuentas, desde **Administración → Usuarios**. La idea es que cada trabajador de la ONG tenga su propia cuenta, así cada registro queda a nombre de quien lo hizo. Al instalar el sistema hay que cambiar la contraseña de `admin`.

Los datos de las familias que trae la base son ficticios, para proteger la información personal de las familias. Los datos reales se cargarán con la información que entregue la ONG.

## Requisitos

- Windows 10 u 11.
- Visual Studio con la carga de trabajo **Desarrollo de escritorio de .NET**.
- SQL Server Express y SQL Server Management Studio.
- Paquete NuGet `Microsoft.Data.SqlClient` (Visual Studio lo descarga solo la primera vez que se compila).

## Organización del equipo

- Rama de trabajo: `develop`.
- Tablero de tareas en Trello: https://trello.com/b/CdyEFrdC
