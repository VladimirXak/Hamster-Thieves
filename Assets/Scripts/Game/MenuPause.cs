using HamsterThieves.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.Game
{
    public class MenuPause : MonoBehaviour
    {
        [SerializeField] private PauseWindow _pauseWindow;
        [Space(10)]
        [SerializeField] private Button _pauseButton;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(Pause);
        }

        private void Pause()
        {
            _pauseWindow.Init();
        }
    }
}
