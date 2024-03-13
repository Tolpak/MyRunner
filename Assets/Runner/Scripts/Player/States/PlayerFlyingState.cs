using System;
using UnityEngine;
using Zenject;
//Player state for flying
public class PlayerFlyingState : PlayerState
{
    readonly Settings settings;
    readonly PlayerController player;
    private Rigidbody2D rigidbody;
    public PlayerFlyingState( Settings settings, PlayerController playerController )
    {
        this.settings = settings;
        player = playerController;
    }
    public override void Start()
    {
        player.SetJumpAnimation(true);
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        if (player.transform.position.y < settings.flyingHeight)
        {
            // moving Player to required height
            player.transform.Translate(Vector3.up * Time.deltaTime * settings.flightSpeed);
            rigidbody.MovePosition(player.transform.position + Vector3.up);
        }
    }

    [Serializable]
    public class Settings
    {
        public float flyingHeight;
        public float flightSpeed;

    }

    public class Factory : PlaceholderFactory<PlayerFlyingState>
    {
    }
}
