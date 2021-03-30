using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RingCatcher
{
    public static class RingCatcherHelper
    {
        public static Dictionary<int, IRingCatcher> RingCatcherList = new Dictionary<int, IRingCatcher>();

        public static void InitializeRingCatcher(this IRingCatcher damageable)
        {
            RingCatcherList.Add(damageable.InstanceID, damageable);
        }

        public static void DestroyRingCatcher(this IRingCatcher damageable)
        {
            RingCatcherList.Remove(damageable.InstanceID);
        }
    }
    
    public interface IRingCatcher
    {
        int InstanceID { get; }
        float GetMinScaleValue();
        IEnumerator WaitAndDestroy();
    }
}
