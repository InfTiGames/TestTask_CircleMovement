using UnityEngine;

namespace Assets.TestTask_CircleMovement.Scripts
{
    [CreateAssetMenu(fileName = "CircleSettings", menuName = "Settings/Circle")]
    public class CircleSettings : ScriptableObject
    {
        [field: SerializeField, Range(0, 20)] public float DefaultMoveSpeed { get; private set; } = 5f;
    }
}