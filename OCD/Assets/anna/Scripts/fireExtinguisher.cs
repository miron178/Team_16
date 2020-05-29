//written by Anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExtinguisher : MonoBehaviour
{//creates link to scripts
    public fireCheck fire; 
    public ScoreManager score;

    private void OnTriggerEnter(Collider other)
    {   

        if (other.gameObject.tag == "extinguisher")//if objected in the trigger is tagged as extinguisher
        {
            fire.extinguished(); //run function

            PickUp pickUp = other.gameObject.GetComponent<PickUp>(); //get the prefix of the held object
            if (pickUp.playerPrefix == "P1") //if the prefix is player 1
            {
                score.IncreaseScore(1, 30); //tell the score manager and increaase by 30
            }
            else if (pickUp.playerPrefix == "P2")//if the prefix is player 2
            {
                score.IncreaseScore(2, 30); //tell the score manager and increaase by 30
            }
            else if (pickUp.playerPrefix == "P3")//if the prefix is player 3
            {
                score.IncreaseScore(3, 30); //tell the score manager and increaase by 30
            }
            else if (pickUp.playerPrefix == "P4")//if the prefix is player 4
            {
                score.IncreaseScore(4, 30); //tell the score manager and increaase by 30
            }
        }

    }
}
