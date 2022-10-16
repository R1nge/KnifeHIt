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

    private bool _gameEnded;

    public event Action OnGameStartedEvent;

    public event Action OnGameOverEvent;

    public event Action OnGameWinEvent;

    public void StartGame() => OnGameStartedEvent?.Invoke();

    public void GameOver()
    {
        if (_gameEnded) return;
        OnGameOverEvent?.Invoke();
        _gameEnded = true;
    }

    public void WinGame()
    {
        if (_gameEnded) return;
        OnGameWinEvent?.Invoke();
        _gameEnded = true;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}