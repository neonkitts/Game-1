using UnityEngine;

namespace Script_1.Player1
{
    public class Playermoment : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        private Vector3 _movemet;
        public Vector3 Movemet=>_movemet;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _movemet=new Vector3( Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical") );
            transform.position+=_movemet.normalized*(_moveSpeed*Time.deltaTime);
        }
    }
}
