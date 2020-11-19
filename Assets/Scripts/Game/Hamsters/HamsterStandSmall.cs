public class HamsterStandSmall : Hamster
{
    private void Start()
    {
        tapHamsterSound = TypeSound.StandSmall;
    }

    public override void TapHamster()
    {
        if (!isTap)
        {
            OnScoreChange?.Invoke(5);
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
