using TMPro;

namespace UI
{
    public class WalletUIView
    {
        private readonly TextMeshProUGUI _money;
        public WalletUIView(TextMeshProUGUI money)
        {
            _money = money;
        }

        public void UpdateMoney(ref int amount)
        {
            _money.text = amount.ToString();
        }
    }
}