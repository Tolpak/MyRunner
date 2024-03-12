using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerFlyingState : PlayerState
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        animator.SetBool("IsJumping", !isGrounded);

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rigidBody.velocity = Vector2.up * settings.JumpPower;
        }
    }
    public class Factory : PlaceholderFactory<PlayerFlyingState>
    {
    }
}
