using HamsterThieves.GameSpace.Advertisements;
using UnityEngine;

namespace HamsterThieves.GameSpace
{
    public class GameManager : MonoBehaviour
    {
        public static Audio Audio => GameContainer.Instance.Audio;
        public static AdsController Ads => GameContainer.Instance.AdsController;
    }
}
