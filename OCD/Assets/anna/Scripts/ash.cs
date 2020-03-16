using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ash : MonoBehaviour
{
    public float countdown = 5.0f;
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            gameObject.SetActive(true);
        }
    }
    public void cleaned()
    {
        gameObject.SetActive(false);
        countdown = 5.0f;
    }
    
}
