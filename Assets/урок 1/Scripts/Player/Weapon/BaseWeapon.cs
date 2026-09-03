using System.Collections.Generic;
using Enemy;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Player.Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] private List<WeaponStats> _weaponStats = new List<WeaponStats>();
        protected float _damage;
        private DiContainer _diContainer;
        private int _currentLevel = 1;
        private int _maxLevel = 8;
        public List<WeaponStats> WeaponStats => _weaponStats;
        public float Damage => _damage;
        public int CurrentLevel => _currentLevel;
        public int MaxLevel => _maxLevel;

        private void Awake() => _diContainer.Inject(this);

        protected virtual void Start() => SetStats(0);

        public virtual void LevelUp()
        {
            if (_currentLevel < _maxLevel)
                _currentLevel++;
            SetStats(_currentLevel-1);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out EnemyHealth enemy))
            {
                float damage = Random.Range(_damage / 2f, _damage * 1.5f);
                enemy.TakeDamage(damage);
            }
        }

        protected virtual void SetStats(int value) => _damage = _weaponStats[value].Damage;

        [Inject] private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    }
}