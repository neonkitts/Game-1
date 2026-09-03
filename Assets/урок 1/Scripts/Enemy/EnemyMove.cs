using System;
using System.Collections;
using GameCore.Pause;
using Player;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _freezeTimer;
        [SerializeField] private Animator _animator;
        private Vector3 _direction;
        private PlayerMovement _playerMovement;
        private WaitForSeconds _checkTime = new WaitForSeconds(3f);
        private WaitForSeconds _freeze;
        private Coroutine _distanceToHide;
        private float _initialSpeed;

        private GamePause _gamePause;

        private void Start()
        {
            _initialSpeed = _moveSpeed;
            _freeze = new WaitForSeconds(_freezeTimer);
        }

        private void OnEnable() => _distanceToHide = StartCoroutine(CheckDistanceToHide());

        private void OnDisable() => StopCoroutine(_distanceToHide);

        private void Update() => Move();

        public void FreezeEnemy()
        {
            if (gameObject.activeSelf)
                StartCoroutine(StartFreeze());
        }

        private void Move()
        {
            _moveSpeed = _gamePause._isStopped ? 0f : _initialSpeed;
            _direction = (_playerMovement.transform.position - transform.position).normalized;
            transform.position += _direction * (_moveSpeed * Time.deltaTime);
            _animator.SetFloat("Horizontal", _direction.x);
            _animator.SetFloat("Vertical", _direction.y);
        }

        private IEnumerator CheckDistanceToHide()
        {
            while (true)
            {
                float distance = Vector3.Distance(transform.position, _playerMovement.transform.position);
                if (distance > 20f) 
                    gameObject.SetActive(false);
                yield return _checkTime;
            }
        }

        private IEnumerator StartFreeze()
        {
            _moveSpeed /= 2f;
            yield return _freeze;
            _moveSpeed = _initialSpeed;
        }
        
       [Inject] private void Construct(PlayerMovement playerMovement, GamePause gamePause)
       {
           _playerMovement = playerMovement;
           _gamePause = gamePause;
       }
    }
}