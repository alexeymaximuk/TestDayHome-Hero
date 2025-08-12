using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views.WalletView
{
    public class WalletWidget : LayoutViewBase, IWalletWidget
    {
        [SerializeField] private TextLabels _textLabels;
        private Label _levelUpPriceValue, _currentCoins;
        
        protected override void Awake()
        {
            base.Awake();
            _currentCoins = root.Q<Label>("current_coins_amount");
        }
        
        public void UpdateCoinsStats(long currentCoins)
        {
            _currentCoins.text = _textLabels.CurrentMoneyText + currentCoins;
        }
    }
}