using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private int amount;
    private GameManager _gameManager;
    private int _amount;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += ResetAmount;
        _gameManager.OnStageCompletedEvent += ResetAmount;
        _amount = amount;
    }

    public void SpawnKnife(Vector3 position)
    {
        if (_amount <= 0) return;
        _amount--;
        Instantiate(knifePrefab, position, Quaternion.identity);
    }

    private void ResetAmount() => _amount = amount;
}