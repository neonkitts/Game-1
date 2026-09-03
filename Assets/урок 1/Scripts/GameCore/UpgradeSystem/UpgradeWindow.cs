using System;
using System.Collections.Generic;
using GameCore.Pause;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GameCore.UpgradeSystem
{
    public class UpgradeWindow : MonoBehaviour
    {
        [SerializeField] private List<CardHolder> _allCards = new List<CardHolder>();

        [Header("weapon cards")] 
        [SerializeField] private CardHolder _fireBall;
        [SerializeField] private CardHolder _aura;
        [SerializeField] private CardHolder _suriken;
        [SerializeField] private CardHolder _frozen;
        [SerializeField] private CardHolder _trap;
        [SerializeField] private CardHolder _bow;
        
        private List<CardHolder> _cardsInPull = new List<CardHolder>();
        private PlayerUpgrade _playerUpgrade;
        private GamePause _gamePause;
        

        private void Start()
        {
            _allCards.Add(_fireBall);
            _allCards.Add(_aura);
            _allCards.Add(_suriken);
            _allCards.Add(_frozen);
            _allCards.Add(_trap);
            _allCards.Add(_bow);
        }

        private void OnEnable()
        {
            _gamePause.SetPause(true);
            ClearPull();
            CheckWeaponLevels();
        }

        private void OnDisable()
        {
            _gamePause.SetPause(false);
            CheckWeaponLevels();
        }

        private void CheckWeaponLevels()
        {
            if (_playerUpgrade.FireBallWeapon.CurrentLevel >= 8) 
                _allCards.Remove(_fireBall);
            if (_playerUpgrade.AuraWeapon.CurrentLevel >= 8) 
                _allCards.Remove(_fireBall);
            if (_playerUpgrade.SurikenWeapon.CurrentLevel >= 8) 
                _allCards.Remove(_fireBall);
            if (_playerUpgrade.FrostBoltWeapon.CurrentLevel >= 8) 
                _allCards.Remove(_fireBall);
            if (_playerUpgrade.TrapWeapon.CurrentLevel >= 8) 
                _allCards.Remove(_fireBall);
            if (_playerUpgrade.BowWeapon.CurrentLevel >= 8) 
                _allCards.Remove(_fireBall);
        }

        public void Upgrade(int id)
        {
            switch (id)
            {
                case 1:
                    _playerUpgrade.UpgradeHealth();
                    break;
                case 2:
                    _playerUpgrade.UpgradeSpeed();
                    break;
                case 3:
                    _playerUpgrade.UpgradeRegeneration();
                    break;
                case 4:
                    _playerUpgrade.UpgradeRangeExp();
                    break;
                case 5:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.FireBallWeapon);
                    break;
                case 6:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.AuraWeapon);
                    break;
                case 7:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.SurikenWeapon);
                    break;
                case 8:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.FrostBoltWeapon);
                    break;
                case 9:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.TrapWeapon);
                    break;
                case 10:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.BowWeapon);
                    break;
            }
        }

        public void GetRandomCards()
        {
            while (_cardsInPull.Count < 3)
            {
                CardHolder randomCard = RandomCard();
                if(randomCard.gameObject.activeSelf) continue;
                _cardsInPull.Add(randomCard);
                randomCard.gameObject.SetActive(true);
            }
        }

        private void ClearPull()
        {
            _cardsInPull.Clear();
            for (int i = 0; i < _allCards.Count; i++) 
                _allCards[i].gameObject.SetActive(false);
        }

        private CardHolder RandomCard() => _allCards[Random.Range(0, _allCards.Count)];

        [Inject] private void Construct(PlayerUpgrade playerUpgrade, GamePause gamePause)
        {
            _playerUpgrade = playerUpgrade;
            _gamePause = gamePause;
        }
    }
}