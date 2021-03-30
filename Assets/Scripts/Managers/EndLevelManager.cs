using Finisher;
using Managers.Initializer;
using Ring;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(menuName = "OnPipe/Manager/End Level Manager")]
    public class EndLevelManager : ScriptableManagerInitializer<EndLevelManager>
    {
        [SerializeField] private RingData _ringData;
        [SerializeField] private FinisherData _finisherData;
        
        public override void Initialize()
        {
            base.Initialize();
            //Debug.Log("Scriptable End Level Manager activated");
        }

        public override void Destroy()
        {
            base.Destroy();
            //Debug.Log("Scriptable End Level Manager deactivated");
        }

        public void ControlEndGame(Transform target)
        {
            if (_ringData.CollectableCount>=_finisherData.TargetCollectableCount)
            {
                var instantiated=Instantiate(_finisherData.Finisher);
                instantiated.transform.position = target.position;
                //Debug.Log("Instantiated finisher");
            }
        }
    }
}
