using TMPro;
using UnityEngine;
using VContainer;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void Awake() => _wallet.OnMoneyChanged += UpdateUI;

    private void Start() => UpdateUI(_wallet.Money);

    private void UpdateUI(int amount) => money.text = amount.ToString();

    private void OnDestroy() => _wallet.OnMoneyChanged -= UpdateUI;
}