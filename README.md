# Project Information

### Unity Version: 2023.1.14f1

To reduce the project size, the "Bee" folder has been removed.

## Key Implementation Points:

### Dependency Injection:
The Zenject framework was used.

### State Management:
The State pattern was applied to control the states of the circle.
The Command pattern was used to handle the command queue.
Simplified versions of these patterns were used, including only the necessary functionality to complete the test assignment.

### Event System:
An event system was implemented to manage game events.

### Click Handling:
To avoid manually processing clicks in each frame via Update(), UniRx was used in the InputHandler class.

## Key Classes in the Project:
- `GamePlaySceneInstaller`
- `CircleController`
- `InputHandler`

## Time to Complete:
- Unity project implementation: ~8 hours.
- Video creation: 10 minutes.
- Writing the README file: 30 minutes.
- Compiling and uploading files to Google Drive: ~1 hour.

**Total time to complete: 9 hours 40 minutes.**
