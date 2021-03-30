using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CornGrain
{
    public static class CollectableHelper
    {
        public static Dictionary<int, ICollectable> CollectableList = new Dictionary<int, ICollectable>();

        public static void InitializeCollectable(this ICollectable collectable)
        {
            CollectableList.Add(collectable.InstanceID, collectable);
        }

        public static void DestroyCollectable(this ICollectable collectable)
        {
            CollectableList.Remove(collectable.InstanceID);
        }
    }
    
    public interface ICollectable
    {
       int InstanceID { get; }
       void SetGravity(bool isTrue);
       void SetTriggerType(bool isTrue);
       IEnumerator WaitAndDestroy();
    }
}
