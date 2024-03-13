using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

// Main Player class where player state is stored and can be changed
public class PlayerController : MonoBehaviour,IEffectable
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] Transform feet;
    [SerializeField] private Animator animator;

    [Serializable]
    public class Settings
    {
        public float JumpPower;
    }

    private bool isGrounded;
    private Settings settings;
    private PlayerState state;
    private PlayerStateFactory stateFactory;
    private PlayerEffectHandler effectHandler;
    private const string AnimationDeadKey = "Dead";
    private const string AnimationJumpKey = "IsJumping";

    public UnityEvent Dead;

    [Inject]
    public void Construct( Settings settings, PlayerStateFactory stateFactory, PlayerEffectHandler playerEffectTimer )
    {
        this.settings = settings;
        this.stateFactory = stateFactory;
        effectHandler = playerEffectTimer;
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
        state.OnTriggerEnter( collision );
    }

    public void CheckForJump()
    {

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rigidBody.velocity = Vector2.up * settings.JumpPower;
        }
        animator.SetBool(AnimationJumpKey, !isGrounded);
    }

    public void SetJumpAnimation( bool state )
    {
        animator.SetBool(AnimationJumpKey, state);
    }

    public void OnDead()
    {
        SetAnimationDead(true);
        effectHandler.Reset();
        Dead.Invoke();
    }

    public void SetAnimationDead(bool state)
    {
        if (state)
        {
            animator.SetTrigger(AnimationDeadKey);
        }
        else
        {
            animator.ResetTrigger(AnimationDeadKey);
        }
    }



    public void IsGrounded()
    {
        var raycast = Physics2D.Raycast(feet.position, Vector2.down, 0);
        isGrounded = raycast.collider != null;
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
        Debug.Log(state.ToString());
    }

    public void ApplyEffect( StatusEffectData statusEffectData )
    {
        effectHandler.ApplyEffect(statusEffectData);
    }
}
