using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private GameCore gameCore;
    [SerializeField] private SelectionHamster selectionHamster;

    [SerializeField] private Text txtHealth;

    public event Action<int> OnScoreChange;

    private int healthPoints = 100;

    private int HealthPoints
    {
        get
        {
            return healthPoints;
        }

        set
        {
            if (value > 100)
                healthPoints = 100;
            else if (value < 0)
                healthPoints = 0;
            else
                healthPoints = value;
        }
    }

    private void ChangeHealth(int countHealht)
    {
        if (HealthPoints == 100)
        {
            if (countHealht > 0)
            {
                OnScoreChange?.Invoke(countHealht);
                return;
            }
        }

        HealthPoints += countHealht;
        txtHealth.text = HealthPoints.ToString();

        if (HealthPoints == 0)
        {
            gameCore.GameOver();
        }
    }

    private void OnEnable()
    {
        gameCore.OnHealthChange += ChangeHealth;
        selectionHamster.OnHealthChange += ChangeHealth;
    }

    private void OnDisable()
    {
        gameCore.OnHealthChange -= ChangeHealth;
        selectionHamster.OnHealthChange -= ChangeHealth;
    }
}
