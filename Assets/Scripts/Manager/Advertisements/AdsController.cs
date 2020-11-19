using GoogleMobileAds.Api;
using UnityEngine;

namespace HamsterThieves.GameSpace.Advertisements
{
    [RequireComponent(typeof(InterstitialAdMob))]
    [RequireComponent(typeof(RewardAdMob))]
    public class AdsController : MonoBehaviour
    {
        private InterstitialAdMob _interstitialAdMob;
        private RewardAdMob _rewardAdMob;

        private void Awake()
        {
            _interstitialAdMob = GetComponent<InterstitialAdMob>();
            _rewardAdMob = GetComponent<RewardAdMob>();
        }

        public void Init()
        {
            MobileAds.Initialize(initStatus => { });
        }

        public bool TryShowInterstitial()
        {
            if (_interstitialAdMob.TryShowVideo())
                return true;

            return false;
        }

        public bool IsReadyRewardAds()
        {
            if (_rewardAdMob.IsReadyAds())
                return true;

            return false;
        }

        public void ShowRewardAds(System.Action giveReward = null)
        {
            _rewardAdMob.Show(giveReward);
        }

        public TypeLoadingAds GetTypeLoadingAds()
        {
            return _rewardAdMob.GetTypeLoadingAds();
        }
    }

    public enum TypeLoadingAds
    {
        Error,
        Ready,
        Loading,
    }
}
