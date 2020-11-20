using HamsterThieves.GameSpace;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HamsterThieves.UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Text _txtTimer;

        private Coroutine _coroutineTimer;

        private void Awake()
        {
            _txtTimer.gameObject.SetActive(false);
            _txtTimer.text = null;
        }

        public void StartTimer()
        {
            if (_coroutineTimer != null)
            {
                StopCoroutine(_coroutineTimer);
            }

            _coroutineTimer = StartCoroutine(CoroutineStartTimer());
        }

        public IEnumerator CoroutineStartTimer()
        {
            _txtTimer.gameObject.SetActive(true);

            Time.timeScale = 1;

            int countSecond = 3;

            while (countSecond != 0)
            {
                yield return new WaitForSeconds(1);
                _txtTimer.text = countSecond.ToString();

                countSecond--;
            }

            yield return new WaitForSeconds(1);

            GameManager.Audio.PlaySound(TypeSound.HamsterGo);
            _txtTimer.text = "Go!";

            yield return new WaitForSeconds(1);

            _txtTimer.text = null;
            _txtTimer.gameObject.SetActive(false);
        }
    }
}