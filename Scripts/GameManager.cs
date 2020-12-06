using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // set in MiniGameManager
    static public int MyWins;
    static public int NealWins;
    static public int SueWins;
    static public int FellowWins;
    static public int GeorgeWins;
    static public int MoniqueWins;

    static public int gamesPlayed;

    static public string TheChampion;

    // set in StadiumPark
    static public int fanPoint;
    static public int fanIX;
    static public int fanPointGameCondition = 6;

    // set in SceneManager
    static public bool IntroPlayed;
    static public bool MidCutPlayed;
    static public bool TourneyAnnounced;
    static public bool ChampionshipPlayed;
    static public bool EndingPlayed;

    static public bool MidCutConditions;
    static public bool EndingConditions;
    static public bool AnouncementConditions;

    static public bool MonicaHasTalked;
    static public bool FernHasTalked;
    static public bool JessicaHasTalked;
    static public bool NoahHasTalked;
    static public bool BradleyHasTalked;
    static public bool NickHasTalked;
    static public bool DamionHasTalked;
    static public bool TedHasTalked;
    static public bool GabriellaHasTalked;
    static public bool AnaHasTalked;
    static public bool AmeliaHasTalked;
    static public bool VictoriaHasTalked;
    static public bool RosaHasTalked;
    static public bool LaurenHasTalked;
    static public bool MableHasTalked;
    static public bool OscarHasTalked;
    static public bool JonHasTalked;
    static public bool KristenHasTalked;
    static public bool HarrisHasTalked;
    static public bool NateHasTalked;
    static public bool MilesHasTalked;

    static public bool InConversation;


    static public bool newGame;


    public static void Mean()
    {
        fanIX += 1;
        fanPoint += 3;
        Debug.Log(fanIX + " " + fanPoint);
        CanvasTextDisplayHandler.UpdateFanPoints();      
    }
    public static void Neutral()
    {
        fanIX += 1;
        fanPoint += 1;
        Debug.Log(fanIX + " " + fanPoint);
        CanvasTextDisplayHandler.UpdateFanPoints();      
    }
    public static void Nice()
    {
        fanIX += 1;
        fanPoint += 0;
        Debug.Log(fanIX + " " + fanPoint);
        CanvasTextDisplayHandler.UpdateFanPoints();
    }

    public void Button_PlayMiniGame()
    {
        CheckEligibility();
    }

    private void CheckEligibility()
    {
        if ((fanPoint - (gamesPlayed * fanPointGameCondition)) >= fanPointGameCondition)
        {
            newGame = true;
            MiniGameManager.RestartGame();
            SceneManager.LoadScene("00_MiniGameScene");
        }
    }

    public void Button_MainMenu()
    {
        SceneManager.LoadScene("02_LoadSlotScene");
        Debug.Log("Clicked");
    }

    public void Button_LoadGame()
    {
        LoadGame();
    }
    public void Button_NewGame()
    {
        NewGame();
    }
    public void Button_Play()
    {
        if (!IntroPlayed)
        {
            IntroPlayed = true;
            SceneManager.LoadScene("04_IntroScene");
        }
        else if (!MidCutPlayed)
        {
            CheckMidCut();
        }
        else if (!TourneyAnnounced)
        {
            CheckTourneyAnnouncement();
        }
    }

    public void Button_ReturnToStadium()
    {
        if (!MidCutPlayed)
        {
            CheckMidCut();
        }
        else if (!TourneyAnnounced)
        {
            CheckTourneyAnnouncement();
        }
        else if (ChampionshipPlayed)
        {
            CheckForEnding();
        }
    }

    

    public void Button_PlayChampionship()
    {
        if (TourneyAnnounced && !ChampionshipPlayed)
        {
            ChampionshipPlayed = true;
            newGame = true;
            MiniGameManager.RestartGame();
            SceneManager.LoadScene("00_MiniGameScene");
        }
    }

    public void Button_Credits()
    {
        SceneManager.LoadScene("08_CreditScene");
    }

    private void CheckForEnding()
    {
        if(((fanPoint/3)/fanIX) >= .5)
        {
            switch (TheChampion)
            {
                case "You":
                    SceneManager.LoadScene("07_WHostile");
                    break;
                case "Teal Neal":
                    SceneManager.LoadScene("07_LHostile");
                    break;
                case "Orange George":
                    SceneManager.LoadScene("07_LHostile");
                    break;
                case "Blue Sue":
                    SceneManager.LoadScene("07_LHostile");
                    break;
                case "Pink Monique":
                    SceneManager.LoadScene("07_LHostile");
                    break;
                case "Yellow Fellow":
                    SceneManager.LoadScene("07_LHostile");
                    break;
            }
        }
        else if(((fanPoint / 3) / fanIX) < .5)
        {
            switch (TheChampion)
            {
                case "You":
                    SceneManager.LoadScene("07_WKind");
                    break;
                case "Teal Neal":
                    SceneManager.LoadScene("07_LKind");
                    break;
                case "Orange George":
                    SceneManager.LoadScene("07_LKind");
                    break;
                case "Blue Sue":
                    SceneManager.LoadScene("07_LKind");
                    break;
                case "Pink Monique":
                    SceneManager.LoadScene("07_LKind");
                    break;
                case "Yellow Fellow":
                    SceneManager.LoadScene("07_LKind");
                    break;
            }
        }
    }

    public void CheckMidCut()
    {
        if (MidCutConditions)
        {
            MidCutPlayed = true;
            SceneManager.LoadScene("05_MidPlayCutScene");
        }
        else
        {
            SceneManager.LoadScene("00_StadiumParkScene");
        }
        
    }



    public void CheckTourneyAnnouncement()
    {
        if (AnouncementConditions)
        {
            TourneyAnnounced = true;
            SceneManager.LoadScene("06_FancyArenaScene");
        }
        else
        {
            SceneManager.LoadScene("00_StadiumParkScene");
        }
    }

    public void Button_StadiumPark()
    {

        Debug.Log("Selected");
        SceneManager.LoadScene("00_StadiumParkScene");
    }

    private void NewGame()
    {
        //create a new key with a string of the new game name passed in todo
        //set all values to zero todo
        Debug.Log("Pretending to reset values");
        SceneManager.LoadScene("03_MainMenuScene");
    }

    private void LoadGame()
    {
        //check passed in string and load game corresponded to that string. todo
        Debug.Log("Pretending to load in data");
        SceneManager.LoadScene("03_MainMenuScene");
    }

    public static void UpdateMidCutConditions()
    {
        if (MyWins == 1)
        {
            MidCutConditions = true;
        }
    }

    public static void UpdateAnouncementConditions()
    {
        if (MyWins == 2)
        {
            AnouncementConditions = true;
        }
    }


}
