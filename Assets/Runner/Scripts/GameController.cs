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
    Spawner obstacleSpawner;
    Spawner collectableSpawner;
    SpawnerFactory spawnerFactory;
    GameStates state = GameStates.Playing;

    public GameController( PlayerController playerChar, SpawnerFactory spawnerFactory )
    {
        this.playerChar = playerChar;
        this.spawnerFactory = spawnerFactory;
        obstacleSpawner = spawnerFactory.CreateSpawner(Spawners.Obstacle);
        collectableSpawner = spawnerFactory.CreateSpawner(Spawners.Collectable);
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
        StartGame();
    }

    public void Tick()
    {
        switch (state)
        {
            case GameStates.Playing:
                {
                    UpdatePlaying();
                    break;
                }
            case GameStates.GameOver:
                {
                    UpdateGameOver();
                    break;
                }
            default:
                {
                    Assert.That(false);
                    break;
                }
        }
    }

    void UpdateGameOver()
    {
        Assert.That(state == GameStates.GameOver);

        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    void UpdatePlaying()
    {
        collectableSpawner.Update();
        obstacleSpawner.Update();
    }

    void OnCharDead()
    {
        state = GameStates.GameOver;
        obstacleSpawner.Disable();
        collectableSpawner.Disable();
    }

    void StartGame()
    {
        playerChar.ChangeState(PlayerStates.Running);
        obstacleSpawner.Start();
        collectableSpawner.Start();
        state = GameStates.Playing;
    }
}
