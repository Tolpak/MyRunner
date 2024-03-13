using System;
using Zenject;

public class ObstacleSpawner : Spawner
{
    public ObstacleSpawner(Settings settings) : base(settings)
    {
    }
    public class Factory : PlaceholderFactory<ObstacleSpawner>
    {
    }

    [Serializable]
    public class Settings : SpawnerSettings
    {
    }
}
