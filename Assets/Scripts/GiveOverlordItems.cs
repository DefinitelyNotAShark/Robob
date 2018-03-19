using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveOverlordItems : MonoBehaviour {

    enum ItemWantedState {battery, gear, wire};
    public Sprite[] sprites;
    public Image spriteCanvas;
    private ItemWantedState itemState;
    private int itemNum;

    private RobotManager robotManager;

	// Use this for initialization
	void Start () {
        spriteCanvas = GetComponentInChildren<Image>();//this works now!
        spriteCanvas.enabled = false;
        StartCoroutine(BufferTimeBetweenChoosingItems());//wait 1 sec and then show item to get!
	}

    IEnumerator BufferTimeBetweenChoosingItems()
    {
        spriteCanvas.enabled = false;
        yield return new WaitForSeconds(1);
        ChooseRandomItem();
        spriteCanvas.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CheckIfItemMatches(collision))//if the player is carrying the right item, change item to ask for 
        {
            CheckPlayerNumberToAssignPoints(collision);
            StartCoroutine(BufferTimeBetweenChoosingItems());
        }
    }


    private void ChooseRandomItem()//returns random state
    {
        System.Random r = new System.Random();
        itemNum = r.Next(0, 3);
        switch (itemNum)
        {
            case 0:
                itemState = ItemWantedState.battery;
                spriteCanvas.sprite = sprites[itemNum];
                break;
            case 1:
                itemState = ItemWantedState.gear;
                spriteCanvas.sprite = sprites[itemNum];
                break;
            case 2:
                itemState = ItemWantedState.wire;
                spriteCanvas.sprite = sprites[itemNum];
                break;
        }
    }

    private bool CheckIfItemMatches(Collision collision)
    {
        if (collision.gameObject.tag == "robot")
        {
            return true;
        }
        //else be false
        return false;
    }

    private void CheckPlayerNumberToAssignPoints(Collision collision)
    {
        robotManager = collision.gameObject.GetComponent<RobotManager>();//get the player's robot manager script
        if (robotManager.playerNumber == 1)//if player 1 collides
        {
            Debug.Log("Player 1 has " + robotManager.points);
            robotManager.points++;
        }
        else if (robotManager.playerNumber == 2)
        {
            Debug.Log("Player 2 has " + robotManager.points);
            robotManager.points++;
        }
    }
}
