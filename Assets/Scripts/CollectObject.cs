using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour {

    private bool collectedWire;
    private bool collectedGear;
    private bool collectedBattery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            if (this.gameObject.tag == "wire")
            {
                Debug.Log("You collected a wire!");
                collectedWire = true;
                Destroy(gameObject);
            }

            if (this.gameObject.tag == "battery")
            {
                Debug.Log("You collected a battery!");
                collectedBattery = true;
                Destroy(gameObject);
            }

            if (this.gameObject.tag == "gear")
            {
                Debug.Log("You collected a gear!");
                collectedGear = true;
                Destroy(gameObject);
            }
        }
    }
}
