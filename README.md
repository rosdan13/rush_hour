# Rush Hour 3D Game

## Overview
Rush Hour 3D is a C# WPF implementation of the classic sliding block puzzle game. The objective is to navigate the red car out of a gridlocked parking lot by strategically moving other vehicles that are in the way. This implementation features a full 3D interface with animated movements, camera controls, and 40 challenging levels.

## Features
- **Interactive 3D Environment**: Fully rendered 3D game environment with detailed vehicles and game board
- **Camera Controls**: Rotate and zoom to get the perfect view of the puzzle
- **40 Puzzle Levels**: Ranging from beginner to expert difficulty
- **Customizable Settings**: Toggle environment details and adjust highlight colors
- **Animated Transitions**: Smooth animations for vehicle movement and UI transitions
- **Level Selection Interface**: Visual grid of all available puzzles with difficulty indicators, featuring dynamically rendered level cards that are built with game logic rather than static images
- **Detailed Instructions**: Built-in "How to Play" guide for new players

## Game Mechanics
- Vehicles can only move horizontally or vertically depending on their orientation
- Vehicles cannot rotate or be lifted off the board
- The objective is to move the red car to the exit on the right side of the board
- The game tracks when you've completed a level successfully

## Controls
- **WASD Keys**: Rotate the camera around the board
- **Mouse Wheel**: Zoom in and out
- **C Key**: Reset camera to default position and angle
- **Mouse Click**: Select vehicles and destination squares
- **UI Navigation**: Interactive menu elements respond to mouse movements

## Technical Details
- Developed in C# using WPF (Windows Presentation Foundation)
- Uses WPF's 3D capabilities for rendering the game environment
- Implements a robust game state management system
- Features a well-organized MVVM-like architecture
- Responsive UI that adapts to different screen resolutions
- Dynamic level card generation system that renders actual vehicle layouts with game logic, not static images

## System Requirements
- Windows operating system
- .NET Framework 4.8
- DirectX 9 or higher (for 3D rendering)
- 2GB RAM recommended
- Mouse and keyboard

## Building the Project

### Prerequisites
- Visual Studio 2019/2022
- .NET Framework 4.8 SDK (included with Visual Studio 2019/2022)

### Build Steps in Visual Studio
1. **Clone or download the repository**
   ```
   git clone https://github.com/rosdan13/rush_hour.git
   ```

2. **Open the project in Visual Studio**
   - Open Visual Studio
   - Select File > Open > Project/Solution
   - Navigate to the project directory 
   - Select the `Rush Hour.csproj` file

3. **Set the build configuration**
   - In the toolbar at the top, ensure the build configuration is set to "Release"
   - Also ensure the platform is set to "x86"
   - Alternatively, you can:
     - Select Build > Configuration Manager
     - Set Active Solution Configuration to "Release"
     - Set Active Solution Platform to "x86"

4. **Build the solution**
   - Select Build > Build Solution (or press F6)
   - The output will be generated in the `bin/Release` directory

5. **Run the application**
   - In Visual Studio, press F5 to run the app
   - Alternatively, navigate to `bin/Release` and run `Rush Hour.exe`

### Project Structure
- **Classes/**: Contains game logic classes
  - `BuildLevel.cs`: Handles level construction
  - `Card.cs`: Dynamic level card visualization that renders actual vehicle layouts with game logic
  - `GameBoard.cs`: Core gameplay logic
  - `Highlighted.cs`: Base class for highlightable objects
  - `Levels.cs`: Level definitions
  - `PageSwitch.cs`: Handles page navigation
  - `ProjectTools.cs`: Utility functions
  - `SceneCamera.cs`: Camera controls
  - `Settings.cs`: Game settings
  - `Square.cs`: Game board squares
  - `Vehicle.cs`: Vehicle implementation
  - `Vehicle2D.cs`: 2D representation of vehicles for cards
- **Pages/**: Contains UI screens
  - `About.xaml`: Information about the game
  - `Gameplay.xaml`: Main game screen
  - `HowToPlay.xaml`: Instructions
  - `LevelSelect.xaml`: Level selection screen
  - `MainMenu.xaml`: Main menu
  - `Options.xaml`: Settings screen
- **Resources/**: Contains images and 3D models
  - `Objects3D.xaml`: 3D object definitions

## Playing the Game
1. **Start the application**
   - On the title screen, click anywhere to proceed to the main menu

2. **From the Main Menu**
   - **Start**: Opens the level selection screen
   - **How To Play**: Shows game instructions
   - **Options**: Configure game settings
   - **About**: Shows information about the game
   - **Exit**: Quits the application

3. **Level Selection**
   - Choose from 40 levels arranged by difficulty
   - Each level card is dynamically rendered using the actual game logic, showing the true starting position of vehicles 
   - Hover over a card to see it enlarge
   - Click a card to start that level

4. **During Gameplay**
   - Click on a vehicle to select it (it will glow)
   - Valid move locations will highlight in blue
   - Click on a highlighted square to move the vehicle there
   - Use WASD to rotate the camera view
   - Use the mouse wheel to zoom in and out
   - Press C to reset the camera
   - The goal is to move the red car to the exit on the right

5. **Options**
   - **Environment**: Toggle 3D environment elements (on/off)
   - **Squares**: Choose highlight color (blue/red)

## Troubleshooting

### Common Build Issues
- **Target Framework Error**: If you receive an error about missing .NET Framework 4.0 assemblies, you need to retarget the project:
  1. Right-click on the project in Solution Explorer
  2. Select "Properties"
  3. Go to the "Application" tab
  4. Change the "Target framework" to ".NET Framework 4.8"
  5. Save and reload the project when prompted

- **Project won't load**: Make sure you're selecting the `Rush Hour.csproj` file when opening
- **Build configuration issues**: Ensure you're using the Release/x86 configuration

### Runtime Issues
- **Game crashes on startup**: Ensure you have DirectX and appropriate video drivers
- **Low frame rate**: Try disabling the environment in Options
- **Controls not responding**: Make sure the game window is in focus
- **Visual artifacts**: Update your graphics drivers

## Game Development Information
This game was developed as a final project in software engineering by Daniel Rosenzweig in 2017. The implementation showcases various programming techniques including 3D rendering, animation, event handling, and object-oriented design principles in a WPF application.

## License
The game was created as an educational project in 2017.
