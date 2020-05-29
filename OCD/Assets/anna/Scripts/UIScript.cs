//started by anna but mostly by chris
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    ScoreManager ScoreManagerReferance;
    MenuManager MenuManagerReferance;

    [SerializeField]
    Text startText;

    [SerializeField]
    float timeLeft = 60.0f;
    float startingTime;
    float minutes;
    float seconds;


    void Start()
    {
        //set referances
        ScoreManagerReferance = GetComponent<ScoreManager>();
        MenuManagerReferance = GetComponent<MenuManager>();
        //save the starting time
        startingTime = timeLeft;
    }

    void Update()
    {
        //if in game run the timer
        if(MenuManagerReferance.inGame == true)
        {
            timeCounter();
        }
    }

    void timeCounter()
    {
        //lower timer
        timeLeft -= Time.deltaTime;
        
        //find minutes
        minutes = Mathf.Floor(timeLeft / 60);
        //find seconds
        seconds = timeLeft % 60;
        //display in text with correct format
        startText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        //old :
        //startText.text = "Time: " + (timeLeft / 100).ToString("0.00"); was 60 not 100

        //if timer is 0 or less calculate the victor
        if (timeLeft <= 0)
        {
            ScoreManagerReferance.CalculateVictor();
        }
    }

    
    public void resetTimer()
    {
        //reset the timer
        timeLeft = startingTime;
    }
}
