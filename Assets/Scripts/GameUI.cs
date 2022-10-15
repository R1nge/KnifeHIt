using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, gameOverMenu;
    private GameManager _gameManager;
    private void Awake()
    {
        ShowMainMenu();
        HideGameOverMenu();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += HideMainMenu;
        _gameManager.OnGameStartedEvent += HideGameOverMenu;
        _gameManager.OnGameEndedEvent += ShowGameOverMenu;
    }

    private void Start()
    {
        
    }

    private void ShowMainMenu() => mainMenu.SetActive(true);

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    private void HideMainMenu() => mainMenu.SetActive(false);

    private void HideGameOverMenu() => gameOverMenu.SetActive(false);

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= HideMainMenu;
        _gameManager.OnGameStartedEvent -= HideGameOverMenu;
        _gameManager.OnGameEndedEvent -= ShowGameOverMenu;
    }
}