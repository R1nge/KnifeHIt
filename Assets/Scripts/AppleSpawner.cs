using UnityEngine;
using VContainer;
using VContainer.Unity;

[RequireComponent(typeof(LogSpawner))]
public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private SpawnChance spawnChance;
    private IObjectResolver _objectResolver;
    private GameManager _gameManager;
    private LogSpawner _logSpawner;

    [Inject]
    private void Construct(IObjectResolver objectResolver, GameManager gameManager)
    {
        _objectResolver = objectResolver;
        _gameManager = gameManager;
    }

    private void Awake()
    {
        _logSpawner = GetComponent<LogSpawner>();
    }

    private void Start() => _gameManager.OnGameStartedEvent += OnGameStarted;

    private void OnGameStarted()
    {
        if (Random.Range(0, 100) <= spawnChance.chance)
        {
            Spawn(_logSpawner.GetLog(), 1.25f);
        }
    }

    private void Spawn(Transform origin, float radius)
    {
        var instance = _objectResolver.Instantiate(applePrefab,
            RandomCirclePosition(origin.position, radius),
            Quaternion.identity);

        var dir = instance.transform.position - origin.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        instance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        instance.transform.parent = origin;
    }

    private Vector2 RandomCirclePosition(Vector2 center, float radius)
    {
        var ang = Random.value * 360;
        Vector2 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

    private void OnDestroy()
    {
        _gameManager.OnGameStartedEvent -= OnGameStarted;
    }
}