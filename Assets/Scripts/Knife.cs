using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float force;
    private KnifeSpawner _spawner;
    private Rigidbody2D _rigidbody2D;
    private bool _collided;
    private bool _thrown;
    private bool _cantThrow;
    private GameManager _gameManager;
    private SoundManager _soundManager;

    private void Awake()
    {
        _spawner = FindObjectOfType<KnifeSpawner>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameOverEvent += delegate { _cantThrow = true; };
        _soundManager = FindObjectOfType<SoundManager>();
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

        _spawner.SpawnKnife();

        var target = other.transform;

        if (target.TryGetComponent(out Knife knife))
        {
            _gameManager.GameOver();
            _soundManager.PlayKnifeHitSound();
            Vibration.Vibrate();
            _collided = true;
        }
        else if (target.TryGetComponent(out Log log))
        {
            transform.parent = target;
            _soundManager.PlayHitSound();
            Vibration.VibratePeek();
            _collided = true;
        }
    }

    private void Update()
    {
        if (_thrown || _collided || _cantThrow) return;
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
            _thrown = true;
        }
    }

    private void Throw() => _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
}