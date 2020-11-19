using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterBombSmall : Hamster
{
    private void Start()
    {
        tapHamsterSound = TypeSound.BombSmall;
    }

    public override void TapHamster()
    {
        if (!isTap)
        {
            OnHealthChange?.Invoke(-5);
            base.TapHamster();
            isTap = true;
        }
    }
}
