using UnityEngine;

namespace RingCatcher.Data
{
    public abstract class AbstractScriptableBaseRingCatcherData : ScriptableObject
    {
        private RingCatcherSpawnManager _ringCatcherSpawner;
        [HideInInspector]public GameObject ThisGameObject;
        public virtual void Initialize(RingCatcherSpawnManager _ringCatcherSpawner)
        {
            this._ringCatcherSpawner = _ringCatcherSpawner;
        }

        public virtual void Destroy()
        {
            Destroy(this);
        }
    }
}
