using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Collection", menuName = "ScriptableObjects/Building/CollectionSO", order = 1)]
public class CollectionSO : ScriptableObject
{
    public RoadStructureSO roadStructureSO;
    public List<SingleStructureBaseSO> singleStructuresList;
    public List<ZoneStructureSO> zoneStructuresList;
}
