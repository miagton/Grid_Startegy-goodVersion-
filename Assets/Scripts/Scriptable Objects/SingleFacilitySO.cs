using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Facility Structure", menuName = "ScriptableObjects/Building/Facility", order = 1)]
public class SingleFacilitySO : SingleStructureBaseSO
{
    public int maxCustomers;
    public int upkeepPerCustomer;

}
