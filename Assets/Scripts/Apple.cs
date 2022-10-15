using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private int income;
    private Wallet _wallet;

    private void Awake() => _wallet = FindObjectOfType<Wallet>();

    public void Collect()
    {
        _wallet.Earn(income);
        Destroy(gameObject);
    }
}