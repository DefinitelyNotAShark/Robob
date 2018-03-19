using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour {

    public GameObject imagePanel;

    [HideInInspector]
    public enum InventoryState { nothing, battery, gear, wire };

    private InventoryState inventory;

    [HideInInspector]
    public InventoryState Inventory
    {
        get
        {
            return inventory;
        }
        private set
        {
            inventory = value;
        }
    } 

    public Sprite wireSprite;
    public Sprite gearSprite;
    public Sprite batterySprite;

    private Image image;

    private bool ableToCollectThings = true;

    private void Start()
    {
        inventory = InventoryState.nothing;
        image = imagePanel.GetComponent<Image>();
    }

    public void PullTrigger(Collider other, string tagName, GameObject thisObject)
    {
        if (other.gameObject.tag == "robot")
        {
            if (tagName == "wire" && ableToCollectThings)
            {
                Debug.Log("You collected a wire!");
                inventory = InventoryState.wire;
                image.enabled = true;
                image.sprite = wireSprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }

            if (tagName == "battery" && ableToCollectThings)
            {
                Debug.Log("You collected a battery!");
                inventory = InventoryState.battery;
                image.enabled = true;
                image.sprite = batterySprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }

            if (tagName == "gear" && ableToCollectThings)
            {
                Debug.Log("You collected a gear!");
                inventory = InventoryState.gear;
                image.enabled = true;
                image.sprite = gearSprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }
        }
    }
}
