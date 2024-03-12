using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Zenject.Asteroids;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] Transform feet;
    [SerializeField] private Animator animator;

    private bool isGrounded;
    private Settings settings;
    public UnityEvent Dead;

    PlayerStateFactory stateFactory;
    PlayerState state;

    [Inject]
    public void Construct( Settings settings )
    {
        this.settings = settings;
    }

    void FixedUpdate()
    {
        state.FixedUpdate();
    }

    private void Update()
    {
        state.Update();
    }


    private void OnTriggerEnter2D( Collider2D collision )
    {
        OnDead();
    }

    public void OnDead()
    {
        animator.SetTrigger("Dead");
        Dead.Invoke();
    }

    public void ResetAnimation()
    {
        animator.ResetTrigger("Dead");
    }

    [Serializable]
    public class Settings
    {
        public float JumpPower;
    }

    public void ChangeState( PlayerStates state )
    {
        if (this.state != null)
        {
            this.state.Dispose();
            this.state = null;
        }

        this.state = stateFactory.CreateState(state);
        this.state.Start();
    }
}
