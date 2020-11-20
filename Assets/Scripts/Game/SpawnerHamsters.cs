using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HamsterThieves.Game
{
    public class SpawnerHamsters : MonoBehaviour
    {
        [SerializeField] private PoolHamsters _poolHamsters;
        [SerializeField] private HamsterHoles _poolHamsterHoles;
        [Space(10)]
        [SerializeField] private SelectionHamster _selectionHamster;
        [SerializeField] private ComplexityGame _complexityGame;
        [SerializeField] private Score _score;

        private List<Hamster> _listHamsters;
        private Coroutine _coroutineSpawnHamsters;
        private Coroutine _coroutineWainEmptyListHamster;

        private void Awake()
        {
            _listHamsters = new List<Hamster>();
        }

        public void StartSpawn()
        {
            if (_coroutineWainEmptyListHamster != null)
                StopCoroutine(_coroutineWainEmptyListHamster);

            if (_coroutineSpawnHamsters != null)
                StopCoroutine(_coroutineSpawnHamsters);

            _coroutineSpawnHamsters = StartCoroutine(CoroutineSpawnHamsters());
        }

        public void StopSpawn()
        {
            Time.timeScale = 0;

            if (_coroutineWainEmptyListHamster != null)
                StopCoroutine(_coroutineWainEmptyListHamster);

            if (_coroutineSpawnHamsters != null)
                StopCoroutine(_coroutineSpawnHamsters);

            foreach (var hamster in _listHamsters)
            {
                hamster.gameObject.SetActive(false);
                _poolHamsterHoles.DropPositionHole(hamster.transform.position);
            }

            _listHamsters.Clear();
        }

        private IEnumerator CoroutineSpawnHamsters()
        {
            while (true)
            {
                SpawnHamsters();
                yield return StartCoroutine(CoroutineWaitEmptyListHamster());
                yield return new WaitForSeconds(0.5f);
            }
        }

        private IEnumerator CoroutineWaitEmptyListHamster()
        {
            while (_listHamsters.Count != 0)
            {
                foreach (Hamster goHamster in _listHamsters)
                {
                    if (!goHamster.gameObject.activeSelf)
                    {
                        _poolHamsterHoles.DropPositionHole(goHamster.transform.position);
                        _listHamsters.Remove(goHamster);
                        break;
                    }
                }

                yield return null;
            }
        }

        private void SpawnHamsters()
        {
            _complexityGame.ChangeComplexity(_score.Value);

            for (int i = 0; i < Random.Range(_complexityGame.MinCountEnemy, _complexityGame.MaxCountEnemy); i++)
            {
                Hamster hamster = _poolHamsters.GetUnit();
                hamster.transform.position = _poolHamsterHoles.GetPositionHole();

                _selectionHamster.SelectionRandomHamster(hamster);

                _listHamsters.Add(hamster);
            }
        }
    }
}
