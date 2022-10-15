using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    private void Awake()
    {
        Close();
        GameManager.Instance.OnGameStartedEvent += Close;
    }

    public void Open() => shop.SetActive(true);

    public void Close() => shop.SetActive(false);

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStartedEvent -= Close;
    }
}