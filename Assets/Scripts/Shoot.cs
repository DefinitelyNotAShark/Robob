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
    private float currentLaunchForce;
    public static  bool fired;

    //private GameObject[] robobChildren;// maybe if i need to ignore the collision

    string fireButton;

	// Use this for initialization
	void Start () {
        fireButton = "Fire" + playerNumber;
        Physics.IgnoreCollision(bulletRbdy.GetComponent<Collider>(), GetComponent<Collider>());
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
        Rigidbody laserInstance = Instantiate(bulletRbdy, spawnLaser.position, spawnLaser.rotation) as Rigidbody;//its' not this that is being the bitch

        laserInstance.velocity = GetComponentInParent<Transform>().forward * laserSpeed * Time.deltaTime;
    }
}
