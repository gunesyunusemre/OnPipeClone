using System;
using UnityEngine;

namespace Ring.Transform
{
    public class RingMovement : MonoBehaviour
    {
        [SerializeField] private RingMovementData _speed;
        [SerializeField] private RingData myData;
        private void Update()
        {
            if (myData.GamePause) return;

            var pos = transform.position;
            //Move z direction
            pos.z = pos.z + (_speed.Value * Time.deltaTime);
            transform.position = pos;
        }
    }
}
