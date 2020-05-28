using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExtinguisher : MonoBehaviour
{
    public fireCheck fire;
    public ScoreManager score;
    public GameObject[] player;
    public PhysicsController playerT;
    private void OnTriggerEnter(Collider other)
    {   

        if (other.gameObject.tag == "extinguisher")
        {
            fire.extinguished();

            PickUp pickUp = other.gameObject.GetComponent<PickUp>();
            Debug.Log("player " + pickUp.playerPrefix);
        }

    }
}
