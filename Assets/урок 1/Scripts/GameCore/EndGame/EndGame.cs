using System;
using System.Collections;
using GameCore.Loot;
using GameCore.Pause;
using GameCore.UI;
using Player;
using Save;
using ScenesLoader;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace GameCore.EndGame
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Button _endButton;
        [SerializeField] private TMP_Text _coinsText;
        private WaitForSeconds _interval;
        private int _coins;
        
        private RewardCoinsAnimation _rewardCoinsAnimation;
        private CoinsKeeper _coinsKeeper;
        private PlayerData _playerData;
        private SaveProgress _saveProgress;
        private SceneLoader _sceneLoader;
        private GamePause _gamePause;

        private void OnEnable()
        {
            _gamePause.SetPause(true);
            _endButton.gameObject.SetActive(false);
            _coins = _coinsKeeper.Coins;
            _coinsText.text = "0";
            _interval = new WaitForSeconds(2.5f);
            StartCoroutine(CalculateCoins());
        }

        public void ExitGame()
        {
            _playerData.AddCoins(_coins);
            _saveProgress.SaveData();
            _sceneLoader.MainMenu();
        }

        private IEnumerator CalculateCoins()
        {
            if(_coins > 10)
                _rewardCoinsAnimation.ActivateAnimation(_coins,0,_coinsText);
            else
            {
                _coinsText.text = _coins.ToString();
                _endButton.gameObject.SetActive(true);
            }
            yield return _interval;
            _endButton.gameObject.SetActive(true);
        }
        

        [Inject] private void Construct(RewardCoinsAnimation coinsAnimation, CoinsKeeper coinsKeeper, 
            PlayerData playerData, SaveProgress saveProgress, GamePause gamePause, SceneLoader sceneLoader)
        {
            _rewardCoinsAnimation = coinsAnimation;
            _coinsKeeper = coinsKeeper;
            _playerData = playerData;
            _saveProgress = saveProgress;
            _gamePause = gamePause;
            _sceneLoader = sceneLoader;
        }
    }
}