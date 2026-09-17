# Prototipo 3 — Party multijugador local

## Minijuego
Cuatro jugadores comparten la misma pantalla.
Durante 60 segundos deben recoger tantas monedas como sea posible.

## Controles
- P1: WASD
- P2: flechas
- P3: IJKL
- P4: teclado numérico 4/6/2/8
- Espacio: empezar
- R: repetir ronda

## Instalación
Copia `Assets/DEIM_PartyLocal` dentro de `Assets`.
Después usa:
`DEIM > Create Party Local Prototype Scene`

## Objetivo docente
El input por teclado está hecho deliberadamente de forma sencilla para que el prototipo
funcione sin paquetes adicionales. Una evolución natural es instalar el **Input System**
y sustituir el sistema por `PlayerInput` + `PlayerInputManager` para usar gamepads.

## Trabajo para el alumnado
1. Pantalla de incorporación de jugadores.
2. Input System y mandos.
3. Selección de personaje.
4. Tres minijuegos diferentes.
5. Temporizador y transición entre rondas.
6. Puntuación acumulada.
7. Power-ups.
8. Cámara, partículas, sonido y game feel.
9. Tablero tipo party entre minijuegos.
10. Como ampliación avanzada: red local LAN con Netcode for GameObjects.
