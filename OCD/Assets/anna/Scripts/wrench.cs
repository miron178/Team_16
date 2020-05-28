using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    public puddleCheck puddle;
    public ScoreManager score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wrench")
        {
            puddle.nutAttached();

            PickUp pickUp = other.gameObject.GetComponent<PickUp>();
            if (pickUp.playerPrefix == "P1")
            {
                score.IncreaseScore(1, 30);
            }
            else if (pickUp.playerPrefix == "P2")
            {
                score.IncreaseScore(2, 30);
            }
            else if (pickUp.playerPrefix == "P3")
            {
                score.IncreaseScore(3, 30);
            }
            else if (pickUp.playerPrefix == "P4")
            {
                score.IncreaseScore(4, 30);
            }
        }
    }
}
