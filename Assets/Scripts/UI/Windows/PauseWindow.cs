using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI
{
    public class PauseWindow : MonoBehaviour
    {
        [SerializeField] private SceneTransitionWindow _prefSceneTransitionWindow;
        [SerializeField] private GameObject _supportWindow;
        [Space(10)]
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _openSupportWindow;
        [SerializeField] private Button _closeSupportWindow;

        private float _currentTimeScape;

        private void Awake()
        {
            _continueButton.onClick.AddListener(Continue);
            _homeButton.onClick.AddListener(ReturnHome);
            _openSupportWindow.onClick.AddListener(OpenSupportWindow);
            _closeSupportWindow.onClick.AddListener(CloseSupportWindow);
        }

        public void Init()
        {
            _currentTimeScape = Time.timeScale;
            Time.timeScale = 0;

            gameObject.SetActive(true);
        }

        private void Continue()
        {
            gameObject.SetActive(false);

            Time.timeScale = _currentTimeScape;
        }

        private void ReturnHome()
        {
            Time.timeScale = 1f;
            Instantiate(_prefSceneTransitionWindow, FindObjectOfType<Canvas>().transform).Show(1);
        }

        private void OpenSupportWindow()
        {
            _supportWindow.SetActive(true);
        }

        private void CloseSupportWindow()
        {
            _supportWindow.SetActive(false);
        }
    }
}
