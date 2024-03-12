using ModestTree;

public enum PlayerStates
{
    Running,
    Dead,
    Fly
}

public class PlayerStateFactory
{
    readonly PlayerFlyingState.Factory flyingFactory;
    readonly PlayerRunningState.Factory runningFactory;
    readonly PlayerDeadState.Factory deadFactory;

    public PlayerStateFactory(
        PlayerDeadState.Factory deadFactory,
        PlayerRunningState.Factory runningFactory,
        PlayerFlyingState.Factory flyingFactory )
    {
        this.flyingFactory = flyingFactory;
        this.runningFactory = runningFactory;
        this.deadFactory = deadFactory;
    }

    public PlayerState CreateState( PlayerStates state )
    {
        switch (state)
        {
            case PlayerStates.Dead:
                {
                    return deadFactory.Create();
                }
            case PlayerStates.Fly:
                {
                    return flyingFactory.Create();
                }
            case PlayerStates.Running:
                {
                    return runningFactory.Create();
                }
        }

        throw Assert.CreateException();
    }
}

