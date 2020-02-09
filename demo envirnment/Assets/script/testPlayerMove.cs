using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMove : MonoBehaviour
{
   
    private void Start()
    {
       
    }
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
   
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0f, 0f, 5f * Time.deltaTime);//right
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0f, 0f, -5f * Time.deltaTime);//left
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-5f * Time.deltaTime, 0f, 0f);//up
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(5f * Time.deltaTime, 0f, 0f);//down

        }
    }
}
