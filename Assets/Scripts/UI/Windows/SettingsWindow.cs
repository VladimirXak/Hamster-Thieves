using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _supportsWindow;
        [Space(10)]
        [SerializeField] private Button _openSupportWindowButton;
        [SerializeField] private Button _closeSupportWindowButton;
        [SerializeField] private Button _closeWindowButton;

        private void Awake()
        {
            _openSupportWindowButton.onClick.AddListener(OpenSupportWindow);
            _closeSupportWindowButton.onClick.AddListener(CloseSupportWindow);
            _closeWindowButton.onClick.AddListener(CloseWindow);
        }

        private void OpenSupportWindow()
        {
            _supportsWindow.SetActive(true);
        }

        private void CloseSupportWindow()
        {
            _supportsWindow.SetActive(false);
        }

        private void CloseWindow()
        {
            gameObject.SetActive(false);
        }
    }
}
