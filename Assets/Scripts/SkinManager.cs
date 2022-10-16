using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private List<SkinSO> skins;
    private int _index;

    private void Awake() => Load();

    public void SetSkin(SkinSO newSkin)
    {
        for (int i = 0; i < skins.Count; i++)
        {
            if (skins[i] == newSkin)
            {
                _index = i;
                break;
            }
        }

        Save();
    }

    public SkinSO GetSkin() => skins[_index];

    private void Save()
    {
        PlayerPrefs.SetInt("Index", _index);
        PlayerPrefs.Save();
    }

    private void Load() => _index = PlayerPrefs.GetInt("Index", 0);
}