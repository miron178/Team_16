using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    MenuManager MenuReferance;
    Text[] PlayerScores = new Text[5];
    [Header("Player In Game Scores")]
    [SerializeField]
    Text TXT_IG_PlayerOneScore;
    [SerializeField]
    Text TXT_IG_PlayerTwoScore;
    [SerializeField]
    Text TXT_IG_PlayerThreeScore;
    [SerializeField]
    Text TXT_IG_PlayerFourScore;

    void Start()
    {
        MenuReferance = GetComponent<MenuManager>();
        PlayerScores[1] = TXT_IG_PlayerOneScore;
        PlayerScores[2] = TXT_IG_PlayerTwoScore;
        PlayerScores[3] = TXT_IG_PlayerThreeScore;
        PlayerScores[4] = TXT_IG_PlayerFourScore;
    }

    public void IncreaseScore(int PlayerNumber, int IncreaseAmount)
    {
        PlayerScores[PlayerNumber].text = (int.Parse(PlayerScores[PlayerNumber].text) + IncreaseAmount).ToString();
        
    }

    public void DecreaseScore(int PlayerNumber, int DecreaseAmount)
    {
        if (int.Parse(PlayerScores[PlayerNumber].text) - DecreaseAmount >= 0)
        {
            PlayerScores[PlayerNumber].text = (int.Parse(PlayerScores[PlayerNumber].text) - DecreaseAmount).ToString();
        }
        else
        {
            PlayerScores[PlayerNumber].text = "0";
        }
    }

    public void ResetScore(int PlayerNumber)
    {
        PlayerScores[PlayerNumber].text = "0";
    }

    public void ResetAllPlayers()
    {
        PlayerScores[1].text = "0";
        PlayerScores[2].text = "0";
        PlayerScores[3].text = "0";
        PlayerScores[4].text = "0";
    }
}