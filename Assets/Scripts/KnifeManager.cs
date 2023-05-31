using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private Knife knifePrefab;
    [SerializeField] private int startAmount;
    [SerializeField] private float throwForce;
    private readonly Vector3 _spawnPosition = new(0, -2.5f, 0);
    private int _amount;
    private IObjectResolver _objectResolver;
    private GameManager _gameManager;
    private List<Knife> _knives;
    private bool _initialized;
    private bool _canThrow = true;

    public event Action<int> OnKnifeSpawned;

    [Inject]
    private void Construct(IObjectResolver objectResolver, GameManager gameManager)
    {
        _objectResolver = objectResolver;
        _gameManager = gameManager;
    }

    private void Awake() => _gameManager.OnGameStartedEvent += Init;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _initialized && _canThrow)
        {
            ThrowKnife();
        }
    }

    private void Init()
    {
        _knives = new(startAmount);
        _amount = startAmount;

        for (var i = 0; i < startAmount; i++)
        {
            var knife = _objectResolver.Instantiate(knifePrefab, _spawnPosition, quaternion.identity);
            _knives.Add(knife);
        }

        for (var i = 0; i < startAmount; i++)
        {
            _knives[i].OnHit += GetKnife;
        }

        for (var i = 1; i < startAmount; i++)
        {
            _knives[i].gameObject.SetActive(false);
        }

        _initialized = true;
    }

    private void ThrowKnife()
    {
        if (_amount > 0)
        {
            _knives[0].Throw(throwForce);
            _amount--;
            _canThrow = false;
        }
    }

    private void GetKnife()
    {
        OnKnifeSpawned?.Invoke(_amount);
        if (_amount > 0)
        {
            _knives[0].OnHit -= GetKnife;
            _knives.RemoveAt(0);
            _knives[0].gameObject.SetActive(true);
            _canThrow = true;
        }
        else
        {
            TryWin();
        }
    }

    private void TryWin()
    {
        if (_amount == 0)
        {
            _gameManager.WinGame();
        }
    }

    private void OnDestroy() => _gameManager.OnGameStartedEvent -= Init;
}