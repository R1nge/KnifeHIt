using UnityEngine;
using VContainer;

public class KnifeSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private SkinManager _skinManager;

    [Inject]
    private void Construct(SkinManager skinManager)
    {
        _skinManager = skinManager;
    }

    private void Start() => ChangeSkin();

    private void ChangeSkin() => spriteRenderer.sprite = _skinManager.GetSelectedSkin().sprite;
}