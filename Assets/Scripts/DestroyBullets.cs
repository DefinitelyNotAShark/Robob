using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour {

    [SerializeField]
    LayerMask robobMask;

    [SerializeField]
    ParticleSystem laserZap;

    [SerializeField]
    float lifeTime = 2.0f;

    [SerializeField]
    float hitRadius = 1f;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, lifeTime);
	}

    private void OnTriggerEnter(Collider other)//when the laser hits something
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, hitRadius, robobMask);

        for(int i = 0; i < colliders.Length; i++)//cycles through all collisions in the radius
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)//if there's no rigidbody, go to next iteration of loop
                continue;

            StunRobob targetStun = targetRigidbody.GetComponent<StunRobob>();//finds the stun script on the rigidbody

            if (!targetStun)//if there's no stun script, go to next iteration of loop
                continue;

            targetStun.Stun();//stuns player
            Destroy(laserZap.gameObject, laserZap.main.duration);//destroys particles after animation finishes
            Destroy(gameObject);
            Shoot.fired = false;
        }
    }
}
