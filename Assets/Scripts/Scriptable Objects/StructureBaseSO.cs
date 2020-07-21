using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public abstract class StructureBaseSO :ScriptableObject
{
    public string buildingName;
    [SerializeField] GameObject buildingPrefab;
    public int placamentCost;
    public int upkeepCost;
    public int income;

    public bool requireWater, requireRoad, requirePower;
}
