using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    public string TowerName;
    
    [Header("Prefabs")]
    public GameObject Level1Prefab;
    public GameObject Level2Prefab;
    public GameObject Level3Prefab;

    [Header("Cost")] 
    public int BuyCost;
    public int UpgradeCost1;
    public int UpgradeCost2;

    [Header("Stats")] 
    public float Level1Range;
    public float Level2Range;
    public float Level3Range;

    [Space]
    public float Damage;
    public float FireRate;
}
