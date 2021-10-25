using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject firstPopup;
    [SerializeField] GameObject secondPopup;
    [SerializeField] GameObject thirdPopup;


    int currentText = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstPopup.SetActive(false);
        secondPopup.SetActive(false);
        thirdPopup.SetActive(false);

        NextText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextText()
    {
        switch (currentText)
        {
            case 0:
                FirstText();
                break;
            case 1:
                SecondText();
                break;
            case 2:
                ThirdText();
                break;
            case 3:
                FourthText();
                break;
            case 4:
                FifthText();
                break;
            case 5:
                LoadNext();
                break;
        }
        currentText += 1;
    }

    private void LoadNext()
    {
        sceneLoader.LoadNextScene();
    }

    private void FifthText()
    {
        secondPopup.SetActive(false);
        thirdPopup.SetActive(true);
        text.text = "Each round the water will rise.\n" +
            "It will also grow more vicious.\n\n" +
            "Good luck.";
    }

    private void FourthText()
    {
        firstPopup.SetActive(false);
        secondPopup.SetActive(true);

        text.text = "I'll then need you to repair the walls.\n" +
            "Wooden walls will do at the beginning, but I fear this could be one of the worst floods I've ever seen.\n\n" +
            "You will need to keep upgrading, and look to use better materials.\n" +
            "We have Wood, Stone and Iron at our disposal.";
    }

    private void ThirdText()
    {
        text.text = "The water will rise soon, I have bestowed upon you the temporary title of Prince, but don't get carried away, it is only temporary.\n\n" +
            "I need you to grow our strength. We will need to attract rich lords - build houses for them.\n" +
            "We can use the gold we gain from taxes to then upgrade our Lumber Mills, Stone Quarries then Iron Mines.";
        firstPopup.SetActive(true);
    }

    private void SecondText()
    {
        text.text = "I may not be around anymore, but I still protect my beloved castle in any way I can, hoping that I may one day return and restore it to its former glory. \n\n" +
            "But, I'm no fool. I know that won't be possible. \n\n" +
            "However, I do have a task for you, if you're brave enough to accept it. \n\n" +
            "Do you know of the River Dee? The large river nearby which cuts into the north of Wales?\n" +
            "The water is rising. It threatens to destroy the last remaining ruins of my proudest legacy. Please, help me protect my castle, and let me rest once and for all.\n\n" +
            "I must know my castle is safe. She is everything to me.";
    }

    private void FirstText()
    {
        text.text = "Excuse me, what do you think you're doing by my castle? This is no place for peasants. \n\n" +
            "That's right, this is my castle. My beautiful Caergwrle castle. \n" +
            "Let me introduce myself. My name is Dafydd ap Gruffydd, prince of Wales - or, at least I used to be...";
    }
}
