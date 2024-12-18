# BALL-E: A 3D Endless Runner Game
A 3D endless runner featuring clean architecture, modular systems, efficient object pooling, and a Service Locator for a seamless gameplay loop.
---

## PLAY ON: https://yashvardhan1.itch.io/ball-e

---

## Features

- Core Gameplay
    - 3D Endless Runner: Supports touch and keyboard inputs for versatile gameplay on mobile and desktop.
    - Dynamic Gameplay Loop:
        - Scalable spawning system for ground, pickups, and obstacles using advanced object pooling.
        - Flexible probability-based spawning for pickups and obstacles, ensuring varied and engaging runs.
    - Score System: High score tracking based on coins collected, with real-time score updates.
    
- Interactive Features
    - Change Ball Color:
        - Customize the ball’s material via a pop-up menu.
        - Data managed with ScriptableObjects for easy expansion and integration.
    - Scalable Power-Up System:
        - Two power-ups currently available:
            - Double Coins: Doubles the value of collected coins.
            - Half Speed: Temporarily slows gameplay for better control.
    - Built with scalability, allowing designers to add or modify power-ups seamlessly.
    - ScriptableObjects handle attributes like name, active time, and icon, enabling flexibility and stack/reset mechanics.
      
- Audio-Visual Feedback
    - Sound Effects: Integrated sound effects for gameplay actions like collecting coins, activating power-ups, and UI interactions, enhancing immersion.
---
## Patterns Used

1. Object Pooling

    - Manages ground, pickups, and obstacles using an advanced object pooling system to reduce performance overhead and improve resource management.
      
2. Service Locator Pattern

    - A centralized Game Service manages and initializes all essential services:

      - Player Service
      - Ground Service
      - Pickup Service
      - UI Service
      - Sound Service
        
3. MVC (Model-View-Controller)

    - All the features and services are following strict MVC pattern to support scalability and proper seperation of concerns.

      - Model: Manages game data, including player stats, score, power-ups, and ground object data.
      - View: Handles visual elements like the ball's material and UI components (buttons, images, etc.).
      - Controller: Implements the core functionality and business logic, coordinating the interactions between Model and View.
        
4. Observer Pattern

   - Reduces unnecessary coupling between services. For example, when the game restarts, the player’s position is reset, score is cleared, and other relevant game data is updated. Primarily used during game start actions.



---
## SCREENSHOTS

<img src="https://github.com/user-attachments/assets/2215a2c0-c593-4f0c-9bcf-e2ad5f47e10c" alt="Screenshot 1" width="400" height="600" style="margin: 20px;">
&nbsp;&nbsp;&nbsp;&nbsp;
<img src="https://github.com/user-attachments/assets/c63e58d4-7d03-4906-8118-d56204ad5d75" alt="Screenshot 2" width="400" height="600">
<br><br>
<img src="https://github.com/user-attachments/assets/d26b1dc8-7d51-4667-9965-fc9d595efece" alt="Screenshot 3" width="400" height="600" style="margin: 20px;">
&nbsp;&nbsp;&nbsp;&nbsp;
<img src="https://github.com/user-attachments/assets/98d78a4f-dc3f-4a52-a0e9-daac531b81fc" alt="Screenshot 4" width="400" height="600">
