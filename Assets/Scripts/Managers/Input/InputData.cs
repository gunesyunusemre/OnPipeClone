using UnityEngine;

namespace Managers.Input
{
    [CreateAssetMenu(menuName = "OnPipe/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        [SerializeField] private KeyCode _keyCode;
        [SerializeField] private bool _isEnable;
        [SerializeField] private float _value;
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;
        [SerializeField] private float _inceraseValue;
        
        public float Value => _value;
        public float MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        /// <summary>
        /// This method checks inputs.
        /// </summary>
        public void SetEnable()
        {
            if (UnityEngine.Input.GetKeyDown(_keyCode))
            {
                //Key Down
                _isEnable = true;
                //Debug.Log("Down");
            }
            else if (UnityEngine.Input.GetKeyUp(_keyCode))
            {
                //Key Up
                _isEnable = false;
                //Debug.Log("Up");
            }
        }
        
        /// <summary>
        /// This method does the calculations
        /// </summary>
        public void Process()
        {
            if (!_isEnable)
            {
                _value += _inceraseValue;
            }
            else
            {
                _value -= _inceraseValue;
            }

            _value = Mathf.Clamp(_value, _minValue, _maxValue);
        }
        
    }
}
