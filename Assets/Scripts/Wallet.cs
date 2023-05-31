using System;
using UnityEngine;
using VContainer.Unity;

public class Wallet : IInitializable
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

    public event Action<int> OnMoneyChanged;

    public void Initialize() => Money = PlayerPrefs.GetInt("Money", 0);

    public void Earn(int amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(_money);
        Save();
    }

    public bool TrySpend(int amount)
    {
        if ((Money -= amount) < 0) return false;
        OnMoneyChanged?.Invoke(_money);
        Save();
        return true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Money", _money);
        PlayerPrefs.Save();
    }
}