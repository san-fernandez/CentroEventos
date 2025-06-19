# 🏋️ Sistema de Gestión de un Centro Deportivo

Este proyecto fue desarrollado como parte del seminario de .NET de la Facultad de Informática de la UNLP. Se trata de una aplicación web desarrollada con **Blazor Server**, que permite la gestión integral de un centro deportivo, incluyendo la administración de **personas**, **eventos**, **reservas** y **usuarios**, con sistema de autenticación y roles.

---

## 📌 Descripción del Proyecto

El sistema está dividido en los siguientes módulos:

### 👤 Personas
- Crear persona
- Editar datos personales
- Listado de personas (con opciones de edición y eliminación)
- Eliminar persona

### 🏆 Eventos Deportivos
- Crear evento deportivo
- Editar evento
- Listado de eventos (con opciones de edición y eliminación)
- Eliminar evento

### 📅 Reservas
- Crear reserva
- Editar reserva
- Listado de reservas (con edición y eliminación)
- Eliminar reserva

### 🔐 Gestión de Usuarios
- Crear usuario
- Editar usuario
- Listado de usuarios (con edición y eliminación)
- Eliminar usuario

### 🛡️ Administración de Permisos (solo para usuarios administradores)
- Dar y quitar permisos a usuarios del sistema

---

## 🚪 Inicio de Sesión y Registro

En la pantalla de inicio, se presentan dos opciones:

- **Iniciar sesión**: los usuarios registrados pueden ingresar al sistema con su correo y contraseña.
- **Registrarse**: permite crear una nueva cuenta de usuario.

Una vez autenticado, el usuario accede al sistema según sus permisos.

---

## ⚙️ Funciones Adicionales

- ✏️ **Editar Perfil**: cada usuario puede modificar su información personal desde su sección de perfil.
- 🔒 **Roles y permisos**: el administrador puede definir qué usuarios tienen acceso a funcionalidades administrativas.
- ✅ Validaciones y mensajes interactivos para guiar al usuario.

---

## ▶️ Cómo Ejecutar el Proyecto

### 1. Requisitos Previos

- ✅ [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/en-us/download)
- ✅ [Visual Studio 2022 o superior](https://visualstudio.microsoft.com/es/) con soporte para desarrollo web con Blazor

### 2. Clonar o Descargar el Proyecto

```bash
git clone https://github.com/san-fernandez/CentroEventos.git
cd CentroEventos
```
O bien, descargar el archivo ZIP desde GitHub y extraerlo en una carpeta local:

1. Hacé clic en el botón verde **"Code"** y seleccioná **"Download ZIP"**.
2. Extraé el archivo ZIP en una carpeta local de tu preferencia.
3. Abrí la carpeta extraída. Deberías ver los archivos del proyecto, incluyendo la solución `.sln` y los proyectos organizados en carpetas (`CentroEventos.UI`, `CentroEventos.Aplicacion`, etc.).

---

### 3. Abrir y Ejecutar

1. Abrí **Visual Studio**.
2. Seleccioná **"Abrir un proyecto o solución"** y abrí el archivo `CentroEventos.sln`.
3. Establecé el proyecto `CentroEventos.UI` como proyecto de inicio.
4. Ejecutá el sistema con `Ctrl + F5` o haciendo clic en **"Iniciar sin depurar"**.
5. Se abrirá el navegador con la pantalla de inicio del sistema (login y registro).

---

## 💡 Cómo Navegar el Sistema


### 🔐 Pantalla de Inicio

- Login y Registro de nuevos usuarios

![Login](./Screenshots/Pantalla_Login.png)
![Registro](./Screenshots/Pantalla_Registro.png)

---

### 🧭 Menú Principal

- Una vez iniciado, el usuario será dirigido al menú principal. Según los permisos asignados, podrá acceder a las siguientes secciones:

![Menú Principal](./Screenshots/Menu_Principal.png)

---

### 👤 Gestión de Personas

#### 📋 Listado de Personas

![Listado Personas](./Screenshots/Personas_Listado.png)

#### ➕ Crear Persona

![Alta Persona](./Screenshots/Personas_Alta.png)

#### ✏️ Editar Persona

![Editar Persona](./Screenshots/Personas_Edicion.png)

#### 🗑️ Eliminar Persona

![Eliminar Persona](./Screenshots/Personas_Eliminar.png)

---

### 🏆 Gestión de Eventos

#### 📋 Listado de Eventos

![Listado Eventos](./Screenshots/Eventos_Listado.png)

#### ➕ Crear Evento

![Alta Evento](./Screenshots/Eventos_Alta.png)

#### ✏️ Editar Evento

![Editar Evento](./Screenshots/Eventos_Edicion.png)

#### 🗑️ Eliminar Evento

![Eliminar Evento](./Screenshots/Eventos_Eliminar.png)

---

### 📅 Gestión de Reservas

#### 📋 Listado de Reservas

![Listado Reservas](./Screenshots/Reservas_Listado.png)

#### ➕ Crear Reserva

![Alta Reserva](./Screenshots/Reservas_Alta.png)

#### ✏️ Editar Reserva

![Editar Reserva](./Screenshots/Reservas_Edicion.png)

#### 🗑️ Eliminar Reserva

![Eliminar Reserva](./Screenshots/Reservas_Eliminar.png)

---

### 👥 Gestión de Usuarios

#### 📋 Listado de Usuarios

![Listado Usuarios](./Screenshots/Usuarios_Listado.png)

#### ➕ Crear Usuario

![Alta Usuario](./Screenshots/Usuarios_Alta.png)

#### ✏️ Editar Usuario

![Editar Usuario](./Screenshots/Usuarios_Edicion.png)

#### 🗑️ Eliminar Usuario

![Eliminar Usuario](./Screenshots/Usuarios_Eliminar.png)

---

### 🛡️ Panel de Administración

- Permite dar y quitar permisos a los usuarios

![Administrar Permisos](./Screenshots/Admin_Permisos.png)

---

### ✏️ Edición de Perfil

- Disponible para todos los usuarios

![Editar Perfil](./Screenshots/Perfil_Edicion.png)

---

## 🧑‍🤝‍🧑 Integrantes del Proyecto

| Nombre y Apellido     | Legajo     | Rol en el Proyecto         |
|-----------------------|------------|----------------------------|
| Santiago Fernández    | 25595/7    | Desarrollo y documentación |
| Ezequiel Prieto       | 25953/9    | Desarrollo y testing       |
| Ignacio Fernández     | 27150/8    | Modelado y diseño          |

---

## 🏫 Contexto Académico

Este proyecto fue desarrollado como parte del **Seminario de .NET** de la **Facultad de Informática de la UNLP**, con el objetivo de aplicar conocimientos avanzados en:

- Programación orientada a objetos
- Desarrollo fullstack con **Blazor Server**
- Inyección de dependencias
- Arquitectura limpia
- Seguridad y control de acceso por roles

Agradecemos a la cátedra por su acompañamiento y guía durante todo el proceso de desarrollo.
