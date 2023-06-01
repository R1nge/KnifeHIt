using UnityEngine.UI;

namespace UI
{
    public class InGameUIView
    {
        private readonly Slider _slider;

        public InGameUIView(Slider slider)
        {
            _slider = slider;
        }

        public void UpdateSliderValue(ref int value)
        {
            _slider.value = value;
        }
    }
}