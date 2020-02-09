using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondPlayerMovement : MonoBehaviour
{
  void Update()
{
    Rigidbody rb = GetComponent<Rigidbody>();

    if (Input.GetKey(KeyCode.LeftArrow))
    {
        transform.Translate(-20f * Time.deltaTime, 0f, 0f);//left
    }
    if (Input.GetKey(KeyCode.RightArrow))
    {
        transform.Translate(20f * Time.deltaTime, 0f, 0f);//right
    }
    if (Input.GetKey(KeyCode.DownArrow))
    {
        transform.Translate(0f, 0f, -20f * Time.deltaTime);//up
    }
    if (Input.GetKey(KeyCode.UpArrow))
    {
        transform.Translate(0f, 0f, 20f * Time.deltaTime);//down

    }
    if (Input.GetKey(KeyCode.RightControl))
    {
        transform.Translate(0f, 10f * Time.deltaTime, 0f);//down

    }
}
}
