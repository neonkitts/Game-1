using UnityEngine;

namespace Script_1.Player1
{
    public class Playermoment : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] private Animator _animator;
        private Vector3 _movemet;
        public Vector3 Movemet=>_movemet;

        private void Update() => Move();

        private void Move()
        {
            _movemet=new Vector3( Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0 );
            transform.position+=_movemet.normalized*(_moveSpeed*Time.deltaTime);
            _animator.SetFloat("Horizontal",_movemet.x);
            _animator.SetFloat("Vertical",_movemet.y);
            _animator.SetFloat("Speed",_movemet.sqrMagnitude);
        }
    }
}
