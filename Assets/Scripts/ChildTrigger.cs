using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour {

    private string tagName;
    GameObject thisObject;

    private void Start()
    {
        tagName = this.tag.ToString();
        thisObject = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You have collided with " + other.name.ToString());
        gameObject.GetComponentInParent<CollectObject>().PullTrigger(other, this.tagName, thisObject);
    }
}
