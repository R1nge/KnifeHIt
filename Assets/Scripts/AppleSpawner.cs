using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private SpawnChance spawnChance;
    private GameManager _gameManager;
    private Transform _log;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStartedEvent += OnGameStarted;
    }

    private void OnGameStarted()
    {
        while (_log == null)
        {
            _log = FindObjectOfType<Log>().transform;
        }

        if (Random.Range(0, 100) <= spawnChance.chance)
        {
            Spawn(_log, 1.25f);
        }
    }

    private void Spawn(Transform origin, float radius)
    {
        var instance = Instantiate(applePrefab,
            RandomCirclePosition(origin.position, radius),
            Quaternion.identity);

        Vector3 dir = instance.transform.position - origin.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        instance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        instance.transform.parent = origin;
    }

    private Vector2 RandomCirclePosition(Vector2 center, float radius)
    {
        float ang = Random.value * 360;
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