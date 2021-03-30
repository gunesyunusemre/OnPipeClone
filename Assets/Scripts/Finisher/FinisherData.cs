using UnityEngine;

namespace Finisher
{
    [CreateAssetMenu(menuName = "OnPipe/Finisher")]
    public class FinisherData : ScriptableObject
    {
        [SerializeField] private int _targetCollectableCount;
        [SerializeField] private GameObject _finisher;

        public GameObject Finisher => _finisher;
        public int TargetCollectableCount => _targetCollectableCount;
    }
}
