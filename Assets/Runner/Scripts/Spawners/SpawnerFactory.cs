using ModestTree;

public enum Spawners
{
    Obstacle,
    Collectable,
}

public class SpawnerFactory
{
    readonly ObstacleSpawner.Factory obstacleFactory;
    readonly CollectableSpawner.Factory collectableFactory;

    public SpawnerFactory(
        ObstacleSpawner.Factory obstacleFactory,
        CollectableSpawner.Factory collectableFactory
        )
    {
        this.collectableFactory = collectableFactory;
        this.obstacleFactory = obstacleFactory;
    }

    public Spawner CreateSpawner( Spawners spawner )
    {
        switch (spawner)
        {
            case Spawners.Obstacle:
                return obstacleFactory.Create();
            case Spawners.Collectable:
                return collectableFactory.Create();
        }
        throw Assert.CreateException();
    }
}
