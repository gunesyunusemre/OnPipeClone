using UnityEngine;

namespace CornGrain.Data
{
    public abstract class AbstractBaseCornGrainData : ScriptableObject
    {
        private CornMaker _cornMaker;
        [HideInInspector]public GameObject ThisGameObject;
        public virtual void Initialize(CornMaker cornMaker)
        {
            this._cornMaker = cornMaker;
        }

        public virtual void Destroy()
        {
            Destroy(this);
        }
    }
}
