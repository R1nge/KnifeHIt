using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, inGameMenu, winMenu, gameOverMenu;
    private GameManager _gameManager;

    private void Awake()
    {
        ShowMainMenu();
        HideInGameMenu();
        HideWinGameMenu();
        HideGameOverMenu();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += HideMainMenu;
        _gameManager.OnGameStartedEvent += ShowInGameMenu;
        _gameManager.OnGameStartedEvent += HideWinGameMenu;
        _gameManager.OnGameStartedEvent += HideGameOverMenu;
        _gameManager.OnGameOverEvent += HideInGameMenu;
        _gameManager.OnGameOverEvent += ShowGameOverMenu;
        _gameManager.OnGameWinEvent += ShowWinGameMenu;
    }

    private void ShowMainMenu() => mainMenu.SetActive(true);

    private void ShowInGameMenu() => inGameMenu.SetActive(true);

    private void ShowWinGameMenu() => winMenu.SetActive(true);

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    private void HideMainMenu() => mainMenu.SetActive(false);

    private void HideInGameMenu() => inGameMenu.SetActive(false);

    private void HideWinGameMenu() => winMenu.SetActive(false);

    private void HideGameOverMenu() => gameOverMenu.SetActive(false);

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= HideMainMenu;
        _gameManager.OnGameStartedEvent -= ShowInGameMenu;
        _gameManager.OnGameStartedEvent -= HideWinGameMenu;
        _gameManager.OnGameStartedEvent -= HideGameOverMenu;
        _gameManager.OnGameOverEvent -= HideInGameMenu;
        _gameManager.OnGameOverEvent -= ShowGameOverMenu;
        _gameManager.OnGameWinEvent -= ShowWinGameMenu;
    }
}