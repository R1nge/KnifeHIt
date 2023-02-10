using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource hit, knifeHit;

    private void Awake()
    {
        Knife.OnHit += PlayHitSound;
        Knife.OnHitKnife += PlayHitKnifeSound;
    }

    private void PlayHitSound() => hit.Play();

    private void PlayHitKnifeSound() => knifeHit.Play();

    private void OnDestroy()
    {
        Knife.OnHit -= PlayHitSound;
        Knife.OnHitKnife -= PlayHitKnifeSound;
    }
}