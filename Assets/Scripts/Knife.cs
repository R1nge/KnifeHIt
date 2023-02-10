using System;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody2D _rigidbody2D;
    private bool _collided;
    private bool _thrown;
    private bool _canThrow = true;
    private GameManager _gameManager;

    public static event Action OnHitKnife;
    public static event Action OnHit;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameOverEvent += delegate { _canThrow = false; };
    }

    private void OnCollisionEnter2D(Collision2D other) => Collide(other);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out Apple apple))
        {
            apple.Collect();
        }
    }

    private void Collide(Collision2D other)
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

    private void Update()
    {
        if (_thrown || _collided || !_canThrow) return;
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
            _thrown = true;
        }
    }

    private void Throw() => _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
}