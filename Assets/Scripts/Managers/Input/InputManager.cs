using System.Collections.Generic;
using UnityEngine;

namespace Managers.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private List<InputData> inputList;
        void Update()
        {
            //Execute Inputs
            foreach (var input in inputList)
            {
                //Detect input
                input.SetEnable();
                //Calculate value
                input.Process();
            }
        }
    }
}
