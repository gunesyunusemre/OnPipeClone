using System;
using System.Collections.Generic;
using Managers.Input;
using UnityEngine;

namespace Ring.Transform
{
    public class RingScale : MonoBehaviour
    {
        [SerializeField] private InputData _input;
        [SerializeField] private RingData myData;

        private void Start()
        {
            myData.GamePause = false;
            myData.CollectableCount = 0;
        }

        private void Update()
        {
            if (myData.GamePause) return;

            var localScale = transform.localScale;
            var targetScale = new Vector3(_input.Value, _input.Value, localScale.z);
            
            localScale=Vector3.Lerp(localScale,targetScale, Time.deltaTime*4f);
            
            transform.localScale = localScale;
        }
    }
}
