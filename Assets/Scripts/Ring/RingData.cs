using System;
using System.Collections.Generic;
using Ring.Transform;
using UnityEngine;

namespace Ring
{
    public enum EndStatus
    {
        Win,
        Lose
    }
    
    [CreateAssetMenu(menuName = "OnPipe/Ring/Ring Data")]
    public class RingData : ScriptableObject
    {
        [SerializeField] private bool _gamePause;
        [SerializeField] private int _collectableCount;
        [SerializeField] private int _totalCollectableCount;
        [HideInInspector]public RingMinScaleController MyMinScaleController;

        public int CollectableCount
        {
            get => _collectableCount;
            set => _collectableCount = value;
        }
        public int TotalCollectableCount => _totalCollectableCount;
        public bool GamePause
        {
            get => _gamePause;
            set => _gamePause = value;
        }

        public delegate void OnEndLevel(EndStatus status);
        public static event OnEndLevel OnEndLevelEventHandler;
        

        public void EndLevel(EndStatus status)
        {
            _gamePause = true;
            OnEndLevelEventHandler?.Invoke(status);
            
            switch (status)
            {
                case EndStatus.Win:
                    _totalCollectableCount += _collectableCount;
                    break;
                case EndStatus.Lose:
                    _collectableCount = 0;
                    break;
            }
        }
    }
}
