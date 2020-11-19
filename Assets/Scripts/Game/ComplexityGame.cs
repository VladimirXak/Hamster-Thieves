using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexityGame : MonoBehaviour
{
    [SerializeField] private List<DataComlexityGame> dataComlexityGame;

    public int MinCountEnemy { get; private set; } = 1;
    public int MaxCountEnemy { get; private set; } = 1;

    public void ChangeComplexity(int currentScore)
    {
        for (int i = dataComlexityGame.Count-1; i >= 0; i--)
        {
            if (currentScore >= dataComlexityGame[i].score)
            {
                Time.timeScale = dataComlexityGame[i].timeScale;

                MinCountEnemy = dataComlexityGame[i].minEnemy;
                MaxCountEnemy = dataComlexityGame[i].maxEnemy;
                break;
            }
        }
    }

    private void OnValidate()
    {
        foreach (var data in dataComlexityGame)
        {
            if (data.minEnemy < 1)
                data.minEnemy = 1;

            if (data.maxEnemy < 1)
                data.maxEnemy = 1;

            if (data.timeScale <= 0)
                data.timeScale = 1f;
        }
    }
}

[System.Serializable]
public class DataComlexityGame
{
    [Header("Количество очков")]
    public int score;
    [Header("Минимальное количество врагов")]
    public int minEnemy;
    [Header("Максимальное количество врагов")]
    public int maxEnemy;
    [Header("Скорость игры")]
    public float timeScale;
}
