using System;
using System.Collections.Generic;
using Managers;
using Managers.Initializer;
using RingCatcher.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RingCatcher
{
    [CreateAssetMenu(menuName = "OnPipe/Manager/Ring Catcher Spawner")]
    public class RingCatcherSpawnManager : ScriptableManagerInitializer<RingCatcherSpawnManager>
    {
        [SerializeField] private AbstractScriptableBaseRingCatcherData[] _ringCatcherDataArray;
        private List<AbstractScriptableBaseRingCatcherData> _instantiatedRingCatcherDataList;

        public GameObject parent;

        [SerializeField] private float _spacerZ = 2f;

        public override void Initialize()
        {
            base.Initialize();
            //Debug.Log("Scriptable Ring Catcher Spawn Manager activated");
            parent = Instantiate(parent);
            InitializeRingCatcher();
        }

        public override void Destroy()
        {
            base.Destroy();
            //Debug.Log("Scriptable Ring Catcher Spawn Manager deactivated");
            ClearCornGrains();
        }


        private void InitializeRingCatcher()
        {
            ClearCornGrains();
            _instantiatedRingCatcherDataList = new List<AbstractScriptableBaseRingCatcherData>(3);
            for (int i = 0; i < 3; i++)
            {
                CreateRingCatcher(i);
            }
        }
        
        private void ClearCornGrains()
        {
            if (_instantiatedRingCatcherDataList!=null)
            {
                foreach (var t in _instantiatedRingCatcherDataList)
                {
                    t.Destroy();
                }
            }
        }

        private void SetRingCatcherPosition(AbstractScriptableBaseRingCatcherData instantiated, int i)
        {
            var pos = instantiated.ThisGameObject.transform.position;
            var zeroPoint = i == 0 ? 0 : _instantiatedRingCatcherDataList[i - 1].ThisGameObject.transform.position.z;
            pos.z = zeroPoint+_spacerZ;
            instantiated.ThisGameObject.transform.position = pos;
        }
        
        private void CreateRingCatcher(int i)
        {
            var type = Random.Range(0, _ringCatcherDataArray.Length);
            var instantiated = Instantiate(_ringCatcherDataArray[type]);
            instantiated.Initialize(this);
                
            SetRingCatcherPosition(instantiated, i);
                
            _instantiatedRingCatcherDataList.Add(instantiated);
        }

        public void CreateNewRingCatcher()
        {
            _instantiatedRingCatcherDataList.Remove(_instantiatedRingCatcherDataList[0]);
            CreateRingCatcher(2);
            var target = _instantiatedRingCatcherDataList[2].ThisGameObject.transform;
            EndLevelManager.Instance.ControlEndGame(target);
        }

    }
}
