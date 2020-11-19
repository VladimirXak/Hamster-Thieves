using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterBombBig : Hamster
{
    private void Start()
    {
        tapHamsterSound = TypeSound.BombBig;
    }

    public override void TapHamster()
    {
        if (!isTap)
        {
            OnHealthChange?.Invoke(-10);
            base.TapHamster();
            isTap = true;
        }
    }
}
