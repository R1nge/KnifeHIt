using UnityEngine;

public class KnifeSkinUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake() => ChangeSkin();

    private void SetSkin(SkinSO newSkin)
    {
        SkinManager.Instance.SetSkin(newSkin);
        ChangeSkin();
    }

    private void ChangeSkin() => spriteRenderer.sprite = SkinManager.Instance.GetSkin().sprite;
}