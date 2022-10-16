using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TODO: Add stages, loot boxes
    public void Awake()
    {
        Application.targetFrameRate = 60;
        Vibration.Init();
    }

    public event Action OnGameStartedEvent;

    public event Action OnGameEndedEvent;

    public event Action OnStageCompletedEvent;

    public void StartGame() => OnGameStartedEvent?.Invoke();

    public void EndGame() => OnGameEndedEvent?.Invoke();

    public void NextStage() => OnStageCompletedEvent?.Invoke();

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}