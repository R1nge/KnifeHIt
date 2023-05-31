using UnityEngine;
using VContainer;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, shop, inGameMenu, winMenu, gameOverMenu;
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Awake()
    {
        _gameManager.OnGameStartedEvent += OnGameStarted;
        _gameManager.OnGameOverEvent += OnGameOver;
        _gameManager.OnGameWinEvent += OnGameWin;
        Init();
    }

    public void StartGame() => _gameManager.StartGame();

    public void RestartGame() => _gameManager.RestartGame();

    public void OpenShop()
    {
        ShowShop();
        HideMainMenu();
    }

    public void CloseShop()
    {
        HideShop();
        ShowMainMenu();
    }

    private void Init()
    {
        ShowMainMenu();
        HideInGameMenu();
        HideWinGameMenu();
        HideGameOverMenu();
    }

    private void OnGameStarted()
    {
        HideMainMenu();
        ShowInGameMenu();
        HideWinGameMenu();
        HideGameOverMenu();
    }

    private void OnGameOver()
    {
        HideInGameMenu();
        ShowGameOverMenu();
    }

    private void OnGameWin()
    {
        ShowWinGameMenu();
    }

    private void ShowMainMenu() => mainMenu.SetActive(true);

    private void ShowInGameMenu() => inGameMenu.SetActive(true);

    private void ShowWinGameMenu() => winMenu.SetActive(true);

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    private void HideMainMenu() => mainMenu.SetActive(false);

    private void HideInGameMenu() => inGameMenu.SetActive(false);

    private void HideWinGameMenu() => winMenu.SetActive(false);

    private void HideGameOverMenu() => gameOverMenu.SetActive(false);

    private void ShowShop() => shop.SetActive(true);

    private void HideShop() => shop.SetActive(false);

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= OnGameStarted;
        _gameManager.OnGameOverEvent -= OnGameOver;
        _gameManager.OnGameWinEvent -= OnGameWin;
    }
}