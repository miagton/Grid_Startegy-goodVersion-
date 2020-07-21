using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StructureRepository : MonoBehaviour
{
    public CollectionSO modelDataCollection;

    public List<string> GetZonesNames()
    {
        return modelDataCollection.zoneStructuresList.Select(zone => zone.buildingName).ToList();
    }

    public List<string> GetSingleStructureNames()
    {
        return modelDataCollection.singleStructuresList.Select(facility => facility.buildingName).ToList();
    }

    public string GetRoadStructureName()
    {
        return modelDataCollection.roadStructureSO.buildingName;
    }
}
