using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondPlayerMovement : MonoBehaviour
{
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-20f * Time.deltaTime, 0f, 0f);//left
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(20f * Time.deltaTime, 0f, 0f);//right
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0f, 0f, -20f * Time.deltaTime);//up
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0f, 0f, 20f * Time.deltaTime);//down

            }
            if (Input.GetKey(KeyCode.Z))
            {
                transform.Translate(0f, 10f * Time.deltaTime, 0f);//down

            }
        }

        if (gameObject.tag == "Player2")
        {
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

        if (gameObject.tag == "Player3")
        {
            if (Input.GetKey(KeyCode.Keypad1))
            {
                transform.Translate(-20f * Time.deltaTime, 0f, 0f);//left
            }
            if (Input.GetKey(KeyCode.Keypad3))
            {
                transform.Translate(20f * Time.deltaTime, 0f, 0f);//right
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                transform.Translate(0f, 0f, -20f * Time.deltaTime);//up
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.Translate(0f, 0f, 20f * Time.deltaTime);//down

            }
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                transform.Translate(0f, 10f * Time.deltaTime, 0f);//down

            }
        }

        if (gameObject.tag == "Player4")
        {
            if (Input.GetKey(KeyCode.J))
            {
                transform.Translate(-20f * Time.deltaTime, 0f, 0f);//left
            }
            if (Input.GetKey(KeyCode.L))
            {
                transform.Translate(20f * Time.deltaTime, 0f, 0f);//right
            }
            if (Input.GetKey(KeyCode.K))
            {
                transform.Translate(0f, 0f, -20f * Time.deltaTime);//up
            }
            if (Input.GetKey(KeyCode.I))
            {
                transform.Translate(0f, 0f, 20f * Time.deltaTime);//down

            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(0f, 10f * Time.deltaTime, 0f);//down

            }
        }
    }
}
