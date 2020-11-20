using System.Collections.Generic;
using UnityEngine;

namespace HamsterThieves.Game
{
    public class PoolHamsters : MonoBehaviour
    {
        [SerializeField] private Hamster _prefHamster;
        [SerializeField] private Health _health;
        [SerializeField] private Score _score;

        Queue<Hamster> _poolHamster = new Queue<Hamster>();

        private const int _startCountHamster = 9;

        private void Awake()
        {
            for (int i = 0; i < _startCountHamster; i++)
            {
                AddHamster();
            }
        }

        private void AddHamster()
        {
            Hamster hamster = Instantiate(_prefHamster, new Vector3(0, 0), Quaternion.identity, transform);
            hamster.gameObject.SetActive(false);
            hamster.Init(_health, _score);

            _poolHamster.Enqueue(hamster);
        }

        public Hamster GetUnit()
        {
            if (_poolHamster.Count == 0)
                AddHamster();

            Hamster hamster = _poolHamster.Dequeue();
            hamster.gameObject.SetActive(true);

            _poolHamster.Enqueue(hamster);

            return hamster;
        }

        public void DropUnit(Hamster hamster)
        {
            hamster.gameObject.SetActive(false);
        }
    }
}
