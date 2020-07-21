using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    [SerializeField] GameObject buildingPrefab;
    [SerializeField] Transform ground;




    public void CreateBuilding(Vector3 gridPosition,GridStructure grid)
    {
        GameObject newStructure=  Instantiate(buildingPrefab,ground.position+ gridPosition, Quaternion.identity);//adding ground to recieve same result whatever ground pos is
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
    }
    public void RemoveBuilding(Vector3 gridPosition,GridStructure grid)
    {
      var structure =  grid.GetStructureFromGrid(gridPosition);
        if (structure != null)
        {
            Destroy(structure);
            grid.RemoveStructureFromGrid(gridPosition);
        }

    }
}
