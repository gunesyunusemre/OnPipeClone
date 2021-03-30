using UnityEngine;

namespace CornGrain
{
    [CreateAssetMenu(menuName = "OnPipe/Corn Grain/CornMaker")]
    public class CornMakerData : ScriptableObject
    {
        private int _cornX;
        private int _cornY;
        [SerializeField] private float _spacerZ;
        [SerializeField] private float _spacerAngle;
        [SerializeField] private float _radius;

        public int CornX => _cornX;
        public int CornY => _cornY;
        public float SpacerZ => _spacerZ;
        public float SpacerAngle => _spacerAngle;

        public float Radius => _radius;

        public void Initialize(Transform makerTransform)
        {
            _cornY = (int)(360f / _spacerAngle);
            _cornX = (int)((makerTransform.localScale.z / _spacerZ) * 2);
            
        }
        
        public int GetLength()
        {
            return _cornX * _cornY;
        }
    }
}
