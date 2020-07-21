using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    private GameObject structureModel = null;
    bool isTaken = false;

    public bool IsTaken { get => isTaken;  }

    public void SetConstruction(GameObject structureModel)
    {
        if (structureModel == null) return;
        else
        {
            this.structureModel = structureModel;
            this.isTaken = true;
        }
      
    }

    public GameObject GetStructure()
    {
        return structureModel;
    }

    public void RemoveStructure()
    {
        structureModel = null;
        isTaken = false;
    }
}
