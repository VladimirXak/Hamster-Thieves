using UnityEngine;

namespace HamsterThieves.Game
{
    [CreateAssetMenu(fileName = "DataHamster", menuName = "ScriptableObject/DataHamster")]
    public class DataHamster : ScriptableObject
    {
        public int healthTap;
        public int healthWithoutTap;
        public int score;
        public RuntimeAnimatorController animatorController;
        public TypeSound typeSound;
    }
}
