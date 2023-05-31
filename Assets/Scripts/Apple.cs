using UnityEngine;
using VContainer;

public class Apple : MonoBehaviour
{
    [SerializeField] private int income;
    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }

    public void Collect()
    {
        _wallet.Earn(income);
        Destroy(gameObject);
    }
}