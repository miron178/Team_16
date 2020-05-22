using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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

    string[] STR_Highscores = new string[50];

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
        WriteScores();
    }

    //write highscores
    //very messy
    //dont know if it works
    //havent run it yet
    //dont want to

    // it might work
    // it prob will work
    // but it doesnt save the values with - and , seperating
    // i would have to bodge together another 50 lines to get it working
    // it wont be efficient neet or easy to understand or debug
    // it will stay commented out for now


    //public void WriteScores()
    //{
    //    string Str_HighScoreFile = File.ReadAllText("Assets/Chris/PlayerNames/HighScores.txt");
    //    string[] Str_HighScores = Str_HighScoreFile.Split(',');



    //    //loads player scores and names
    //    string[] HighscoresParsed = Str_HighScores[1].Split('-');
    //    bool alternate = false;
    //    string[] playernames = new string[50];
    //    string[] highscore = new string[50];
    //    int IntTeller = 0;
    //    foreach (string Str_Values in HighscoresParsed)
    //    {
    //        //saves names
    //        if (alternate == false)
    //        {
    //            playernames[IntTeller] = Str_Values;
    //        }
    //        //saves score
    //        if (alternate == true)
    //        {
    //            highscore[IntTeller] = Str_Values;
                
    //            IntTeller++;
    //        }
    //        alternate = !alternate;
            
    //    }

    //    //checks if names dont exists to add them
    //    IntTeller = 0;
    //    int found = 0;
    //    string[] valuetoadd= new string[5];
    //    for (int p = 0; p < 4; p++)
    //    {
    //        foreach (string Str_Values in HighscoresParsed)
    //        {
    //            if (alternate == false)
    //            {
    //                if(playernames[IntTeller] == MenuReferance.TXT_IG_PlayerNamesArray[p].ToString())
    //                {
    //                    found++;
    //                }
    //            }

    //            if (alternate == true)
    //            {
    //                IntTeller++;
    //            }
    //            alternate = !alternate; //so it only runs 1/2 the array length

    //        }
    //        if (found == 0)
    //        {
    //            valuetoadd[p] = playernames[IntTeller]; ;
    //        }
    //        else
    //        {
    //            found = 0;
    //        }

    //    }

    //    //checks for player scores to update
    //    IntTeller = 0;
    //    alternate = false;
    //    foreach (string Str_Values in HighscoresParsed)
    //    {
    //        if (alternate == false)
    //        {
    //            for (int o = 0; o < 4; o++)
    //            {
    //                //tests if players in game match name
    //                if (playernames[IntTeller] == MenuReferance.TXT_IG_PlayerNamesArray[o].ToString())
    //                {
    //                    //tests if the score they recieved is better
    //                    if (int.Parse(highscore[IntTeller]) > int.Parse(TXT_PlayerScoresArray[o].text))
    //                    {
    //                        //updates the score
    //                        highscore[IntTeller] = TXT_PlayerScoresArray[o].ToString();
    //                    }
    //                }
    //            }
    //        }
    //        if (alternate == true)
    //        {
    //            IntTeller++;
    //        }
    //        alternate = !alternate;//so it only runs 1/2 the array length
    //    }


    //    string NewWriteString = "";
    //    foreach (string Str_Values in HighscoresParsed)
    //    {
    //        NewWriteString = NewWriteString + Str_Values;
    //        //alternate adding - and ,
    //    }

    //    File.WriteAllText("Assets/Chris/PlayerNames/HighScores.txt", NewWriteString);

    //    for (int g = 0; g < 4; g++)
    //    {
    //        File.WriteAllText("Assets/Chris/PlayerNames/HighScores.txt", NewWriteString + valuetoadd[g]);
    //    }
    //}

}