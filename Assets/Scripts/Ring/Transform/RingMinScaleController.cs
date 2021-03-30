using System;
using Managers.Input;
using RingCatcher;
using UnityEngine;

namespace Ring.Transform
{
    public class RingMinScaleController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private RingData myData;

        private void Awake()
        {
            myData.MyMinScaleController = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Collider: " +other.name);
            int colliderInstanceID = other.GetInstanceID();
            if (!RingCatcherHelper.RingCatcherList.ContainsKey(colliderInstanceID)) return;

            var thisRingCatcher = RingCatcherHelper.RingCatcherList[colliderInstanceID];
            var minScaleValue=thisRingCatcher.GetMinScaleValue();
            //Debug.Log("Ring Catcher Minimum Value: "+ minScaleValue);
            
            //Create new Cylinder
            RingCatcherSpawnManager.Instance.CreateNewRingCatcher();
            //Destroy this cylinder
            StartCoroutine(thisRingCatcher.WaitAndDestroy());
            

            if (transform.parent.localScale.x < minScaleValue)
            {
                //Debug.Log("Game over");
                StopAllCoroutine();
                myData.EndLevel(EndStatus.Lose);
                return;
            }
            _inputData.MinValue = minScaleValue;
            //Debug.Log("Input Minimum Value: "+_inputData.MinValue);
            
        }

        public void StopAllCoroutine()
        {
            StopAllCoroutines();
        }
    }
}
