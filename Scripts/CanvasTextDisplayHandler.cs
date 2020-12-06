using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTextDisplayHandler : MonoBehaviour
{
    [SerializeField] Canvas canvasToToggle;

    public Text currentFanPoints;
    public Text pointsNeeded;

    public Text MyWins;
    public Text Intro;
    public Text MidCut;
    public Text Announce;
    public Text Ending;
    public Text Championship;

    private static int _currentFanPoints;
    private static int _pointsNeeded;

    private static int _MyWins;
    private static bool _Intro;
    private static bool _MidCut;
    private static bool _Announce;
    private static bool _Ending;
    private static bool _Championship;

    GameManager gameManager;


    void Start()
    {
        _pointsNeeded = GameManager.fanPointGameCondition;

        _currentFanPoints = GameManager.fanPoint - (GameManager.gamesPlayed * _pointsNeeded);

        currentFanPoints.text = "" + _currentFanPoints;
        pointsNeeded.text = "" + _pointsNeeded;

        if (_currentFanPoints >= _pointsNeeded)
        {
            canvasToToggle.gameObject.SetActive(false);
        }
        else if (_currentFanPoints < _pointsNeeded)
        {
            canvasToToggle.gameObject.SetActive(true);
        }

        _MyWins = GameManager.MyWins;
        _Intro = GameManager.IntroPlayed;
        _MidCut = GameManager.MidCutPlayed;
        _Announce = GameManager.TourneyAnnounced;
        _Ending = GameManager.EndingPlayed;
        _Championship = GameManager.ChampionshipPlayed;
    }

    public static void UpdateFanPoints()
    {
        //ToDo - Fix this mumbo jumbo
        
        //This function gets called only when fan points change, ideally this is when everything in update should happen.

        //Issue:

        //The only way i know how to call a function from another class is to make everything static.

        // However, because some of the objects need to be serialized in the game, I have to keep them public and not static.
    }

    public void Update()
    {
        _currentFanPoints = GameManager.fanPoint - (GameManager.gamesPlayed * _pointsNeeded);

        if (_currentFanPoints >= _pointsNeeded)
        {
            canvasToToggle.gameObject.SetActive(false);
        }
        else if (_currentFanPoints < _pointsNeeded)
        {
            canvasToToggle.gameObject.SetActive(true);
        }

        currentFanPoints.text = "" + _currentFanPoints;
        pointsNeeded.text = "" + _pointsNeeded;

        MyWins.text = "" + _MyWins;
        Intro.text = "" + _Intro;
        MidCut.text = "" + _MidCut;
        Announce.text = "" + _Announce;
        Ending.text = "" + _Ending;
        Championship.text = "" + _Championship;
}
}
