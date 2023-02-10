using System;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private int startAmount;
    private const float SpawnPositionY = -2.5f;
    private int _amount;
    private GameManager _gameManager;

    public event Action<int> OnKnifeSpawned;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += ResetAmount;
        _gameManager.OnGameStartedEvent += SpawnKnifeOnGameStarted;
        _amount = startAmount;

        Knife.OnHit += SpawnKnife;
        Knife.OnHit += TryWin;
    }

    private void SpawnKnife()
    {
        _amount--;
        OnKnifeSpawned?.Invoke(_amount);
        if (_amount > 0)
        {
            Instantiate(knifePrefab, new Vector3(0, SpawnPositionY), Quaternion.identity);
        }
    }

    private void TryWin()
    {
        if (_amount <= 0)
        {
            Win();
        }
    }

    private void SpawnKnifeOnGameStarted() =>
        Instantiate(knifePrefab, new Vector3(0, SpawnPositionY), Quaternion.identity);

    private void Win() => _gameManager.WinGame();

    private void ResetAmount() => _amount = startAmount;

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= ResetAmount;
        _gameManager.OnGameStartedEvent -= SpawnKnifeOnGameStarted;
        Knife.OnHit -= SpawnKnife;
        Knife.OnHit -= TryWin;
    }
}