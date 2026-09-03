using Player;
using Player.Weapon;
using Player.Weapon.Bow;
using Player.Weapon.FrostBolt;
using Player.Weapon.Suriken;
using Player.Weapon.Trap;
using UnityEngine;
using Zenject;

namespace GameCore.UpgradeSystem
{
    public class PlayerUpgrade : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private PlayerMovement _playerMovement;
        
        private FireBallWeapon _fireBallWeapon;
        private AuraWeapon _auraWeapon;
        private SurikenWeapon _surikenWeapon;
        private FrostBoltWeapon _frostBoltWeapon;
        private TrapWeapon _trapWeapon;
        private BowWeapon _bowWeapon;

        public FireBallWeapon FireBallWeapon => _fireBallWeapon;
        public AuraWeapon AuraWeapon => _auraWeapon;
        public SurikenWeapon SurikenWeapon => _surikenWeapon;
        public FrostBoltWeapon FrostBoltWeapon => _frostBoltWeapon;
        public TrapWeapon TrapWeapon => _trapWeapon;
        public BowWeapon BowWeapon => _bowWeapon;

        public float RangeExp { get; private set; }
        private void Start() => RangeExp = 1.5f;

        public void UpgradeHealth() => _playerHealth.UpgradeHealth();
        
        public void UpgradeRegeneration() => _playerHealth.UpgradeRegeneration();

        public void UpgradeSpeed() => _playerMovement.UpgradeSpeed();

        public void UpgradeRangeExp() => RangeExp += 1f;

        public void UpgradeWeapon(BaseWeapon target)
        {
            if (target.gameObject.activeSelf)
                target.LevelUp();
            else
                ActivateWeapon(target);
        }

        private void ActivateWeapon(BaseWeapon target) => 
            target.gameObject.SetActive(true);

        [Inject]
        private void Construct(PlayerHealth health, PlayerMovement movement, FireBallWeapon fireball, AuraWeapon aura,
            SurikenWeapon suriken, FrostBoltWeapon frost, TrapWeapon trap, BowWeapon bow)
        {
            _playerHealth = health;
            _playerMovement = movement;
            _fireBallWeapon = fireball;
            _auraWeapon = aura;
            _surikenWeapon = suriken;
            _frostBoltWeapon = frost;
            _trapWeapon = trap;
            _bowWeapon = bow;
        }
    }
}