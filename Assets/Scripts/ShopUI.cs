using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Close();
    }

    private void Start() => _gameManager.OnGameStartedEvent += Close;

    public void Open() => shop.SetActive(true);

    public void Close() => shop.SetActive(false);

    private void OnDestroy() => _gameManager.OnGameStartedEvent -= Close;
}