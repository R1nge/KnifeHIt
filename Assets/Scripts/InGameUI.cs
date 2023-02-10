using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private KnifeSpawner _knifeSpawner;

    private void Awake()
    {
        _knifeSpawner = FindObjectOfType<KnifeSpawner>();
        _knifeSpawner.OnKnifeSpawned += UpdateUI;
    }

    private void UpdateUI(int amount) => slider.value = amount;

    private void OnDestroy() => _knifeSpawner.OnKnifeSpawned -= UpdateUI;
}