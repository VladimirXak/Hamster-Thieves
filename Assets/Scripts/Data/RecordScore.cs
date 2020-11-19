using UnityEngine;

public static class RecordScore
{
    private const string _hamsterScore = "hamsterScore";

    public static void SaveScore(int score)
    {
        if (GetScore() < score)
            PlayerPrefs.SetInt(_hamsterScore, score);
    }

    public static int GetScore()
    {
        if (PlayerPrefs.HasKey(_hamsterScore))
        {
            return PlayerPrefs.GetInt(_hamsterScore);
        }

        return 0;
    }
}
