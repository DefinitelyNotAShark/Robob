using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            Debug.Log("You got the tag working, congrats!!!");
            Destroy(gameObject);
        }
    }
}
