using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour {

    public GameObject imagePanel;
    private RobotManager robotManager;

    public Sprite wireSprite;
    public Sprite gearSprite;
    public Sprite batterySprite;

    PlayerInventory playerInventory;

    private Image image;

    private bool ableToCollectThings = true;

    private void Start()
    {
        image = imagePanel.GetComponent<Image>();
    }

    public void PullTrigger(Collider other, string tagName, GameObject thisObject)
    {
        if (other.gameObject.tag == "robot")
        {
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();//gets the robot manager in the collision 

            if (tagName == "wire" && ableToCollectThings)
            {
                playerInventory.Inventory = PlayerInventory.InventoryState.wire;

                image.enabled = true;
                image.sprite = wireSprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }

            if (tagName == "battery" && ableToCollectThings)
            {
                playerInventory.Inventory = PlayerInventory.InventoryState.battery;

                image.enabled = true;
                image.sprite = batterySprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }

            if (tagName == "gear" && ableToCollectThings)
            {
                playerInventory.Inventory = PlayerInventory.InventoryState.gear;

                image.enabled = true;
                image.sprite = gearSprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }
        }
    }
}
