using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector]
    public enum InventoryState { nothing, battery, gear, wire, };//this doesn't really work for player!

    private InventoryState inventory;
    [HideInInspector]
    public InventoryState Inventory { get { return inventory; } set { inventory = value; } }

    [HideInInspector]
    public bool ableToCollectThings;

    private void Start()
    {
        inventory = InventoryState.nothing;//find a way to set this somewhe
    }
}
