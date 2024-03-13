using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
//Class for dead state
public class PlayerDeadState : PlayerState
{
    public override void Update()
    {

    }

    [Serializable]
    public class Settings
    {
    }

    public class Factory : PlaceholderFactory<PlayerDeadState>
    {
    }
}
