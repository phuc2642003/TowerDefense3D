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
    public float[] Ranges;
    public float[] Damages;
    public float[] FireRates;

    [Header("Additional Stats")]
    public float RotationSpeed;
}
