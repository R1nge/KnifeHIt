using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    private const float SpawnPositionY = 3f;

    private void Awake() => GameManager.Instance.OnGameStartedEvent += SpawnLog;

    private void SpawnLog()
    {
        Instantiate(logPrefab, new Vector3(0, SpawnPositionY), Quaternion.identity);
    }

    private void OnDestroy() => GameManager.Instance.OnGameStartedEvent -= SpawnLog;
}