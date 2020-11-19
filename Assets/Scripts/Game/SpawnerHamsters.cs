using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHamsters : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] private PoolHamsters poolHamsters;
    [SerializeField] private HamsterHoles poolHamsterHoles;
    [Space(10)]
    [SerializeField] private SelectionHamster selectionHamster;
    [SerializeField] private ComplexityGame complexityGame;
    [SerializeField] private Score score;

    private List<GameObject> listHamsters;
    private Coroutine coroutineSpawnHamsters;
    private Coroutine coroutineWainEmptyListHamster;

    private void Awake()
    {
        listHamsters = new List<GameObject>();
    }

    public void StartSpawn()
    {
        if (coroutineWainEmptyListHamster != null)
            StopCoroutine(coroutineWainEmptyListHamster);

        if (coroutineSpawnHamsters != null)
            StopCoroutine(coroutineSpawnHamsters);

        coroutineSpawnHamsters = StartCoroutine(CoroutineSpawnHamsters());
    }

    public void StopSpawn()
    {
        Time.timeScale = 0;

        if (coroutineWainEmptyListHamster != null)
            StopCoroutine(coroutineWainEmptyListHamster);

        if (coroutineSpawnHamsters != null)
            StopCoroutine(coroutineSpawnHamsters);

        foreach (var hamster in listHamsters)
        {
            hamster.SetActive(false);
            poolHamsterHoles.DropPositionHole(hamster.transform.position);
        }

        listHamsters.Clear();
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
        while (listHamsters.Count != 0)
        {
            foreach (GameObject goHamster in listHamsters)
            {
                if (!goHamster.activeSelf)
                {
                    poolHamsterHoles.DropPositionHole(goHamster.transform.position);
                    listHamsters.Remove(goHamster);
                    break;
                }
            }

            yield return null;
        }
    }

    private void SpawnHamsters()
    {
        complexityGame.ChangeComplexity(score.Value);

        for (int i = 0; i < Random.Range(complexityGame.MinCountEnemy, complexityGame.MaxCountEnemy); i++)
        {
            GameObject goHamster = poolHamsters.GetUnit();
            goHamster.transform.position = poolHamsterHoles.GetPositionHole();

            selectionHamster.SelectionRandomHamster(goHamster);

            listHamsters.Add(goHamster);
        }
    }
}
