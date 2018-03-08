using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObject : MonoBehaviour {

    public GameObject imagePanel;

    public Sprite wireSprite;
    public Sprite gearSprite;
    public Sprite batterySprite;

    private Image image;

    private bool collectedWire = false;
    private bool collectedGear = false;
    private bool collectedBattery = false;
    private bool ableToCollectThings = true;

    private void Start()
    {
        image = imagePanel.GetComponent<Image>();
    }

    public void PullTrigger(Collider other, string tagName, GameObject thisObject)
    {
        if (other.gameObject.tag == "robot")
        {
            if (tagName == "wire" && ableToCollectThings)
            {
                Debug.Log("You collected a wire!");
                collectedWire = true;
                image.sprite = wireSprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }

            if (tagName == "battery" && ableToCollectThings)
            {
                Debug.Log("You collected a battery!");
                collectedBattery = true;
                image.sprite = batterySprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }

            if (tagName == "gear" && ableToCollectThings)
            {
                Debug.Log("You collected a gear!");
                collectedGear = true;
                image.sprite = gearSprite;
                ableToCollectThings = false;
                Destroy(thisObject);
            }
        }
    }
}
