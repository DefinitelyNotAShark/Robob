using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private int laserSpeed;

    [SerializeField]
    int playerNumber = 1;

    [SerializeField]
    Rigidbody bulletRbdy;

    string fireButton;
    bool fired; 


	// Use this for initialization
	void Start () {
        fireButton = "Fire" + playerNumber;
        bulletRbdy = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireButton))//is button pressed?
        {
            Fire();
        }
    }

    private void Fire()
    {
        fired = true;
        Rigidbody laserInstance = Instantiate(bulletRbdy, transform.position, transform.rotation) as Rigidbody;
        laserInstance.velocity = transform.forward * laserSpeed * Time.deltaTime;
        //fire the laser beam
        //play laser noise
    }
}
