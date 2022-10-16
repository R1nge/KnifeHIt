using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 60;
        Vibration.Init();
    }

    public event Action OnGameStartedEvent;

    public event Action OnGameOverEvent;

    public event Action OnGameWinEvent;

    public void StartGame() => OnGameStartedEvent?.Invoke();

    public void GameOver() => OnGameOverEvent?.Invoke();

    public void WinGame() => OnGameWinEvent?.Invoke();

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}