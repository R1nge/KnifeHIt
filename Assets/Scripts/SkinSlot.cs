using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    [SerializeField] private SkinSO skin;
    private Image _image;
    private SkinManager _skinManager;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = skin.sprite;
        _skinManager = FindObjectOfType<SkinManager>();
    }

    public void SetSkin() => _skinManager.SetSkin(skin);
}