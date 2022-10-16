using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _wallet.OnMoneyChanged += UpdateUI;
    }

    private void Start() => UpdateUI(_wallet.Money);

    private void UpdateUI(int amount) => money.text = amount.ToString();

    private void OnDestroy() => _wallet.OnMoneyChanged -= UpdateUI;
}