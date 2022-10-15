using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    public event Action OnGameStartedEvent;
    public event Action OnGameEndedEvent;
    public event Action OnStageCompletedEvent;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Vibration.Init();
    }

    public void StartGame() => OnGameStartedEvent?.Invoke();

    public void EndGame() => OnGameEndedEvent?.Invoke();

    public void NextStage() => OnStageCompletedEvent?.Invoke();
}