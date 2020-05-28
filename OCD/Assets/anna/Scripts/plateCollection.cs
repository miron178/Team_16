using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCollection : MonoBehaviour
{
    public ScoreManager score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plate")
        {
           
            PickUp pickUp = other.gameObject.GetComponent<PickUp>();
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

            Destroy(other.gameObject);
        }

    }
}
