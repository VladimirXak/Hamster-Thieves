using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealSmall : Hamster
{
    private void Start()
    {
        tapHamsterSound = TypeSound.HealSmall;
    }

    public override void TapHamster()
    {
        if (!isTap)
        {
            OnHealthChange?.Invoke(5);
            base.TapHamster();
            isTap = true;
        }
    }

    public override void DestroyWithoutTap()
    {
        if (!isTap)
            OnHealthChange?.Invoke(-5);

        base.DestroyWithoutTap();
    }
}
