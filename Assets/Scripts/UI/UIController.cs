using System;
using Managers.Input;
using Ring;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [Header("Panels")] 
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _firstScreenPanel;
        

        [Header("Buttons")]
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _tryAgainButton;

        [Header("Datas")] 
        [SerializeField] private InputData _inputData;
        
        private void OnEnable()
        {
            RingData.OnEndLevelEventHandler += EndStatus;
            _firstScreenPanel.SetActive(true);
            _nextLevelButton.onClick.AddListener(OnClickNextLevel);
            _tryAgainButton.onClick.AddListener(OnClickTryAgain);
        }

        private void OnDisable()
        {
            RingData.OnEndLevelEventHandler -= EndStatus;
        }

        private void Update()
        {
            if (_inputData.Value!=1f)
            {
                _firstScreenPanel.SetActive(false);
            }
        }

        private void EndStatus(EndStatus status)
        {
            switch (status)
            {
                case Ring.EndStatus.Win:
                    _winPanel.SetActive(true);
                    _losePanel.SetActive(false);
                    break;
                case Ring.EndStatus.Lose:
                    _winPanel.SetActive(false);
                    _losePanel.SetActive(true);
                    break;
            }
        }

        private void OnClickNextLevel()
        {
            Debug.Log("Next level button onclick!");
            SceneManager.LoadScene("Scenes/Level1");
        }
        private void OnClickTryAgain()
        {
            Debug.Log("Try Again button onclick!");
            SceneManager.LoadScene("Scenes/Level1");
        }
    }
}
