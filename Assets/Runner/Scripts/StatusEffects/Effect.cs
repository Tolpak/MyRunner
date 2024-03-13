using System;

public class Effect
{
    public float timeLeft;
    public Action Action;
    public Effect( float timeLeft, Action action )
    {
        this.timeLeft = timeLeft;
        this.Action = action;
    }
}
