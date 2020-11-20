using HamsterThieves.GameSpace;
using UnityEngine;

namespace HamsterThieves.Game
{
    [RequireComponent(typeof(Animator))]
    public class Hamster : MonoBehaviour
    {
        private Health _health;
        private Score _score;
        private DataHamster _dataHamster;

        private Animator _animator;
        private StateAnimationHamster _stateAnim;

        private bool _isTap;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Init(Health health, Score score)
        {
            _health = health;
            _score = score;
        }

        public void InitDataHamster(DataHamster dataHamster)
        {
            _dataHamster = dataHamster;
            _animator.runtimeAnimatorController = dataHamster.animatorController;

            PlayAnimation("Spawn");
        }

        public void TapHamster()
        {
            if (_isTap)
                return;

            _isTap = true;

            GameManager.Audio.PlaySound(_dataHamster.typeSound);

            _health.ChangeHealth(_dataHamster.healthTap);
            _score.Value += _dataHamster.score;

            if (_stateAnim != StateAnimationHamster.Diss)
                PlayAnimation("Death");
        }

        public void DestroyWithoutTap()
        {
            if (_isTap)
                return;

            _health.ChangeHealth(_dataHamster.healthWithoutTap);
            gameObject.SetActive(false);
        }

        public void DestroyWithTap()
        {
            gameObject.SetActive(false);
        }

        private void PlayAnimation(string nameAnimation)
        {
            switch (nameAnimation)
            {
                case "Spawn":
                    _stateAnim = StateAnimationHamster.Spawn;
                    break;
                case "Stand":
                    _stateAnim = StateAnimationHamster.Stand;
                    break;
                case "Diss":
                    _stateAnim = StateAnimationHamster.Diss;
                    break;
                case "Death":
                    _stateAnim = StateAnimationHamster.Death;
                    break;
            }

            if (_animator.runtimeAnimatorController != null)
                _animator.Play(nameAnimation);
        }

        private void OnDisable()
        {
            _isTap = false;
            _animator.runtimeAnimatorController = null;

            //в машине аниматора метод дестройвитхтаб есть, а тут я его удалил.
        }

        private enum StateAnimationHamster
        {
            Spawn,
            Stand,
            Diss,
            Death
        }
    }
}
