using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    private void Awake() => Close();

    public void Open() => shop.SetActive(true);

    public void Close() => shop.SetActive(false);
}