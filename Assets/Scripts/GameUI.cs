using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, gameOverMenu;

    private void Awake()
    {
        ShowMainMenu();
        HideGameOverMenu();
        GameManager.Instance.OnGameStartedEvent += HideMainMenu;
        GameManager.Instance.OnGameStartedEvent += HideGameOverMenu;
        GameManager.Instance.OnGameEndedEvent += ShowGameOverMenu;
    }

    private void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    private void HideGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStartedEvent -= HideMainMenu;
        GameManager.Instance.OnGameStartedEvent -= HideGameOverMenu;
        GameManager.Instance.OnGameEndedEvent -= ShowGameOverMenu;
    }
}