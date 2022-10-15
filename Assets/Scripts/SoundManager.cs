using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource hit, knifeHit;

    public void PlayHitSound() => hit.Play();

    public void PlayKnifeHitSound() => knifeHit.Play();
}