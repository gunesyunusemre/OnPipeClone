using CornGrain.Mono;
using UnityEngine;

namespace CornGrain.Data
{
    [CreateAssetMenu(menuName = "OnPipe/Corn Grain/Cube Data")]
    public class CornGrainCubeData : AbstractCornGrainData<CornGrainCubeMono>
    {
        public override void Initialize(CornMaker cornMaker)
        {
            var instantiated = InstantiateAndInitializePrefab(cornMaker.transform);
            ThisGameObject = instantiated.gameObject;
            //probs
            //Debug.Log("This class  is  cube data");
        }
    }
}
