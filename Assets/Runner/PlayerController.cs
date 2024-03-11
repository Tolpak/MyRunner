using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float jump;
    [SerializeField] Transform feet;
    [SerializeField] private Animator animator;
    private bool isGrounded;

    void FixedUpdate()
    {
        var groundRaycast = Physics2D.Raycast(feet.position, -Vector2.up, 0);
        isGrounded = groundRaycast.collider != null;
        animator.SetBool("IsJumping", !isGrounded);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rigidBody.velocity = Vector2.up * jump;
        }
    }
}
