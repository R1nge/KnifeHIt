using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private SkinSO skin;
    private static SkinManager _instance;

    public static SkinManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SkinManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<SkinManager>();
                }
            }

            return _instance;
        }
    }

    public void SetSkin(SkinSO newSkin) => skin = newSkin;

    public SkinSO GetSkin() => skin;
}