using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour {

    public Sprite wireSprite;
    public Sprite gearSprite;
    public Sprite batterySprite;

    PlayerInventory playerInventory;
    SetUIForPlayers setUI;

    private void Start()
    {
        
    }

    public void PullTrigger(Collider other, string tagName, GameObject thisObject)
    {
        playerInventory = other.gameObject.GetComponent<PlayerInventory>();//gets the robot manager in the collision 
        setUI = other.gameObject.GetComponent<SetUIForPlayers>();

        if (tagName == "wire" && playerInventory.ableToCollectThings)
        {
            setUI.ChangeImageToItem(wireSprite);
            playerInventory.Inventory = PlayerInventory.InventoryState.wire;
            playerInventory.ableToCollectThings = false;
            Destroy(thisObject);
        }

        if (tagName == "battery" && playerInventory.ableToCollectThings)
        {
            playerInventory.Inventory = PlayerInventory.InventoryState.battery;
            setUI.ChangeImageToItem(batterySprite);
            playerInventory.ableToCollectThings = false;
            Destroy(thisObject);
        }

        if (tagName == "gear" && playerInventory.ableToCollectThings)
        {
            playerInventory.Inventory = PlayerInventory.InventoryState.gear;
            setUI.ChangeImageToItem(gearSprite);
            playerInventory.ableToCollectThings = false;
            Destroy(thisObject);
        }

    }
}
