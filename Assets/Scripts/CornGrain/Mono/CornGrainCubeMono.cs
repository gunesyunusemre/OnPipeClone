using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CornGrain.Mono
{
    public class CornGrainCubeMono : AbstractBaseCornGrainMono, ICollectable
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;
        public int InstanceID { get; private set; }

        private void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeCollectable();
        }

        private void OnDestroy()
        {
            this.DestroyCollectable();
        }
        
        public void SetGravity(bool isTrue)
        {
            _rigidbody.useGravity = isTrue;
        }

        public void SetTriggerType(bool isTrue)
        {
            _collider.isTrigger = isTrue;
        }

        public IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(1f);
            SetTriggerType(true);
            SetGravity(false);
            transform.gameObject.SetActive(false);
        }
    }
}
