using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ash : MonoBehaviour
{
    public GameObject ashDust;
    public float countdown = 5.0f;
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            ashDust.SetActive(true);
        }
    }
    public void cleaned()
    {
        ashDust.SetActive(false);
        countdown = 5.0f;
    }
    
}
