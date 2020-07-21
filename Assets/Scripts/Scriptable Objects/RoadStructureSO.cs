using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Road", menuName = "ScriptableObjects/Building/Road", order = 1)]
public class RoadStructureSO : StructureBaseSO
{
    [Tooltip("Road facing Up and Right")]
    public GameObject cornerPrefab;
    [Tooltip("Road facing Up , Right, Down")]
    public GameObject threeWayPrefab;
    public GameObject fourwayPRefab;
}
