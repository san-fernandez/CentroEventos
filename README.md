Sistema de Gestión del Centro Deportivo Universitario 🏅
🎯 Objetivo

Este sistema tiene como propósito la gestión integral de eventos deportivos y las inscripciones dentro de un centro universitario. A través de este sistema, se podrá:

    Registrar personas: Personas que pueden ser tanto participantes de eventos como responsables de su organización.

    Definir eventos deportivos: Cada evento incluirá detalles como fecha, hora de inicio, duración y el cupo máximo de participantes.

    Gestionar reservas: Las personas podrán realizar reservas para participar en los eventos, con un control básico del estado de su asistencia.

🛠 Diseño y Arquitectura

El sistema está diseñado siguiendo los principios de Arquitectura Limpia, enfocándose en:

    Separación de responsabilidades.

    Desacoplamiento de componentes.

Esto se logra mediante el uso del patrón de Inyección de Dependencias (DI), garantizando un código modular, fácil de mantener y extender.
🌐 Entidades Principales

Las entidades claves dentro del sistema son:

    Persona: Representa a los usuarios, ya sean participantes u organizadores.

    Evento Deportivo: Define los detalles específicos de los eventos.

    Reserva: Gestiona la inscripción de las personas a los eventos.

Cada una de estas entidades estará identificada de forma única, lo que permitirá una gestión eficiente y precisa de los datos.
🔄 Operaciones Principales

El sistema soporta las operaciones esenciales de gestión de datos, incluyendo:

    Altas: Registro de nuevas personas, eventos y reservas.

    Bajas: Eliminación de personas, eventos o reservas.

    Modificaciones: Actualización de los datos existentes.

    Listados: Consulta de las personas, eventos y reservas disponibles.
