using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI
{
    public class DataDisplay : MonoBehaviour
    {
        [SerializeField] private AbstractDataValue _dataValue;
        [SerializeField] private Text _txtData;

        private void Awake()
        {
            _dataValue.OnChangeData += Display;
        }

        private void OnDestroy()
        {
            _dataValue.OnChangeData -= Display;
        }

        private void Display(object value)
        {
            _txtData.text = value.ToString();
        }
    }
}
