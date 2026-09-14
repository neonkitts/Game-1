

using Script_1.Player1;
using UnityEngine;

namespace Enemy
{ 
     class EnemyBeeMovement : MonoBehaviour
     {
    
        [SerializeField] private float _moveSpeed;
        private Vector3 _direction;
        private PlayerMovement _playerMovement;
    }
}