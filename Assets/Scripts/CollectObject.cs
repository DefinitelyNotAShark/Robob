using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour {

    [SerializeField]
    private GameObject iconSpawnPoint;

    private bool collectedWire = false;
    private bool collectedGear = false;
    private bool collectedBattery = false;
    private bool ableToCollectThings = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            if (this.gameObject.tag == "wire")
            {
                Debug.Log("You collected a wire!");
                collectedWire = true;
                ableToCollectThings = false;
                Destroy(gameObject);
            }

            if (this.gameObject.tag == "battery")
            {
                Debug.Log("You collected a battery!");
                collectedBattery = true;
                ableToCollectThings = false;
                Destroy(gameObject);
            }

            if (this.gameObject.tag == "gear")
            {
                Debug.Log("You collected a gear!");
                collectedGear = true;
                ableToCollectThings = false;
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        CheckIfCollectedObject();
    }

    private void CheckIfCollectedObject()
    {
        if (collectedWire && ableToCollectThings)
            ShowIcon(collectedWire);

        if (collectedGear && ableToCollectThings)
            ShowIcon(collectedGear);

        if (collectedBattery && ableToCollectThings)
            ShowIcon(collectedBattery);
    }

    private void ShowIcon(bool itemCollected)
    {
        if(itemCollected == collectedWire)
        {

        }
    }
}
