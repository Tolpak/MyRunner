using System;
using UnityEngine;
using Zenject;

//[CreateAssetMenu(menuName = "Settings/Game Settings")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public RunnerSettings Runner;
    public SpawnerSettings Spawner;
    public PlayerSettings Player;

    [Serializable]
    public class RunnerSettings
    {
        public PlayerController.Settings settings;
    }

    [Serializable]
    public class PlayerSettings
    {
        public PlayerRunningState.Settings RunningState;
        public PlayerDeadState.Settings DeadState;
        public PlayerFlyingState.Settings FlyingState;
    }

    [Serializable]
    public class SpawnerSettings
    {
        public ObstacleSpawner.Settings Obstacles;
        public CollectableSpawner.Settings Collectables;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(Spawner.Obstacles);
        Container.BindInstance(Spawner.Collectables);
        Container.BindInstance(Runner.settings);
        Container.BindInstance(Player.RunningState);
        Container.BindInstance(Player.DeadState);
        Container.BindInstance(Player.FlyingState);
    }
}


