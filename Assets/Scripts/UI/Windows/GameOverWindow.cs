using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private SceneTransitionWindow _prefSceneTransitionWindow;
        [SerializeField] private GameCore _gameCore;
        [SerializeField] private Score _score;
        [SerializeField] private Text _txtScore;
        [Space(10)]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
            _homeButton.onClick.AddListener(ReturnHome);
        }

        private void OnEnable()
        {
            Time.timeScale = 1f;

            _txtScore.text = $"Score: {_score.Value.ToString()}";

            RecordScore.SaveScore(_score.Value);
        }

        private void Restart()
        {
            _gameCore.RestartGame();
        }

        private void ReturnHome()
        {
            Instantiate(_prefSceneTransitionWindow, FindObjectOfType<Canvas>().transform).Show(1);
        }
    }
}
