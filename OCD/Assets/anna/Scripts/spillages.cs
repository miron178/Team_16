using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spillages : MonoBehaviour
{
    public Transform spillagePos;
    public GameObject spillage;
    public ScoreManager score;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stainRemover")
        {
            Instantiate(spillage, spillagePos.position, spillagePos.rotation);

            PickUp pickUp = other.gameObject.GetComponent<PickUp>();
            if (pickUp.playerPrefix == "P1")
            {
                score.DecreaseScore(1, 10);
            }
            else if (pickUp.playerPrefix == "P2")
            {
                score.DecreaseScore(2, 10);
            }
            else if (pickUp.playerPrefix == "P3")
            {
                score.DecreaseScore(3, 10);
            }
            else if (pickUp.playerPrefix == "P4")
            {
                score.DecreaseScore(4, 10);
            }
        }
    }
}
