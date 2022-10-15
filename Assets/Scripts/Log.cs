using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update() => transform.Rotate(Vector3.forward * speed);
}