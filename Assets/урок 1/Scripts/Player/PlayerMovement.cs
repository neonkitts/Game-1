using GameCore.Pause;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Animator _animator;
        private Vector3 _movement;
        private float _initialSpeed;
        private GamePause _gamePause;
        public Vector3 Movement => _movement;

        private void Start() => _initialSpeed = _moveSpeed;

        private void Update() => Move();

        private void Move()
        {
            _moveSpeed = _gamePause._isStopped ? 0 : _initialSpeed;
            _movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += _movement.normalized * (_moveSpeed * Time.deltaTime);
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);
        }
        public void UpgradeSpeed()
        {
            _moveSpeed += 0.3f;
            _initialSpeed = _moveSpeed;
        }

        [Inject]
        private void Construct(GamePause gamePause) => _gamePause = gamePause;
    }
}
