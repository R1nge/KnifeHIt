using UnityEngine;

public class VibrationController : MonoBehaviour
{
    private void Awake()
    {
        Knife.OnHitKnife += Vibrate;
        Knife.OnHit += VibratePeek;
    }

    private void Vibrate() => Vibration.Vibrate();

    private void VibratePeek() => Vibration.VibratePeek();

    private void OnDestroy()
    {
        Knife.OnHitKnife -= Vibrate;
        Knife.OnHit -= VibratePeek;
    }
}