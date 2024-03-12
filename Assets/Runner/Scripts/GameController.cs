using System;
using ModestTree;
using UnityEngine;
using Zenject;

public enum GameStates
{
    Playing,
    GameOver
}

public class GameController : IInitializable, ITickable, IDisposable
{
    readonly PlayerController playerChar;
    readonly ObstacleSpawner obstacleSpawner;

    GameStates state = GameStates.Playing;

    public GameController( PlayerController playerChar, ObstacleSpawner obstacleSpawner )
    {
        this.playerChar = playerChar;
        this.obstacleSpawner = obstacleSpawner;
    }

    public GameStates State
    {
        get { return state; }
    }

    public void Dispose()
    {
        playerChar.Dead.RemoveAllListeners();
    }

    public void Initialize()
    {
        playerChar.Dead.AddListener(delegate {
            OnCharDead();
        });
        
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0) && state == GameStates.GameOver)
        {
            StartGame();
        }
    }

    void OnCharDead()
    {
        state = GameStates.GameOver;
        obstacleSpawner.ResetAll();
    }

    void StartGame()
    {
        playerChar.ResetAnimation();
        obstacleSpawner.Start();
        state = GameStates.Playing;
    }
}
