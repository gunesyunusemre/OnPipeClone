using System.Collections.Generic;
using UnityEngine;

namespace Ring
{
    public static class RingHelper
    {
        public static Dictionary<int, IRing> RingList = new Dictionary<int, IRing>();

        public static void InitializeRing(this IRing ring)
        {
            RingList.Add(ring.InstanceID,ring);
        }

        public static void DestroyRing(this IRing ring)
        {
            RingList.Remove(ring.InstanceID);
        }
    }
    
    public interface IRing
    {
        int InstanceID { get; }
    }
}
