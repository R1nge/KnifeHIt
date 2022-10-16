using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateUI(int amount) => slider.value = amount;
}