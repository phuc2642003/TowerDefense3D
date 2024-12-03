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
    public float BuyCost;
    public float UpgradeCost1;
    public float UpgradeCost2;

    [Header("Stats")] 
    public float Level1Range;
    public float Level2Range;
    public float Level3Range;

    [Space]
    public float Damage;
    public float FireRate;
}
