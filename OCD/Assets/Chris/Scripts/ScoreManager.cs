using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    MenuManager MenuReferance;


    [Header("Player In Game Scores")]
    [SerializeField]
    Text TXT_IG_PlayerOneScore;
    [SerializeField]
    Text TXT_IG_PlayerTwoScore;
    [SerializeField]
    Text TXT_IG_PlayerThreeScore;
    [SerializeField]
    Text TXT_IG_PlayerFourScore;
    Text[] TXT_PlayerScoresArray = new Text[5];
    [Header("Victory Text")]
    [SerializeField]
    Text TXT_Victory;

    void Start()
    {
        MenuReferance = GetComponent<MenuManager>(); // set referance
        //load array
        TXT_PlayerScoresArray[1] = TXT_IG_PlayerOneScore;
        TXT_PlayerScoresArray[2] = TXT_IG_PlayerTwoScore;
        TXT_PlayerScoresArray[3] = TXT_IG_PlayerThreeScore;
        TXT_PlayerScoresArray[4] = TXT_IG_PlayerFourScore;
    }

    //increase the score of a target player
    public void IncreaseScore(int PlayerNumber, int IncreaseAmount)
    {
        TXT_PlayerScoresArray[PlayerNumber].text = (int.Parse(TXT_PlayerScoresArray[PlayerNumber].text) + IncreaseAmount).ToString();
        
    }

    //decrease the score of a target player
    public void DecreaseScore(int PlayerNumber, int DecreaseAmount)
    {
        if (int.Parse(TXT_PlayerScoresArray[PlayerNumber].text) - DecreaseAmount >= 0)
        {
            TXT_PlayerScoresArray[PlayerNumber].text = (int.Parse(TXT_PlayerScoresArray[PlayerNumber].text) - DecreaseAmount).ToString();
        }
        else
        {
            TXT_PlayerScoresArray[PlayerNumber].text = "0";
        }
    }
    
    //reset scores of all players
    public void ResetScore(int PlayerNumber)
    {
        TXT_PlayerScoresArray[PlayerNumber].text = "0";
    }

    //resets all players scores to 0
    public void ResetAllPlayers()
    {
        TXT_PlayerScoresArray[1].text = "0";
        TXT_PlayerScoresArray[2].text = "0";
        TXT_PlayerScoresArray[3].text = "0";
        TXT_PlayerScoresArray[4].text = "0";
    }

    //find victor and show victory screen
    public void CalculateVictor()
    {
        int highScoreOfPlayer = 0; // the highest score
        int highScoringPlayer = 0; // the player with the highest score
        
        //run for each player
        for (int i = 0; i < 4; i++)
        {
            //check all scores against current highest found
            if (int.Parse(TXT_PlayerScoresArray[i].text) > highScoreOfPlayer)
            {
                highScoreOfPlayer = int.Parse(TXT_PlayerScoresArray[i].text); //records the new highscore
                highScoringPlayer = i; //saves the player number with the highest score
            }
        }
        if (highScoreOfPlayer == 0)//if all players have 0 highscoreofplayer wont be changed
        {
            TXT_Victory.text = "Draw!";
        }
        else
        {
            //show the player who won
            TXT_Victory.text = MenuReferance.TXT_IG_PlayerNamesArray[highScoringPlayer] + "Wins!!!";
        }
        MenuReferance.V_Show();
        MenuReferance.WriteScores();
    }











}