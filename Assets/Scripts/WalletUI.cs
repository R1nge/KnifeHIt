using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    private Wallet _wallet;

    private void Awake() => _wallet = GetComponent<Wallet>();

    private void Start() => UpdateUI();

    private void UpdateUI() => money.text = _wallet.Money.ToString();
}