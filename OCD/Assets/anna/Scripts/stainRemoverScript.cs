using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stainRemoverScript : MonoBehaviour
{
    public ScoreManager score;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dirt")
        {
            other.gameObject.SetActive(false);

            PickUp pickUp = this.GetComponent<PickUp>();
            if (pickUp.playerPrefix == "P1")
            {
                score.IncreaseScore(1, 10);
            }
            else if (pickUp.playerPrefix == "P2")
            {
                score.IncreaseScore(2, 10);
            }
            else if (pickUp.playerPrefix == "P3")
            {
                score.IncreaseScore(3, 10);
            }
            else if (pickUp.playerPrefix == "P4")
            {
                score.IncreaseScore(4, 10);
            }
        }
       
    }
}
