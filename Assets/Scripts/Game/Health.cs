using System;
using UnityEngine;

namespace HamsterThieves.Game
{
    public class Health : AbstractDataValue
    {
        [SerializeField] private Score _score;

        public override event Action<object> OnChangeData;

        private const int _maxHealth = 100;

        private int _value = 100;
        public int Value
        {
            get => _value;
            private set
            {
                _value = value;
                OnChangeData?.Invoke(_value);
            }
        }

        public void ChangeHealth(int value)
        {
            int newValue = _value + value;

            if (newValue > _maxHealth)
            {
                Value = _maxHealth;
                _score.Value += newValue - _maxHealth;
            }
            else if (newValue < 0)
            {
                Value = 0;
            }
            else
            {
                Value = newValue;
            }
        }
    }
}
