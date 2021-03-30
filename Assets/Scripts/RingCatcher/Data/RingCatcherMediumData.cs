using RingCatcher.Mono;
using UnityEngine;

namespace RingCatcher.Data
{
    [CreateAssetMenu(menuName = "OnPipe/Catcher/Medium Catcher Data")]
    public class RingCatcherMediumData : AbstractScriptableRingCatcherData<RingCatcherMediumMono>
    {
        public override void Initialize(RingCatcherSpawnManager _ringCatcherSpawner)
        {
            var instantiated = InstantiateAndInitializePrefab(_ringCatcherSpawner.parent.transform);
            ThisGameObject = instantiated.gameObject;
            //probs
            //Debug.Log("This class  is  default ringCatcher data");
        }
    }
}
