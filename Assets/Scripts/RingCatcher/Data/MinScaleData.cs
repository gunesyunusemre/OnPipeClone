using UnityEngine;

namespace RingCatcher.Data
{
    [CreateAssetMenu(menuName = "OnPipe/Catcher/Minimum Scale Data")]
    public class MinScaleData : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value
        {
            get => value;
            set => this.value = value;
        }
    }
}
