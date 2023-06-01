using UnityEngine;
using VContainer;

namespace UI
{
    public class InGameUIController : MonoBehaviour
    {
        [SerializeField] private InGameUIModel inGameUIModel;
        private InGameUIView _inGameUIView;
        private KnifeManager _knifeManager;

        [Inject]
        private void Construct(KnifeManager knifeManager)
        {
            _knifeManager = knifeManager;
        }

        private void Awake()
        {
            _knifeManager.OnKnifeSpawned += UpdateSliderValue;
            _inGameUIView = new(inGameUIModel.slider);
        }

        private void UpdateSliderValue(int amount) => _inGameUIView.UpdateSliderValue(ref amount);

        private void OnDestroy() => _knifeManager.OnKnifeSpawned -= UpdateSliderValue;
    }
}