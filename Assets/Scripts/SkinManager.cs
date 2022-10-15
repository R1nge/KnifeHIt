using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private SkinSO skin;

    //TODO: Save skin
    private void Awake() => Load();

    public void SetSkin(SkinSO newSkin) => skin = newSkin;

    public SkinSO GetSkin() => skin;

    private void Save()
    {
    }

    private void Load()
    {
    }
}