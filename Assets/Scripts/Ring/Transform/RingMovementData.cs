using UnityEngine;

namespace Ring.Transform
{
    [CreateAssetMenu(menuName = "OnPipe/Ring/Movement Data")]
    public class RingMovementData : ScriptableObject
    {
        [Range(0,5)][SerializeField] private float _value;

        public float Value => _value;
    }
}
