using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shop, mainMenu;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Close();
    }

    private void Start() => _gameManager.OnGameStartedEvent += () => { shop.SetActive(false); };

    public void Open()
    {
        shop.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Close()
    {
        shop.SetActive(false);
        mainMenu.SetActive(true);
    }
}