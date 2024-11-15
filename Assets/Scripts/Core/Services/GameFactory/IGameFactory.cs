﻿using Game;
using Game.Camera;
using Game.Levels;
using Game.Player;
using Game.UI;

namespace Core.Services.GameFactory
{
    public interface IGameFactory
    {
        MainGameField CreateMainGameField();
        Level CreateLevel(int levelIndex);
        PlayerController CreatePlayer();
        CameraFollow CreateCamera();
        GameUI CreateGameUI();
    }
}