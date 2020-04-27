using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timecounter : MonoBehaviour
{
    public Text startText;
    float timeLeft = 216.0f;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = "Time: "+(timeLeft/60).ToString("0.00");
        if (timeLeft < 0)
        {
            gameObject.SetActive(false);
            //mum comes home
        }
    }
}
