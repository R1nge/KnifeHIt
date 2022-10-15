using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private SkinSO skin;
    
    public void SetSkin(SkinSO newSkin) => skin = newSkin;

    public SkinSO GetSkin() => skin;
}