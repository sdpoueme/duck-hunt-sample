# Duck Hunt Sample

A modern take on the classic Duck Hunt game, implemented in Unity.

## Description

This project is a simple implementation of a Duck Hunt-style game. Players attempt to shoot ducks as they fly across the screen. The game features different types of ducks, each with unique characteristics and point values.

## Features

- Multiple duck types: Normal, Fast, and Golden
- Point system based on duck type
- Ducks escape if not shot within a time limit
- Simple click-to-shoot mechanics
- Utilizes Unity's Universal Render Pipeline (URP) for enhanced graphics

## Key Components

### DuckController.cs

This script manages the behavior of individual ducks in the game.

#### Duck Properties
- `type`: Determines the duck's type (Normal, Golden, or Fast)
- `isAlive`: Tracks if the duck is still active
- `speed`: Controls how fast the duck moves
- `pointsValue`: Defines how many points the duck is worth
- `direction`: Sets the direction of duck movement
- `escapeDuration`: Determines how long a duck stays on screen before escaping

#### Main Functions
- `Initialize`: Sets up duck properties based on its type
- `Update`: Handles duck movement, lifespan, and player interaction
- `OnMouseDown`: Manages what happens when a duck is shot

## How to Use

1. Attach the `DuckController` script to duck prefabs in your Unity project.
2. Implement a spawn system to create ducks in your game scene.
3. Create a UI to display the player's score.
4. Implement game logic to handle scoring and game flow.

## Customization

You can easily customize the game by adjusting the following:
- Duck speeds
- Point values for different duck types
- Escape duration for ducks
- Spawn rates and patterns

## Future Improvements

- Add sound effects for shooting and duck movements
- Implement different backgrounds or levels
- Create a high score system
- Add power-ups or special events

## Contributing

Contributions to improve the game are welcome. Please feel free to fork the repository and submit pull requests.

## License

[Include your chosen license here]