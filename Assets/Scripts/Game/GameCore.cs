using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private SpawnerHamsters spawnerHamsters;
    [SerializeField] private Timer timer;

    [SerializeField] private Score score;

    public event Action<int> OnScoreChange;
    public event Action<int> OnHealthChange;

    private void Start()
    {
        StartCoroutine(CoroutineStartGame());
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);

        spawnerHamsters.StopSpawn();
    }

    public void RestartGame()
    {
        OnHealthChange?.Invoke(100);
        OnScoreChange?.Invoke(-score.Value);

        StartCoroutine(CoroutineStartGame());
    }

    private IEnumerator CoroutineStartGame()
    {
        yield return StartCoroutine(timer.CoroutineStartTimer());

        yield return new WaitForSeconds(1f);

        spawnerHamsters.StartSpawn();
    }
}
