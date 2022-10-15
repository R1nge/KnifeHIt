using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private int amount;
    private const float SpawnPositionY = -2.5f;
    private GameManager _gameManager;
    private int _amount;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += ResetAmount;
        _gameManager.OnGameStartedEvent += SpawnKnife;
        _gameManager.OnStageCompletedEvent += ResetAmount;
        _gameManager.OnStageCompletedEvent += SpawnKnife;
        _amount = amount;
    }

    public void SpawnKnife()
    {
        if (_amount <= 0) return;
        _amount--;
        Instantiate(knifePrefab, new Vector3(0, SpawnPositionY, 0), Quaternion.identity);
    }

    private void ResetAmount() => _amount = amount;

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= ResetAmount;
        _gameManager.OnGameStartedEvent -= SpawnKnife;
        _gameManager.OnStageCompletedEvent -= ResetAmount;
        _gameManager.OnStageCompletedEvent -= SpawnKnife;
    }
}