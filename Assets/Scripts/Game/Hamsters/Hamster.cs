using HamsterThieves.GameSpace;
using System;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    protected Health health;
    protected Score score;

    protected bool isTap;
    protected TypeSound tapHamsterSound;

    private Animator animator;
    private StateAnimationHamster stateAnim;

    protected Action<int> OnScoreChange;
    protected Action<int> OnHealthChange;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlayAnimation("Spawn");
    }

    public void SetInfo(Action<int> health, Action<int> score)
    {
        OnHealthChange = health;
        OnScoreChange = score;
    }

    public virtual void TapHamster()
    {
        GameManager.Audio.PlaySound(tapHamsterSound);

        if (stateAnim != StateAnimationHamster.Diss)
            PlayAnimation("Death");
    }

    private void DestroyWithTap()
    {
        gameObject.SetActive(false);
    }

    public virtual void DestroyWithoutTap()
    {
        gameObject.SetActive(false);
    }

    private void PlayAnimation(string nameAnimation)
    {
        switch (nameAnimation)
        {
            case "Spawn":
                stateAnim = StateAnimationHamster.Spawn;
                break;
            case "Stand":
                stateAnim = StateAnimationHamster.Stand;
                break;
            case "Diss":
                stateAnim = StateAnimationHamster.Diss;
                break;
            case "Death":
                stateAnim = StateAnimationHamster.Death;
                break;
        }

        animator?.Play(nameAnimation);
    }

    private void OnDisable()
    {
        animator = null;

        Destroy(this);
    }

    private enum StateAnimationHamster
    {
        Spawn,
        Stand,
        Diss,
        Death
    }
}
