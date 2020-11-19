using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHamster : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Score score;
    [Space(10)]
    [SerializeField] private List<RuntimeAnimatorController> listRuntimeAnimatorController;

    public event Action<int> OnScoreChange;
    public event Action<int> OnHealthChange;

    public void SelectionRandomHamster(GameObject goHamster)
    {
        Hamster hamster;

        int rndHamster = UnityEngine.Random.Range(0, 6);

        switch(rndHamster)
        {
            case 0:
                hamster = goHamster.AddComponent<HamsterStandSmall>();
                break;
            case 1:
                hamster = goHamster.AddComponent<HamsterStandBig>();
                break;
            case 2:
                hamster = goHamster.AddComponent<HamsterBombSmall>();
                break;
            case 3:
                hamster = goHamster.AddComponent<HamsterBombBig>();
                break;
            case 4:
                hamster = goHamster.AddComponent<HamsterHealSmall>();
                break;
            case 5:
                hamster = goHamster.AddComponent<HamsterHealBig>();
                break;
            default:
                hamster = goHamster.AddComponent<HamsterStandSmall>();
                break;
        }

        if (rndHamster < listRuntimeAnimatorController.Count)
        {
            goHamster.GetComponent<Animator>().runtimeAnimatorController = listRuntimeAnimatorController[rndHamster];
        }
        else
        {
            goHamster.GetComponent<Animator>().runtimeAnimatorController = listRuntimeAnimatorController[0];
        }

        hamster.SetInfo(OnHealthChange, OnScoreChange);
    }
}
