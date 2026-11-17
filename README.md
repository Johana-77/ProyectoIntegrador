# Sistema de Control de Materia Prima y Entregas del Desayuno Escolar de Yachay Chhalaku

**Proyecto Integrador I – Grupo SolAndino**

Universidad Privada Franz Tamayo (UNIFRANZ) – Cochabamba, Bolivia – 2026

## Integrantes

| Nombre completo | Rol |

| Johana Cándida Granado Huarcaya | Coordinación / Líder |
| Mauricio Gabriel Terrazas Gómez | Comunicación con la institución |
| José Antonio Paco Almanza | Diseño / UX |
| Kevin René Vidal Pinto | Documentación / Analista |

## Descripción del proyecto

Yachay Chhalaku es una organización social de Tutimayu (Sacaba, Cochabamba) que forma jóvenes del Bachillerato Técnico Humanístico y entrega néctar de tumbo para el desayuno escolar del municipio de Sacaba.

Hoy la recepción de materia prima y las entregas se registran en cuadernos, hojas de Excel sueltas y facturas, por lo que no se puede verificar si la materia prima fue la adecuada, y la conciliación con el GAMS y los informes se hacen a mano.

Este proyecto propone una **aplicación de escritorio** (C# con Windows Forms y SQL Server) de registro y control de la materia prima y de las entregas del desayuno escolar, que genere indicadores de calidad (porcentaje de lotes conformes, merma en Bs e incidencias por proveedor) para la toma de decisiones.

**Alcance:** solo control de materia prima y entregas. Seguimiento de estudiantes, egresados y emprendimientos queda como fase futura.

## Requerimientos funcionales

| ID | Requerimiento | Prioridad |

| RF01 | Registrar cada lote de materia prima recibido (proveedor, producto, cantidad, fecha de vencimiento). | Alta |
| RF02 | Registrar la inspección de cada lote como conforme, observado o rechazado, con motivo obligatorio si no es conforme. | Alta |
| RF03 | Registrar las entregas del desayuno escolar (fecha, producto, cantidad, unidad educativa). | Alta |
| RF04 | Calcular y mostrar indicadores de calidad: IC(t), merma en Bs e incidencias por proveedor. | Media |
| RF05 | Generar reportes por rango de fechas y exportarlos en Excel o PDF. | Media |
| RF06 | Gestionar usuarios, proveedores y catálogo de materia prima. | Media |
| RF07 | Iniciar sesión, restringir funciones por rol y anular (no eliminar) registros. | Alta |

## Requerimientos no funcionales

| Código | Atributo (ISO/IEC 25010:2023) | Requerimiento |

| RNF-01 | Capacidad de interacción | Interfaz en español, comprensible para personal sin formación técnica (registro de un lote en ≤ 2 min). |
| RNF-02 | Seguridad | Contraseñas con hash seguro con sal (bcrypt o Argon2). |
| RNF-03 | Seguridad | Acceso restringido según el rol; solo el administrador anula registros. |
| RNF-04 | Eficiencia de desempeño | Las pantallas de registro cargan en ≤ 5 s en una PC estándar. |
| RNF-05 | Fiabilidad | Respaldo automático semanal de la base de datos en la nube. |
| RNF-06 | Seguridad (integridad) | Anulación lógica (sin borrado físico) e integridad referencial con claves foráneas. |
| RNF-07 | Seguridad (OWASP) | Seguir OWASP Top 10: validación de entradas, consultas parametrizadas y manejo seguro de sesiones. |
| RNF-08 | Restricción de costo | Herramientas gratuitas: Visual Studio Community y SQL Server Express (licencias Bs 0). |

## Tecnologías

| Capa | Tecnología |
|---|---|
| Lenguaje | C# (.NET) |
| Interfaz | Windows Forms (aplicación de escritorio) |
| Base de datos | SQL Server |
| Entorno de desarrollo | Visual Studio 2026 |
| Control de versiones | Git y GitHub |
| Gestión de tareas | Trello |
| Comunicación / documentos | WhatsApp, Google Drive |

### Cómo hacer correr la aplicación

**Requisitos**
- Windows 10/11
- Visual Studio 2026 con la carga de trabajo **Desarrollo de escritorio de .NET**
- SQL Server y SQL Server Management Studio (SSMS)

**Pasos**

```bash
# 1. Clonar el repositorio
git clone https://github.com/Johana-77/ProyectoIntegrador.git
cd ProyectoIntegrador

# 2. Cambiar a la rama de desarrollo
git checkout develop
```

3. **Crear la base de datos:** *(pendiente)*
4. **Ejecutar la aplicación:** *(en desarrollo)* — se completará cuando esté lista la interfaz en Windows Forms.

### Base de datos

Modelo relacional con 10 entidades: `PROVEEDOR`, `MATERIA_PRIMA`, `LOTE`, `INSPECCION`, `USUARIO`, `REGISTRO_ACCESO`, `PRODUCCION`, `DETALLE_PRODUCCION`, `ENTREGA` y `UNIDAD_EDUCATIVA`. El `LOTE` es la entidad central: cada inspección y entrega se rastrea hasta el lote y el proveedor de origen.

```text
Script de creación: (por definir, ej. /database/schema.sql)
```

### Comandos Git

```bash
git clone <url>                     # clonar el repositorio
git checkout develop                # moverse a la rama develop
git checkout -b feature/<nombre>    # crear una rama de trabajo
git status                          # ver cambios
git add .                           # preparar cambios
git commit -m "mensaje claro"       # guardar cambios
git pull origin develop             # traer cambios del equipo
git push origin feature/<nombre>    # subir la rama
git merge develop                   # integrar develop en la rama actual
```

### Principios SOLID

- **S** – Responsabilidad única: cada clase tiene un solo motivo para cambiar.
- **O** – Abierto/cerrado: abierto a extensión, cerrado a modificación.
- **L** – Sustitución de Liskov: las clases hijas pueden reemplazar a sus clases base.
- **I** – Segregación de interfaces: interfaces pequeñas y específicas.
- **D** – Inversión de dependencias: depender de abstracciones, no de implementaciones concretas.

### Pilares de la POO

- **Abstracción**
- **Encapsulamiento**
- **Herencia**
- **Polimorfismo**

## Rama de trabajo

La rama de desarrollo es **`develop`**.

## Tablero Trello

Tablero: **Proyecto I** – https://trello.com/b/CdyEFrdC
