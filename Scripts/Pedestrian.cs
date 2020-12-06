using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public Vector3 startingPos;
    public Quaternion startingRotation;
    [SerializeField] GameObject thisPerson;
    [SerializeField] Canvas talkToPerson;
    [SerializeField] GameObject conversationPos;
    [SerializeField] Canvas dialogueCanvas;

    private Vector3 _conversationPos;

    void Start()
    {
        startingPos = thisPerson.transform.position;
        startingRotation = thisPerson.transform.rotation;
        _conversationPos = conversationPos.transform.position;

        switch (thisPerson.gameObject.name)
        {
            case "Monica":
                if (GameManager.MonicaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Fern":
                if (GameManager.FernHasTalked == true)
                {
                   talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Jessica":
                if (GameManager.JessicaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Noah":
                if (GameManager.NoahHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Bradley":
                if (GameManager.BradleyHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Nick":
                if (GameManager.NickHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Damion":
                if (GameManager.DamionHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Ted":
                if (GameManager.TedHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Gabriella":
                if (GameManager.GabriellaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Ana":
                if (GameManager.AnaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Amelia":
                if (GameManager.AmeliaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Victoria":
                if (GameManager.VictoriaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Rosa":
                if (GameManager.RosaHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Lauren":
                if (GameManager.LaurenHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Mable":
                if (GameManager.MableHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Oscar":
                if (GameManager.OscarHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Jon":
                if (GameManager.JonHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Kristen":
                if (GameManager.KristenHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Harris":
                if (GameManager.HarrisHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Nate":
                if (GameManager.NateHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
            case "Miles":
                if (GameManager.MilesHasTalked == true)
                {
                    talkToPerson.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void TalkToCanvasButton()
    {
        if (GameManager.InConversation == true)
        {
            return;
        }
        else if (GameManager.InConversation == false)
        {
            GameManager.InConversation = true;
            Debug.Log("Seen");
            talkToPerson.gameObject.SetActive(false);
            thisPerson.transform.position = _conversationPos;
            thisPerson.transform.LookAt(SelfReferenceScript.that);
            dialogueCanvas.gameObject.SetActive(true);
            //todo, halt their random animations?
        }
    }

    public void BeMean()
    {
        GameManager.Mean();
        RespondedTo();
    }
    public void BeNeutral()
    {
        GameManager.Neutral();
        RespondedTo();
    }
    public void BeNice()
    {
        GameManager.Nice();
        RespondedTo();
    }
    public void RespondedTo()
    {
        //how do we ensure that gamemanager is calling the proper pedestrian function? Will all of them switch off?
        Debug.Log("Turning off canvas, returning to crowd");
        thisPerson.transform.position = startingPos;
        thisPerson.transform.rotation = startingRotation;
        dialogueCanvas.gameObject.SetActive(false);
        WhoTalked();
        GameManager.InConversation = false;
    }

    private void WhoTalked()
    {
        //Debug.Log(thisPerson.gameObject.name);
        switch(thisPerson.gameObject.name){
            case "Monica":
                GameManager.MonicaHasTalked = true;
                break;
            case "Fern":
                GameManager.FernHasTalked = true;
                break;
            case "Jessica":
                GameManager.JessicaHasTalked = true;
                break;
            case "Noah":
                GameManager.NoahHasTalked = true;
                break;
            case "Bradley":
                GameManager.BradleyHasTalked = true;
                break;
            case "Nick":
                GameManager.NickHasTalked = true;
                break;
            case "Damion":
                GameManager.DamionHasTalked = true;
                break;
            case "Ted":
                GameManager.TedHasTalked = true;
                break;
            case "Gabriella":
                GameManager.GabriellaHasTalked = true;
                break;
            case "Ana":
                GameManager.AnaHasTalked = true;
                break;
            case "Amelia":
                GameManager.AmeliaHasTalked = true;
                break;
            case "Victoria":
                GameManager.VictoriaHasTalked = true;
                break;
            case "Rosa":
                GameManager.RosaHasTalked = true;
                break;
            case "Lauren":
                GameManager.LaurenHasTalked = true;
                break;
            case "Mable":
                GameManager.MableHasTalked = true;
                break;
            case "Oscar":
                GameManager.OscarHasTalked = true;
                break;
            case "Jon":
                GameManager.JonHasTalked = true;
                break;
            case "Kristen":
                GameManager.KristenHasTalked = true;
                break;
            case "Harris":
                GameManager.HarrisHasTalked = true;
                break;
            case "Nate":
                GameManager.NateHasTalked = true;
                break;
            case "Miles":
                GameManager.MilesHasTalked = true;
                break;
        }
    }

    void Update()
    {
        PlayRandomAnimation();
    }

    private void PlayRandomAnimation()
    {
        Debug.Log("Playing animations");
    }
}
