using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers.Initializer
{
    public class ManagerInitializerMono : MonoBehaviour
    {
        [SerializeField] private AbstractScriptableBaseManagerInitializer[] _abstractScriptableManagerArray;
        private List<AbstractScriptableBaseManagerInitializer> _instantiatedManagerList;

        private void Start()
        {
            _instantiatedManagerList = new List<AbstractScriptableBaseManagerInitializer>(_abstractScriptableManagerArray.Length);
            for (int i = 0; i < _abstractScriptableManagerArray.Length; i++)
            {
                var instantiated = Instantiate(_abstractScriptableManagerArray[i]);
                instantiated.Initialize();
                _instantiatedManagerList.Add(instantiated);
            }
        }

        private void OnDestroy()
        {
            if (_instantiatedManagerList!=null)
            {
                for (int i = 0; i < _abstractScriptableManagerArray.Length; i++)
                {
                    _abstractScriptableManagerArray[i].Destroy();
                }
            }
        }
    }
}
