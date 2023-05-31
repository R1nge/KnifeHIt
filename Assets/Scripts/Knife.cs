using System;
using UnityEngine;
using VContainer;

public class Knife : MonoBehaviour
{
    private bool _collided;
    private bool _thrown;
    private Rigidbody2D _rigidbody;
    private GameManager _gameManager;

    public event Action OnHitKnife;
    public event Action OnHit;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    public void Throw(float force) => _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_collided) return;

        var target = other.transform;

        if (target.TryGetComponent(out Knife _))
        {
            OnHitKnife?.Invoke();
            _gameManager.GameOver();
            _collided = true;
        }
        else if (target.TryGetComponent(out Log _))
        {
            OnHit?.Invoke();
            transform.parent = target;
            _collided = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Apple apple))
        {
            apple.Collect();
        }
    }
}