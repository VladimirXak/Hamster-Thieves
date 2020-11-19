using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterStandBig : Hamster
{
    private void Start()
    {
        tapHamsterSound = TypeSound.StandBig;
    }

    public override void TapHamster()
    {
        if (!isTap)
        {
            OnScoreChange?.Invoke(10);
            base.TapHamster();
            isTap = true;
        }
    }

    public override void DestroyWithoutTap()
    {
        if (!isTap)
            OnHealthChange?.Invoke(-10);

        base.DestroyWithoutTap();
    }
}
