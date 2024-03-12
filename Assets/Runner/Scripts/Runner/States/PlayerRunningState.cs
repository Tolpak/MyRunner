using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.Asteroids;
using Zenject;

public class PlayerRunningState : PlayerState
{
    public override void Update()
    {

    }

    public class Factory : PlaceholderFactory<PlayerRunningState>
    {
    }
}
