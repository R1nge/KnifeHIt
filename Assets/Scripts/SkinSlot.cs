using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    private bool _isUnlocked;
    private SkinSO _skin;

    public void Init(SkinSO skin) => _skin = skin;

    private void Awake() => Load();

    private void Start() => UpdateSlot();

    public void UpdateSlot()
    {
        image.sprite = _skin.sprite;
        if (_isUnlocked)
        {
            price.gameObject.SetActive(false);
        }
        else
        {
            price.gameObject.SetActive(true);
            price.text = _skin.price != 0 ? _skin.price.ToString() : String.Empty;
        }
    }

    public void Unlock() => _isUnlocked = true;
    
    public bool IsUnlocked() => _isUnlocked;

    public Button GetButton() => button;

    private void Save()
    {
        PlayerPrefs.SetInt(_skin.skinName, _isUnlocked ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void Load() => _isUnlocked = PlayerPrefs.GetInt(_skin.skinName) == 1;

    private void OnDisable() => Save();
}