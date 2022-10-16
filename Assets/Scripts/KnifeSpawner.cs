using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private int amount;
    private const float SpawnPositionY = -2.5f;
    private int _amount;
    private GameManager _gameManager;
    private InGameUI _inGameUI;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += ResetAmount;
        _gameManager.OnGameStartedEvent += SpawnKnife;
        _amount = amount;
        _inGameUI = FindObjectOfType<InGameUI>();
        _inGameUI.UpdateUI(_amount);
    }

    public void SpawnKnife()
    {
        if (_amount <= 0)
        {
            _gameManager.WinGame();
            return;
        }

        _amount--;
        _inGameUI.UpdateUI(_amount);
        Instantiate(knifePrefab, new Vector3(0, SpawnPositionY), Quaternion.identity);
    }

    private void ResetAmount() => _amount = amount;

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= ResetAmount;
        _gameManager.OnGameStartedEvent -= SpawnKnife;
    }
}