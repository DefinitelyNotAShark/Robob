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

    [SerializeField]
    Transform spawnLaser;

    string fireButton;
    public static  bool fired;


	// Use this for initialization
	void Start () {
        fireButton = "Fire" + playerNumber;
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
        Rigidbody laserInstance = Instantiate(bulletRbdy, spawnLaser.position, spawnLaser.rotation) as Rigidbody;
        laserInstance.velocity = spawnLaser.forward * laserSpeed * Time.deltaTime;
    }
}
