using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    //needs to spawn in spawnpoints
    //needs to rotate after been spawned
    //needs to be able to be collected
    //needs to destroy once collected


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        System.Console.Write("YOU FUCKIN HIT IT BRAH");
        Destroy(this);
    }
}
