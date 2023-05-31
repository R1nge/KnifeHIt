using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skin")]
public class SkinSO : ScriptableObject
{
    public string skinName;
    public Sprite sprite;
    public int price;
}