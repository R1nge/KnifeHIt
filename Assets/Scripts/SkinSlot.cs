using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    [SerializeField] private SkinSO skin;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private bool unlocked;
    private Image _image;
    private Wallet _wallet;
    private SkinManager _skinManager;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = skin.sprite;
        _wallet = FindObjectOfType<Wallet>();
        _skinManager = FindObjectOfType<SkinManager>();
        Load();
    }

    private void Start() => SetPrice();

    private void SetPrice()
    {
        if (unlocked)
        {
            price.gameObject.SetActive(false);
        }
        else
        {
            price.gameObject.SetActive(true);
            price.text = skin.price.ToString();
        }
    }

    private void SetSkin() => _skinManager.SetSkin(skin);

    public void Buy()
    {
        if (unlocked)
        {
            SetSkin();
        }
        else
        {
            if (_wallet.Spend(skin.price))
            {
                SetSkin();
                unlocked = true;
            }
        }

        SetPrice();
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(skin.name, unlocked ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void Load() => unlocked = PlayerPrefs.GetInt(skin.name, 0) == 1;
}