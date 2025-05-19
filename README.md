# 🏟️ Sistema de Gestión de Eventos Deportivos

Este proyecto fue desarrollado como parte del seminario de .NET en la facultad. Se trata de una aplicación de consola que permite la gestión de **personas**, **eventos deportivos** y **reservas**. El sistema permite dar de alta, baja, modificar y listar información relacionada, todo a través de un menú interactivo por consola.

---

## 📌 Descripción del Proyecto

El sistema está dividido en tres módulos principales:

1. **Personas**  
   - Alta de personas  
   - Baja de personas  
   - Modificación de datos  
   - Listado de todas las personas registradas

2. **Eventos Deportivos**  
   - Alta de eventos deportivos  
   - Baja de eventos deportivos  
   - Modificación de eventos  
   - Listado de eventos  
   - Listado de eventos con cupo disponible  
   - Listado de asistentes a un evento específico

3. **Reservas**  
   - Alta de reserva  
   - Baja de reserva  
   - Modificación de reserva  
   - Listado de reservas

Cada funcionalidad está acompañada por una interfaz clara y amigable por consola, con validaciones adecuadas y mensajes informativos.

---

## ▶️ Cómo Ejecutar el Proyecto

### 1. Requisitos Previos

Antes de ejecutar la aplicación, asegurate de tener instalado lo siguiente:

- ✅ [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/en-us/download)
- ✅ [Visual Studio 2022 o superior](https://visualstudio.microsoft.com/es/) con el componente de desarrollo para .NET

### 2. Clonar o Descargar el Proyecto

#### Opción A - Clonación

```bash
git clone https://github.com/san-fernandez/CentroEventos.git
cd CentroEventos
```

#### Opción B - Descarga del ZIP

1. Hacé clic en el botón verde **"Code"** en este repositorio y seleccioná **"Download ZIP"**.
2. Extraé el archivo ZIP en una carpeta local de tu preferencia.
3. Abrí la carpeta extraída. Deberías ver los archivos del proyecto, incluyendo el archivo `.csproj` principal y la carpeta `screenshots`.

---

### 3. Abrir y Ejecutar el Proyecto

1. Abrí **Visual Studio**.
2. Seleccioná **"Abrir un proyecto o solución"** y buscá el archivo `program.cs` dentro de la carpeta del proyecto.
3. Para ejecutar la aplicación, presioná `Ctrl + F5` o hacé clic en el botón **"Iniciar sin depurar"** en la barra superior.
4. Se abrirá una consola con el menú principal del sistema.

> 📌 Si estás usando otra IDE o la terminal, también podés ejecutar el proyecto desde la línea de comandos:
> ```bash
> dotnet run
> ```

## 💡 Cómo Usar el Sistema

Una vez iniciado el programa, se mostrará el siguiente menú principal:


### 🧭 Menú Principal

![Menú Principal](./Screenshots consola/menu_principal.png)

---

## 👤 Gestión de Personas

### 📋 Menú de Personas

![Menú Personas](./screenshots/menu_personas.png)

#### ➕ Alta de Persona

![Alta Persona](./screenshots/alta_persona.png)

#### ➖ Baja de Persona

![Baja Persona](./screenshots/baja_persona.png)

#### ✏️ Modificación de Persona

![Modificación Persona](./screenshots/modificacion_persona.png)

#### 📄 Listado de Personas

![Listado Personas](./screenshots/listado_personas.png)

---

## 🏆 Gestión de Eventos Deportivos

### 📋 Menú de Eventos

![Menú Eventos](./screenshots/menu_eventos.png)

#### ➕ Alta de Evento Deportivo

![Alta Evento](./screenshots/alta_evento.png)

#### ➖ Baja de Evento Deportivo

![Baja Evento](./screenshots/baja_evento.png)

#### ✏️ Modificación de Evento Deportivo
  
![Modificación Evento](./screenshots/modificacion_evento.png)

#### 📄 Listado de Eventos Deportivos

![Listado Eventos](./screenshots/listado_eventos.png)

#### ✅ Listado de Eventos con Cupo Disponible

![Eventos con Cupo](./screenshots/eventos_con_cupo.png)

#### 👥 Listado de Asistentes a un Evento
  
![Asistentes Evento](./screenshots/asistentes_evento.png)

---

## 📅 Gestión de Reservas

### 📋 Menú de Reservas

[]  
![Menú Reservas](./screenshots/menu_reservas.png)

#### ➕ Alta de Reserva

[]  
![Alta Reserva](./screenshots/alta_reserva.png)

#### ➖ Baja de Reserva

[]  
![Baja Reserva](./screenshots/baja_reserva.png)

#### ✏️ Modificación de Reserva

[]  
![Modificación Reserva](./screenshots/modificacion_reserva.png)

#### 📄 Listado de Reservas

[]  
![Listado Reservas](./screenshots/listado_reservas.png)

---

## 🧑‍🤝‍🧑 Integrantes del Proyecto

| Nombre y Apellido     | Legajo     | Rol en el Proyecto      |
|-----------------------|------------|--------------------------|
| [Nombre Apellido]     | [12345]    | Desarrollo y documentación |
| [Nombre Apellido]     | [67890]    | Desarrollo y testing       |
| [Nombre Apellido]     | [13579]    | Modelado y diseño          |


## 🏫 Contexto Académico

Este proyecto fue desarrollado como parte del Seminario de .NET en la Facultad de Informática de la UNLP, con el objetivo de aplicar conceptos de programación orientada a objetos y arquitectura limpia.

Agradecemos a la cátedra por la guía durante el desarrollo.
