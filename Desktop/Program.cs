using CrazyToonsEngine;
using CrazyToonsEngine.GameSrc;
using CrazyToonsEngine.src.StateMachine;

BaseGameState startState = new MainMenuState();
using var game = new MainGame(1280, 720, 940, 680, startState);
game.Run();
