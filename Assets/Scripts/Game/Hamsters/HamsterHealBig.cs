using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealBig : Hamster
{
    private void Start()
    {
        tapHamsterSound = TypeSound.HealBig;
    }

    public override void TapHamster()
    {
        if (!isTap)
        {
            OnHealthChange?.Invoke(10);
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
