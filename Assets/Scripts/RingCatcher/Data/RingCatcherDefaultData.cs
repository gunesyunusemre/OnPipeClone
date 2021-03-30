using RingCatcher.Mono;
using UnityEngine;

namespace RingCatcher.Data
{
    [CreateAssetMenu(menuName = "OnPipe/Catcher/Default Catcher Data")]
    public class RingCatcherDefaultData : AbstractScriptableRingCatcherData<RingCatcherDefaultMono>
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
