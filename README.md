# Sistema de Gestión del Centro Deportivo Universitario

## 🎯 Objetivo

Se requiere desarrollar un sistema para la gestión de **eventos deportivos específicos** y las **inscripciones (reservas)** correspondientes dentro de un centro universitario. Este sistema permitirá:

  - Registrar **Personas**, quienes podrán ser participantes en eventos o responsables de la organización de los mismos.
  
  - Definir **Eventos Deportivos concretos**, cada uno con su **fecha**, **hora de inicio**, **duración** y **cupo máximo** de participantes.
  
  - Gestionar las **Reservas** que las personas realizan para participar en dichos eventos, incluyendo un control básico del estado de su asistencia.

El diseño del sistema se fundamentará en los principios de la **Arquitectura Limpia**, priorizando la separación de responsabilidades y el desacoplamiento de componentes mediante el uso del patrón de **Inyección de Dependencia (DI)**. 

Cada una de las entidades principales – **Persona**, **EventoDeportivo** y **Reserva** – será identificable de forma única.

El sistema deberá soportar las operaciones fundamentales de gestión de datos (altas, bajas, modificaciones y listados) a través de **casos de uso** bien definidos.
