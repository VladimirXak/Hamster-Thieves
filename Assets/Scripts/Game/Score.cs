using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private GameCore gameCore;
    [SerializeField] private SelectionHamster selectionHamster;

    [SerializeField] private Text txtScore;

    public int Value { get; private set; }

    private void ChangeValue(int value = 0)
    {
        Value += value;
        txtScore.text = Value.ToString();
    }

    private void OnEnable()
    {
        health.OnScoreChange += ChangeValue;
        gameCore.OnScoreChange += ChangeValue;
        selectionHamster.OnScoreChange += ChangeValue;
    }

    private void OnDisable()
    {
        health.OnScoreChange -= ChangeValue;
        gameCore.OnScoreChange -= ChangeValue;
        selectionHamster.OnScoreChange -= ChangeValue;
    }
}
