using System;
using System.Collections.Generic;
using CornGrain.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CornGrain
{
    public class CornMaker : MonoBehaviour
    {
        [SerializeField] private AbstractBaseCornGrainData[] _cornGrainDataArray;
        [SerializeField] private CornMakerData _makerData;
        private List<AbstractBaseCornGrainData> _instantiatedCornGrainDataList;

        

        private void Start()
        {
            _makerData.Initialize(transform);

            //Random spawn
            int i = Random.Range(0, 10);
            if (i>=5) return;
            
            InitializeCornGrains();
        }

        private void OnDestroy()
        {
            ClearCornGrains();
        }

        private void InitializeCornGrains()
        {
            ClearCornGrains();
            _instantiatedCornGrainDataList = new List<AbstractBaseCornGrainData>(_makerData.GetLength());
            var type = Random.Range(0, _cornGrainDataArray.Length);
            for (int i = 0; i < _makerData.CornX; i++)
            {
                for (int j = 0; j < _makerData.CornY; j++)
                {
                    var instantiated = Instantiate(_cornGrainDataArray[type]);
                    instantiated.Initialize(this);
                    
                    SetGrainPosition(instantiated, i, j);
                    
                    _instantiatedCornGrainDataList.Add(instantiated);
                }
                
            }
        }
        
        private void ClearCornGrains()
        {
            if (_instantiatedCornGrainDataList!=null)
            {
                foreach (var t in _instantiatedCornGrainDataList)
                {
                    t.Destroy();
                }
            }
        }

        private void SetGrainPosition(AbstractBaseCornGrainData instantiated, int i, int j)
        {
            var pos = instantiated.ThisGameObject.transform.position;
            pos.z += i*_makerData.SpacerZ;
            pos.y += _makerData.Radius;
            instantiated.ThisGameObject.transform.position = pos;
                    
            instantiated.ThisGameObject.transform.RotateAround(transform.parent.position,
                transform.forward, _makerData.SpacerAngle*j);

        }
    }
}
