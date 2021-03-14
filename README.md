# CubeGame

## Unity Version : 2019.4.12F1

### Unity Executable build placed in Builds Folder.

## Controls
- W, A, S, D - move cube in directions. 
- Esc - Toggle Cube Select Mode
- M - Toggle Goku Mode - select all cubes

## Dry Run:
- The game open up with a simple UI scene with 2 options - Play and Exit 
- Play : Opens a new scene, 4 cubes colored Black, Blue, Yellow, Green spawn on the map and falls on the floor. At this point, the cursor should be visible 
- Use the cursor to select a cube
- On selection, the selected cube should turn red, cursor is invisible. The cube can now be controlled using directional keys
- The cube follows physics and once it falls off the floor, it respawns at its original posistion after 7 seconds
- Toggle back to cube select mode by pressing the respective key, the cursor should now be visible again, allowing the player to select the new cube
- Use the Goku Mode to select all cubes that can be controlled using the directional keys simoultaneously
- Toogle Goku mode key bind to switch back to normal mode
- There is simple UI that takes care of the number of respawns and a simple button to go back to Menu
- Exit: Quits the game
