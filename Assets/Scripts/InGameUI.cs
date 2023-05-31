using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private KnifeManager _knifeManager;

    [Inject]
    private void Construct(KnifeManager knifeManager)
    {
        _knifeManager = knifeManager;
    }

    private void Awake() => _knifeManager.OnKnifeSpawned += UpdateUI;

    private void UpdateUI(int amount) => slider.value = amount;

    private void OnDestroy() => _knifeManager.OnKnifeSpawned -= UpdateUI;
}