using System;
using CornGrain;
using UnityEngine;

namespace Ring
{
    public class CollectableCatcher : MonoBehaviour
    {
        [SerializeField] private RingData myData;
        
        private void OnTriggerEnter(Collider other)
        {
            var InstanceID = other.GetInstanceID();
            if (!CollectableHelper.CollectableList.ContainsKey(InstanceID)) return;

            var collectable = CollectableHelper.CollectableList[InstanceID];
            //Debug.Log(other.name);
            collectable.SetGravity(true);
            collectable.SetTriggerType(false);
            StartCoroutine(collectable.WaitAndDestroy());

            myData.CollectableCount++;
        }
    }
}
