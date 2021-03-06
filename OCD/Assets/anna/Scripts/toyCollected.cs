﻿//made by anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toyCollected : MonoBehaviour
{
    public ScoreManager score;//takes in link to score manager
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "toy") //if object which trigger is tagged as toy
        {
            Destroy(other.gameObject); //destory toy

            PickUp pickUp = other.gameObject.GetComponent<PickUp>();//get the prefix of the held object
            if (pickUp.playerPrefix == "P1")//if the prefix is player 1
            {
                score.IncreaseScore(1, 10); //tell the score manager and increaase by 10
            }
            else if (pickUp.playerPrefix == "P2")//if the prefix is player 2
            {
                score.IncreaseScore(2, 10);//tell the score manager and increaase by 10
            }
            else if (pickUp.playerPrefix == "P3")//if the prefix is player 3
            {
                score.IncreaseScore(3, 10);//tell the score manager and increaase by 10
            }
            else if (pickUp.playerPrefix == "P4")//if the prefix is player 4
            {
                score.IncreaseScore(4, 10);//tell the score manager and increaase by 10
            }
        }
        
    }
}
