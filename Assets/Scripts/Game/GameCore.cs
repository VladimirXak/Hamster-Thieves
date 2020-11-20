using HamsterThieves.UI;
using System.Collections;
using UnityEngine;

namespace HamsterThieves.Game
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private SpawnerHamsters _spawnerHamsters;
        [SerializeField] private Timer _timer;

        [SerializeField] private Health _health;

        private void Awake()
        {
            _health.OnChangeData += GameOver;
        }

        private void Start()
        {
            StartCoroutine(CoroutineStartGame());
        }

        private void GameOver(object value)
        {
            if ((int)value != 0)
                return;

            _gameOverWindow.SetActive(true);
            _spawnerHamsters.StopSpawn();
        }

        private IEnumerator CoroutineStartGame()
        {
            yield return StartCoroutine(_timer.CoroutineStartTimer());

            yield return new WaitForSeconds(1f);

            _spawnerHamsters.StartSpawn();
        }

        private void OnDestroy()
        {
            _health.OnChangeData -= GameOver;
        }
    }
}
