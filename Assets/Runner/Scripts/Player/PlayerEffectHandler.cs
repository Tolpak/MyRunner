using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
// class handles effect expiery
public class PlayerEffectHandler : ITickable
{
    readonly PlayerController playerChar;

    List<Effect> effects;
    List<Effect> effectsToBeRemoved;
    public const float defaultTimeScale = 1;

    public PlayerEffectHandler( PlayerController playerChar )
    {
        this.playerChar = playerChar;
        effects = new List<Effect>();
        effectsToBeRemoved = new List<Effect>();
    }

    public void ApplyEffect(StatusEffectData data)
    {
        AffectSpeed(data.movementEffection);

        Action action = () => { AffectSpeed(-data.movementEffection); };
        if (data.applyFly)
        {
            playerChar.ChangeState(PlayerStates.Fly);
            action = () => {
                playerChar.ChangeState(PlayerStates.Running);
                AffectSpeed(-data.movementEffection); 
            };
        }
        effects.Add(new Effect(data.Duration, action));
    }

    public void Tick()
    {
        foreach (var effect in effects)
        {
            effect.timeLeft -= Time.deltaTime;
            if (effect.timeLeft < 0)
            {
                effect.Action?.Invoke();
                effectsToBeRemoved.Add(effect);
            }
        }
        foreach (var item in effectsToBeRemoved)
        {
            effects.Remove(item);
        }
        effectsToBeRemoved.Clear();
    }

    public void AffectSpeed( float speed )
    {
        Time.timeScale += speed;
    }

    public void Reset()
    {
        effects.Clear();
        Time.timeScale = defaultTimeScale;
    }
}
