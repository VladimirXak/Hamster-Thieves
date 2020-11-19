using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Text _txtScore;

        private void Awake()
        {
            _txtScore.text = RecordScore.GetScore().ToString();
        }
    }
}
