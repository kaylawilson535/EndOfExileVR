using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int myWins = 0;
    public int nealWins = 0;
    public int georgeWins = 0;
    public int moniqueWins = 0;
    public int fellowWins = 0;
    public int sueWins = 0;

    

    public string test;

    public Transform[] Players;

    public int[] PlayerScore;
    public string[] PlayerName;

    public Canvas endScreen;
    public Text winingAnnouncement;

 

    

    void Start()
    {
        PlayerScore = new int[6];
        PlayerName = new string[6];
        
    }

    public static void RestartGame()
    {
        Time.timeScale = 1.0f;
    }


    public void EndGame()
    {
        Time.timeScale = 0.0f;
        GameManager.gamesPlayed += 1;


        for (int i = 0; i < Players.Length; i++)
        {
            PlayerScore[i] = Players[i].GetComponent<PlayerPlatform>().CurrentStep();
            PlayerName[i] = Players[i].name;
            Debug.Log(PlayerName[i] + PlayerScore[i]);
        }

        int scoreTemp = 0;
        string playerTemp = "temp";

        for (int i = 0; i < PlayerScore.Length; i++)
        {
            for (int j = 0; j < PlayerScore.Length - 1; j++)
            {
                if (PlayerScore[j] < PlayerScore[j + 1])
                {
                    scoreTemp = PlayerScore[j + 1];
                    PlayerScore[j + 1] = PlayerScore[j];
                    PlayerScore[j] = scoreTemp;

                    playerTemp = PlayerName[j + 1];
                    PlayerName[j + 1] = PlayerName[j];
                    PlayerName[j] = playerTemp;
                }
            }
            //Debug.Log(PlayerName[i] + PlayerScore[i]);
        }
        if (GameManager.ChampionshipPlayed)
        {
            switch (PlayerName[0])
            {
                case "Teal Neal":
                    GameManager.NealWins += 1;
                    GameManager.TheChampion = "Teal Neal";
                    break;
                case "Blue Sue":
                    GameManager.SueWins += 1;
                    GameManager.TheChampion = "Blue Sue";
                    break;
                case "Yellow Fellow":
                    GameManager.FellowWins += 1;
                    GameManager.TheChampion = "Yellow Fellow";
                    break;
                case "Orange George":
                    GameManager.GeorgeWins += 1;
                    GameManager.TheChampion = "Orange George";
                    break;
                case "Pink Monique":
                    GameManager.MoniqueWins += 1;
                    GameManager.TheChampion = "Pink Monique";
                    break;
                case "You!":
                    GameManager.TheChampion = "You";
                    GameManager.MyWins += 1;
                    break;
            }
        }
        else if (!GameManager.ChampionshipPlayed)
        {
            switch (PlayerName[0])
            {
                case "Teal Neal":
                    GameManager.NealWins += 1;
                    break;
                case "Blue Sue":
                    GameManager.SueWins += 1;
                    break;
                case "Yellow Fellow":
                    GameManager.FellowWins += 1;
                    break;
                case "Orange George":
                    GameManager.GeorgeWins += 1;
                    break;
                case "Pink Monique":
                    GameManager.MoniqueWins += 1;
                    break;
                case "You!":

                    GameManager.MyWins += 1;
                    GameManager.UpdateMidCutConditions();
                    GameManager.UpdateAnouncementConditions();
                    break;
            }
        }
        

        endScreen.gameObject.SetActive(true);

        winingAnnouncement.text = "Winner is: " + PlayerName[0];
        Debug.Log( "Winner is: " + PlayerName[0]);

    }
}

   
