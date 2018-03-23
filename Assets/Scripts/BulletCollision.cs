using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField]
    LayerMask robobMask;

    [SerializeField]
    float lifeTime = 4.0f;

    [SerializeField]
    float hitRadius = 1f;

    private MovePlayer playerMovement;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)//when the laser hits something
    { 
        Collider[] colliders = Physics.OverlapSphere(transform.position, hitRadius, robobMask);//this is a stupid way of doing things and im gonna change it!

        for (int i = 0; i < colliders.Length; i++)//cycles through all collisions in the radius
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)//if there's no rigidbody, go to next iteration of loop
                continue;

            //find the tag and set a bool to true depending on the item it hit.

            Shoot targetStun = targetRigidbody.GetComponent<Shoot>();//finds the stun script on the rigidbody
            playerMovement = targetRigidbody.GetComponent<MovePlayer>();

            if (!targetStun)//if there's no stun script, go to next iteration of loop
                continue;

            Debug.Log("I hit another player!!!");
            StartCoroutine(Stun());//stuns player
            Destroy(gameObject);
            Shoot.fired = false;
        }
    }

    private IEnumerator Stun()
    {
        playerMovement.enabled = false;
        Debug.Log("Stunned");
        yield return new WaitForSeconds(1f);
        playerMovement.enabled = true;
        Debug.Log("Not Stunned");
    }
}
