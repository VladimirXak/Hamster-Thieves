using System.Collections.Generic;
using UnityEngine;

namespace HamsterThieves.Game
{
    public class SelectionHamster : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private List<DataHamster> _listDataHamster;

        public void SelectionRandomHamster(Hamster hamster)
        {
            DataHamster dataHamster = _listDataHamster[Random.Range(0, _listDataHamster.Count)];
            hamster.InitDataHamster(dataHamster);
        }
    }
}
