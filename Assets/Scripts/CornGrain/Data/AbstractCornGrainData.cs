using CornGrain.Mono;
using UnityEngine;

namespace CornGrain.Data
{
    public class AbstractCornGrainData<T> : AbstractBaseCornGrainData 
        where T : AbstractBaseCornGrainMono
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
