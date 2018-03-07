using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField]
    LayerMask robobMask;

    [SerializeField]
    ParticleSystem laserZap;

    [SerializeField]
    float lifeTime = 2.0f;

    [SerializeField]
    float hitRadius = 1f;

    private MovePlayer playerMovement;

    // Use this for initialization
    void Start()
    {
        laserZap.Stop();
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)//when the laser hits something
    { 
        Collider[] colliders = Physics.OverlapSphere(transform.position, hitRadius, robobMask);

        for (int i = 0; i < colliders.Length; i++)//cycles through all collisions in the radius
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)//if there's no rigidbody, go to next iteration of loop
                continue;

            //find the tag and set a bool to true depending on the item it hit.

            Shoot targetStun = targetRigidbody.GetComponent<Shoot>();//finds the stun script on the rigidbody

            if (!targetStun)//if there's no stun script, go to next iteration of loop
                continue;

            Debug.Log("I hit another player!!!");
            StartCoroutine("Stun");//stuns player
            Destroy(laserZap.gameObject, laserZap.main.duration);//destroys particles after animation finishes
            Destroy(gameObject);
            Shoot.fired = false;
        }
    }

    private IEnumerator Stun()
    {
        laserZap.Play();
        playerMovement.enabled = false;
        Debug.Log("Stunned");
        yield return new WaitForSeconds(3f);
        playerMovement.enabled = true;
        Debug.Log("Not Stunned");
    }
}
