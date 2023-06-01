using UnityEngine;
using VContainer;

namespace UI
{
    public class WalletUIController : MonoBehaviour
    {
        [SerializeField] private WalletUIModel walletModel;
        private WalletUIView _walletUIView;
        private Wallet _wallet;

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }

        private void Awake()
        {
            _wallet.OnMoneyChanged += UpdateUI;
            _walletUIView = new(walletModel.money);
        }

        private void Start() => UpdateUI(_wallet.Money);

        private void UpdateUI(int amount) => _walletUIView.UpdateMoney(ref amount);

        private void OnDestroy() => _wallet.OnMoneyChanged -= UpdateUI;
    }
}