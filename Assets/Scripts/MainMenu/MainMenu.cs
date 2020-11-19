using HamsterThieves.GameSpace;
using HamsterThieves.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.Game
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private SceneTransitionWindow _prefSceneTransitionWindow;
        [SerializeField] private GameObject _settingsWindow;
        [Space(10)]
        [SerializeField] private Button _playGameButton;
        [SerializeField] private Button _openSettingsButton;
        [SerializeField] private Button _quitGameButton;

        private Transform _transformCanvas;

        private void Awake()
        {
            _playGameButton.onClick.AddListener(PlayGame);
            _openSettingsButton.onClick.AddListener(OpenSettings);
            _quitGameButton.onClick.AddListener(QuitGame);

            _transformCanvas = FindObjectOfType<Canvas>().transform;

            GameManager.Audio.PlayMusic();
        }

        public void PlayGame()
        {
            SceneTransitionWindow sceneTransition = Instantiate(_prefSceneTransitionWindow, _transformCanvas);
            sceneTransition.Show(2);
        }

        public void OpenSettings()
        {
            _settingsWindow.SetActive(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
