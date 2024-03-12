using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDeadState : PlayerState
{
    public override void Update()
    {

    }

    public class Factory : PlaceholderFactory<PlayerDeadState>
    {
    }
}
