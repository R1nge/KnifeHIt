using UnityEngine;
using VContainer;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    private const float SpawnPositionY = 3f;
    private GameManager _gameManager;
    private Transform _log;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Awake() => _gameManager.OnGameStartedEvent += SpawnLog;

    public Transform GetLog() => _log;

    private void SpawnLog() => _log = Instantiate(logPrefab, new(0, SpawnPositionY), Quaternion.identity).transform;

    private void OnDestroy() => _gameManager.OnGameStartedEvent -= SpawnLog;
}