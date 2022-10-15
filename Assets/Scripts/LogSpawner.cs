using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    private const float SpawnPositionY = 3f;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += SpawnLog;
    }

    private void SpawnLog()
    {
        Instantiate(logPrefab, new Vector3(0, SpawnPositionY), Quaternion.identity);
    }

    private void OnDestroy() => _gameManager.OnGameStartedEvent -= SpawnLog;
}