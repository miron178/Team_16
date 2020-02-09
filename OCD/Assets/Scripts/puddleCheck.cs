using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleCheck : MonoBehaviour
{
    public GameObject puddle;
    public float countdown = 40.0f;
    void Update()
    {
        if (gameObject.activeSelf==true)
        {
            puddle.SetActive(false);
        }
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            gameObject.SetActive(false);
            puddle.SetActive(true);
        }
    }
    public void nutAttached()
    {
        gameObject.SetActive(true);
        countdown = 40.0f;
    }
}
