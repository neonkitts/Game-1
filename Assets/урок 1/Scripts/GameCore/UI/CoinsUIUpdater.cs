using System;
using GameCore.Loot;
using TMPro;
using UnityEngine;
using Zenject;

namespace GameCore.UI
{
    public class CoinsUIUpdater: MonoBehaviour
    {
        public Action OnCountChanged;

        [SerializeField] private TMP_Text _coinsText;

        private void OnEnable() => OnCountChanged += UpdateCoinsText;

        private void OnDisable() => OnCountChanged -= UpdateCoinsText;

        private void UpdateCoinsText() => _coinsText.text = _coinsKeeper.Coins.ToString();

        private CoinsKeeper _coinsKeeper;
        
        [Inject] private void Construct(CoinsKeeper coinsKeeper) => _coinsKeeper = coinsKeeper;
    }
}