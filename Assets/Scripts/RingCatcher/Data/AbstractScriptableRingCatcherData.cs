using RingCatcher.Mono;
using UnityEngine;

namespace RingCatcher.Data
{
    public class AbstractScriptableRingCatcherData<T> : AbstractScriptableBaseRingCatcherData 
        where T:AbstractBaseRingCatcherMono
    {
        [SerializeField] protected string _itemID;
        [SerializeField] protected T _prefab;
        protected T _instantiated;
        
        protected T InstantiateAndInitializePrefab(Transform parent)
        {
            _instantiated = Instantiate(_prefab, parent);
            return _instantiated;
        }
        
    }
}
