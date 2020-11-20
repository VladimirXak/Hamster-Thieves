using System;

namespace HamsterThieves.Game
{
    public class Score : AbstractDataValue
    {
        public override event Action<object> OnChangeData;

        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChangeData?.Invoke(_value);
            }
        }
    }
}
