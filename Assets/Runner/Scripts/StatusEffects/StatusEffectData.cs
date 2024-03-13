using UnityEngine;
//Read-only scriptable object class for effects that can affect player 
[CreateAssetMenu(menuName = "StatusEffect")]
public class StatusEffectData : ScriptableObject
{
    [field: SerializeField]
    public float Duration
    {
        get; private set;
    } = 10;

    [field: SerializeField]
    public float movementEffection
    {
        get; private set;
    } = 1;

    [field: SerializeField]
    public bool applyFly
    {
        get; private set;
    }
}
