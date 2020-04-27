using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCheck : MonoBehaviour
{
    public GameObject fire;
    public float countdown = 5.0f;
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            fire.SetActive(true);
        }
    }
    public void extinguished()
    {
        fire.SetActive(false);
        countdown = 5.0f;
    }
    
}
