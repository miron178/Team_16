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
        ScoreManagerReferance = GetComponent<ScoreManager>();
        MenuManagerReferance = GetComponent<MenuManager>();
        startingTime = timeLeft;
    }

    void Update()
    {
        if(MenuManagerReferance.inGame == true)
        {
            timeCounter();
        }
    }

    void timeCounter()
    {
        timeLeft -= Time.deltaTime;
        
        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        startText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        //startText.text = "Time: " + (timeLeft / 100).ToString("0.00"); 

        if (timeLeft <= 0)
        {
            ScoreManagerReferance.CalculateVictor();
        }
    }

    
    public void resetTimer()
    {
        timeLeft = startingTime;
    }
}
