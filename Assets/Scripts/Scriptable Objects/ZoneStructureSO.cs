using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zone Structure", menuName = "ScriptableObjects/Building/ZoneStructure", order = 1)]
public class ZoneStructureSO : StructureBaseSO
{
    public GameObject[] prefabVariants;
    public bool isUpgradable;
    public UpgradeType[] avaibleUpgrades;
    public ZoneType zoneType;
}

public enum ZoneType
{
    Residential,
    Commercial,
    Agricultural,
    Factory
}
[System.Serializable]
public struct UpgradeType
{
    public GameObject[] prefabVAriants;
    public int happinesTreshhold, newIncome, newUpkeep;

}
