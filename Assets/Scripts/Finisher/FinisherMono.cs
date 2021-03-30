using System;
using Ring;
using UnityEngine;

namespace Finisher
{
    public class FinisherMono : MonoBehaviour
    {
        [SerializeField] private RingData _ringData;
        private void OnTriggerEnter(Collider other)
        {
            var instanceID = other.GetInstanceID();
            var isRing = RingHelper.RingList.ContainsKey(instanceID);
            if (!isRing) return;
            
            _ringData.MyMinScaleController.StopAllCoroutines();
            //Debug.Log("Level Successful");
            _ringData.EndLevel(EndStatus.Win);

        }
        
    }
}
