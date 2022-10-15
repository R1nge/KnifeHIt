using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Money
    {
        get => _money;
        private set
        {
            _money = value;
            Save();
        }
    }

    private int _money;

    private void Awake() => Money = PlayerPrefs.GetInt("Money", 0);

    public void Earn(int amount) => Money += amount;

    public bool Spend(int amount) => (_money -= amount) >= 0;

    private void Save() => PlayerPrefs.SetInt("Money", Money);
}