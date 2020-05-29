//made by anna
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spillages : MonoBehaviour
{
    public Transform spillagePos;//creates a transform to hold where spillage will go
    public GameObject spillage; //takes the spillage prefab
    public ScoreManager score;//creates link to score manager
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stainRemover")//if objected that triggered is tagged as stain remover
        {
            Instantiate(spillage, spillagePos.position, spillagePos.rotation); //create a clone of spillage at the transform

            PickUp pickUp = other.gameObject.GetComponent<PickUp>();//get the prefix of the held object
            if (pickUp.playerPrefix == "P1")//if the prefix is player 1
            {
                score.DecreaseScore(1, 10); //tell the score manager and increaase by 10
            }
            else if (pickUp.playerPrefix == "P2")//if the prefix is player 2
            {
                score.DecreaseScore(2, 10);//tell the score manager and increaase by 10
            }
            else if (pickUp.playerPrefix == "P3")//if the prefix is player 3
            {
                score.DecreaseScore(3, 10);//tell the score manager and increaase by 10
            }
            else if (pickUp.playerPrefix == "P4")//if the prefix is player 4
            {
                score.DecreaseScore(4, 10);//tell the score manager and increaase by 10
            }
        }
    }
}
