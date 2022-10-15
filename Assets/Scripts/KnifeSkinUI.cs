using UnityEngine;

public class KnifeSkinUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private SkinManager _skinManager;
    private void Awake()
    {
        _skinManager = FindObjectOfType<SkinManager>();
        ChangeSkin();
    }

    private void ChangeSkin() => spriteRenderer.sprite = _skinManager.GetSkin().sprite;
}