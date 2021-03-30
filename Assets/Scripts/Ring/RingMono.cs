using System;
using UnityEngine;

namespace Ring
{
    public class RingMono : MonoBehaviour,IRing
    {
        public int InstanceID { get; private set; }
        [SerializeField] private Collider _collider;

        private void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeRing();
        }

        private void OnDestroy()
        {
            this.DestroyRing();
        }
    }
}
