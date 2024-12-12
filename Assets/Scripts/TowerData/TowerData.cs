using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    public string TowerName;
    public Sprite Icon;
    
    [Header("Prefabs")]
    public GameObject[] PrefabObjects;

    [Header("Cost")] 
    public int BuyCost;
    public int[] UpgradeCost;


    [Header("Stats")] 
    public float[] Range;

    [Space]
    public float Damage;
    public float FireRate;
}
