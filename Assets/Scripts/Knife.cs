using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float force;
    private KnifeSpawner _spawner;
    private Rigidbody2D _rigidbody2D;
    private bool _collided;

    private void Awake()
    {
        _spawner = FindObjectOfType<KnifeSpawner>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) => Collide(other);

    private void Collide(Collision2D other)
    {
        if (_collided) return;

        _spawner.SpawnKnife();

        var target = other.transform;

        if (target.TryGetComponent(out Knife knife))
        {
            GameManager.Instance.EndGame();
            Vibration.Vibrate();
        }
        else if (target.TryGetComponent(out Log log))
        {
            transform.parent = target;
            Vibration.VibratePeek();
        }

        _collided = true;
    }

    private void OnMouseDown() => Throw();

    private void Throw() => _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
}