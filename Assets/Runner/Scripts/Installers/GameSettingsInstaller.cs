using System;
using UnityEngine;
using Zenject;

    [CreateAssetMenu(menuName = "Enemies/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public RunnerSettings Runner;
        public ObstacleSpawnerSettings Obstacle;

        [Serializable]
        public class RunnerSettings
        {
            public PlayerController.Settings jumpPower;
        }

        [Serializable]
        public class ObstacleSpawnerSettings
        {
            public ObstacleSpawner.Settings Spawner;
        }

        public override void InstallBindings()
        {

            Container.BindInstance(Obstacle.Spawner);
            Container.BindInstance(Runner.jumpPower);
        }
    }


