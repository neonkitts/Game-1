

using Script_1.Player1;
using UnityEngine;
using Zenject;

namespace Enemy
{ 
      public class EnemyBeeMovement : MonoBehaviour
     {
    
        [SerializeField] private float _moveSpeed;
        private Vector3 _direction;
        private PlayerMovement _playerMovement;

private void Update()
        {
            Move();
        }

private void Move()
        {
            _direction=(_playerMovement.transform.position-transform.position).normalized;
            transform.position+=_direction*(_moveSpeed*Time.deltaTime);
        }



        [Inject] private void Construct(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
    }
}