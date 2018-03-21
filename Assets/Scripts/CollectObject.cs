using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour {

    [SerializeField]
    private RectTransform imagePanel;

    public Sprite wireSprite;
    public Sprite gearSprite;
    public Sprite batterySprite;

    PlayerInventory playerInventory;

    private Image image;

    private bool ableToCollectThings = true;

    private void Start()
    {
        image = imagePanel.GetComponentInChildren<Image>();
    }

    public void PullTrigger(Collider other, string tagName, GameObject thisObject)
    {
        playerInventory = other.gameObject.GetComponent<PlayerInventory>();//gets the robot manager in the collision 

        if (tagName == "wire" && playerInventory.ableToCollectThings)
        {
            playerInventory.Inventory = PlayerInventory.InventoryState.wire;

            image.enabled = true;
            image.sprite = wireSprite;
            playerInventory.ableToCollectThings = false;
            Destroy(thisObject);
        }

        if (tagName == "battery" && playerInventory.ableToCollectThings)
        {
            playerInventory.Inventory = PlayerInventory.InventoryState.battery;

            image.enabled = true;
            image.sprite = batterySprite;
            playerInventory.ableToCollectThings = false;
            Destroy(thisObject);
        }

        if (tagName == "gear" && ableToCollectThings)
        {
            playerInventory.Inventory = PlayerInventory.InventoryState.gear;

            image.enabled = true;
            image.sprite = gearSprite;
            playerInventory.ableToCollectThings = false;
            Destroy(thisObject);
        }

    }
}
