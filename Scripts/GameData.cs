using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int myWins;
    /*
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

    static public bool newGame; 
     */
     public GameData()
    {
        myWins = GameManager.MyWins;
    }
}
