using UnityEngine;

public class KnifeSound : MonoBehaviour
{
    [SerializeField] private AudioSource hit, knifeHit;
    private Knife _knife;

    private void Awake()
    {
        _knife = GetComponent<Knife>();
        _knife.OnHit += PlayHitSound;
        _knife.OnHitKnife += PlayHitKnifeSound;
    }

    private void PlayHitSound() => hit.Play();

    private void PlayHitKnifeSound() => knifeHit.Play();

    private void OnDestroy()
    {
        _knife.OnHit -= PlayHitSound;
        _knife.OnHitKnife -= PlayHitKnifeSound;
    }
}