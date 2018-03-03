using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private int laserSpeed;


    [SerializeField]
    Rigidbody bulletRbdy;

    [SerializeField]
    Transform spawnLaser;

    public int playerNumber = 1;
    public static  bool fired;

    string fireButton;

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
