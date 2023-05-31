using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private List<SkinSO> skins;
    [SerializeField] private SkinSlot[] slots;
    private Dictionary<string, SkinSO> _skinDict;
    private string _selectedSkinName;
    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void Awake()
    {
        _skinDict = new(skins.Count);
        foreach (var skin in skins)
        {
            _skinDict.Add(skin.skinName, skin);
        }

        Load();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Init(skins[i]);
            var i1 = i;
            slots[i].GetButton().onClick.AddListener(() => Buy(i1));
        }
    }

    private void SetSkin(SkinSO newSkin)
    {
        _selectedSkinName = newSkin.skinName;
        Save();
    }

    private void Buy(int index)
    {
        if (slots[index].IsUnlocked())
        {
            SetSkin(skins[index]);
        }
        else
        {
            if (_wallet.TrySpend(skins[index].price))
            {
                SetSkin(skins[index]);
                slots[index].Unlock();
                slots[index].UpdateSlot();
            }
        }
    }

    public SkinSO GetSelectedSkin() => _skinDict[_selectedSkinName];

    private void Save()
    {
        PlayerPrefs.SetString("SkinName", _selectedSkinName);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        _selectedSkinName = PlayerPrefs.GetString("SkinName", "Default");
    }
}