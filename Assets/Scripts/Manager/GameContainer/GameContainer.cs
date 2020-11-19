using HamsterThieves.GameSpace.Advertisements;
using UnityEngine;

namespace HamsterThieves.GameSpace
{
    public class GameContainer : Singleton<GameContainer>
    {
        [SerializeField]
        private Audio _audio;
        public Audio Audio => _audio;

        [SerializeField] private AdsController _adsController;
        public AdsController AdsController => _adsController;
    }
}
