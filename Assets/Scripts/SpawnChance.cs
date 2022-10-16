using UnityEngine;

[CreateAssetMenu(fileName = "SpawnChance", menuName = "SpawnChance")]
public class SpawnChance : ScriptableObject
{
    [Range(0, 100)] public int chance;
}