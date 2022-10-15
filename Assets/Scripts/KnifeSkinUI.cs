using UnityEngine;

public class KnifeSkinUI : MonoBehaviour
{
    [SerializeField] private SkinSO skin;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake() => SetSkin(skin);

    public void SetSkin(SkinSO newSkin)
    {
        skin = newSkin;
        spriteRenderer.sprite = skin.sprite;
    }
}