using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI.Logo
{
    [RequireComponent(typeof(Image))]
    public class Logo : MonoBehaviour
    {
        [SerializeField] private SceneTransitionWindow _prefSceneTransitionWindow;

        private Image _logo;
        private Transform _transformCanvas;

        private void Awake()
        {
            _transformCanvas = FindObjectOfType<Canvas>().transform;

            SetApplicationSettings();

            _logo = GetComponent<Image>();

            _logo.SetAlpha(0);

            _logo.DOFade(1, 1.5f).SetEase(Ease.Linear).SetDelay(0.5f).OnComplete(delegate
            {
                _logo.DOFade(0, 1.5f).SetEase(Ease.Linear).SetDelay(1f).OnComplete(delegate
                {
                    SceneTransitionWindow sceneTransition = Instantiate(_prefSceneTransitionWindow, _transformCanvas);
                    sceneTransition.Show(1);
                });
            });
        }

        private void SetApplicationSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 144;
        }
    }
}
