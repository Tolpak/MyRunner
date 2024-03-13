using UnityEngine;
//Class for objects that interact with a player
public class Collectable : MonoBehaviour
{
    [SerializeField] private StatusEffectData effectData;

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (collision.gameObject.TryGetComponent(out IEffectable effectable))
        {
            effectable.ApplyEffect(effectData);
            Destroy(gameObject);
        }
    }
}
