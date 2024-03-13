using Zenject;
using System;
using UnityEngine;

public class PlayerRunningState : PlayerState
{
    readonly Settings settings;
    readonly PlayerController player;
    public PlayerRunningState( Settings settings, PlayerController playerController )
    {
        this.settings = settings;
        player = playerController;
    }
    public override void Start()
    {
        player.SetAnimationDead(false);
    }

    public override void Update()
    {
        player.CheckForJump();
    }

    public override void FixedUpdate()
    {
        player.IsGrounded();
    }

    public override void OnTriggerEnter( Collider2D other )
    {
        player.OnDead();
    }

    [Serializable]
    public class Settings
    {
    }

    public class Factory : PlaceholderFactory<PlayerRunningState>
    {
    }
}
