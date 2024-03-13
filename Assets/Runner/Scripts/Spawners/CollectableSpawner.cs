using System;
using Zenject;

public class CollectableSpawner : Spawner
{
    public CollectableSpawner( Settings settings ) : base(settings)
    {
    }

    public class Factory : PlaceholderFactory<CollectableSpawner>
    {
    }

    [Serializable]
    public class Settings : SpawnerSettings
    {
    }
}
