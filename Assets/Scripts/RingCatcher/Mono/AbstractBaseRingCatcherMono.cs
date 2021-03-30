using System.Collections;
using RingCatcher.Data;
using UnityEngine;

namespace RingCatcher.Mono
{
    public class AbstractBaseRingCatcherMono : MonoBehaviour, IRingCatcher
    {
        [SerializeField] protected MinScaleData _minScaleData;
        public MinScaleData MinScaleData => _minScaleData;
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }
        
        private void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeRingCatcher();
        }

        private void OnDestroy()
        {
            this.DestroyRingCatcher();
        }
        
        public float GetMinScaleValue()
        {
            return _minScaleData.Value;
        }

        public IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(2.5f);
            Destroy(this.gameObject);
        }

        
    }
}
