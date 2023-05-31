using UnityEngine;

public class KnifeVibration : MonoBehaviour
{
    private Knife _knife;

    private void Awake()
    {
        _knife = GetComponent<Knife>();
        _knife.OnHitKnife += Vibrate;
        _knife.OnHit += VibratePeek;
    }

    private void Vibrate() => Vibration.Vibrate();

    private void VibratePeek() => Vibration.VibratePeek();

    private void OnDestroy()
    {
        _knife.OnHitKnife -= Vibrate;
        _knife.OnHit -= VibratePeek;
    }
}