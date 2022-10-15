using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private int amount;
    private const float SpawnPositionY = -2.5f;
    private int _amount;

    private void Awake()
    {
        GameManager.Instance.OnGameStartedEvent += ResetAmount;
        GameManager.Instance.OnGameStartedEvent += SpawnKnife;
        GameManager.Instance.OnStageCompletedEvent += ResetAmount;
        GameManager.Instance.OnStageCompletedEvent += SpawnKnife;
        _amount = amount;
    }

    public void SpawnKnife()
    {
        if (_amount <= 0) return;
        _amount--;
        Instantiate(knifePrefab, new Vector3(0, SpawnPositionY), Quaternion.identity);
    }

    private void ResetAmount() => _amount = amount;

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStartedEvent -= ResetAmount;
        GameManager.Instance.OnGameStartedEvent -= SpawnKnife;
        GameManager.Instance.OnStageCompletedEvent -= ResetAmount;
        GameManager.Instance.OnStageCompletedEvent -= SpawnKnife;
    }
}