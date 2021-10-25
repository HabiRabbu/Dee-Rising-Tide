using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject storyPopup;
    [SerializeField] Text storyText;
    [SerializeField] GameObject popupTip;
    [SerializeField] GameObject water;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Text timerText;
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] ResourceManager resourceManager;

    private float currentTime = 0;
    private float totalTime = 10;
    public float damage = 1f;
    private int roundCounter = 0;

    private bool startTimer = false;

    public bool inProgress = false;



    private enum State
    {
        Round1,Round2,Round3,Round4,Round5,Round6,Round7,Round8,Round9,Round10,
        Round11,Round12,Round13,Round14,Round15,Round16,Round17,Round18,Round19,Round20,
        Continuous
    }

    private State round;

    public Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        popupTip.SetActive(true);
        storyPopup.SetActive(true);
        RoundText();
        newPos = new Vector3(waypoints[0].position.x, waypoints[0].position.y, waypoints[0].position.z);
        timerText.enabled = false;
        round = State.Round1;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (currentTime > 0)
            {
                water.GetComponent<BoxCollider2D>().enabled = true;
                currentTime -= 1 * Time.deltaTime;
                timerText.text = currentTime.ToString();
            } 
            else
            {
                startTimer = false;
                timerText.enabled = false;
                water.GetComponent<BoxCollider2D>().enabled = false;
                water.GetComponent<Water>().resetWater();
            }
        }
    }

    public void setDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void loadLoseScreen()
    {
        sceneLoader.LoadNextScene();
    }

    public void closePopup()
    {
        storyPopup.SetActive(false);
        popupTip.SetActive(false);
    }

    public void setProgress()
    {
        inProgress = false;
        if (roundCounter < 3)
        {
            RoundText();
        }
        scoreManager.updateScore(1, "rounds");
    }

    public void BeginTurn()
    {
        water.GetComponent<Water>().state = Water.State.stop;
        Debug.Log("Turn started");
        currentTime = totalTime;
        startTimer = true;
        timerText.enabled = true;
    }

    public float getDamage()
    {
        return damage;
    }

    public void OnNextTurn()
    {
        if (inProgress == false)
        {
            inProgress = true;
            switch (round)
            {
                case State.Round1:
                    newPos.Set(waypoints[0].position.x, waypoints[0].position.y, waypoints[0].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round2;
                    break;
                case State.Round2:
                    newPos.Set(waypoints[1].position.x, waypoints[1].position.y, waypoints[1].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round3;
                    break;
                case State.Round3:
                    newPos.Set(waypoints[2].position.x, waypoints[2].position.y, waypoints[2].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round4;
                    break;
                case State.Round4:
                    newPos.Set(waypoints[3].position.x, waypoints[3].position.y, waypoints[3].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round5;
                    break;
                case State.Round5:
                    newPos.Set(waypoints[4].position.x, waypoints[4].position.y, waypoints[4].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round6;
                    break;
                case State.Round6:
                    newPos.Set(waypoints[5].position.x, waypoints[5].position.y, waypoints[5].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round7;
                    break;
                case State.Round7:
                    newPos.Set(waypoints[6].position.x, waypoints[6].position.y, waypoints[6].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round8;
                    break;
                case State.Round8:
                    newPos.Set(waypoints[7].position.x, waypoints[7].position.y, waypoints[7].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round9;
                    break;
                case State.Round9:
                    newPos.Set(waypoints[8].position.x, waypoints[8].position.y, waypoints[8].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round10;
                    break;
                case State.Round10:
                    newPos.Set(waypoints[9].position.x, waypoints[9].position.y, waypoints[9].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round11;
                    break;
                case State.Round11:
                    newPos.Set(waypoints[10].position.x, waypoints[10].position.y, waypoints[10].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round12;
                    break;
                case State.Round12:
                    newPos.Set(waypoints[11].position.x, waypoints[11].position.y, waypoints[11].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round13;
                    break;
                case State.Round13:
                    newPos.Set(waypoints[12].position.x, waypoints[12].position.y, waypoints[12].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round14;
                    break;
                case State.Round14:
                    newPos.Set(waypoints[13].position.x, waypoints[13].position.y, waypoints[13].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round15;
                    break;
                case State.Round15:
                    newPos.Set(waypoints[14].position.x, waypoints[14].position.y, waypoints[14].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round16;
                    break;
                case State.Round16:
                    newPos.Set(waypoints[15].position.x, waypoints[15].position.y, waypoints[15].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round17;
                    break;
                case State.Round17:
                    newPos.Set(waypoints[16].position.x, waypoints[16].position.y, waypoints[16].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round18;
                    break;
                case State.Round18:
                    newPos.Set(waypoints[17].position.x, waypoints[17].position.y, waypoints[17].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round19;
                    break;
                case State.Round19:
                    newPos.Set(waypoints[18].position.x, waypoints[18].position.y, waypoints[18].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Round20;
                    break;
                case State.Round20:
                    newPos.Set(waypoints[19].position.x, waypoints[19].position.y, waypoints[19].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    round = State.Continuous;
                    break;
                case State.Continuous:
                    damage += 1;
                    newPos.Set(waypoints[19].position.x, waypoints[19].position.y, waypoints[19].position.z);
                    water.GetComponent<Water>().Move(newPos);
                    break;
            }
            resourceManager.OnNextTurn();
        }
        
    }

    public void RoundText()
    {
        switch (roundCounter)
        {
            case 0:
                storyPopup.SetActive(true);
                popupTip.SetActive(true);
                storyText.text = "Welcome to my castle.\n\n" +
                    "I've put a few tips here to help you.\n" +
                    "I hope this is enough.\n\n" +
                    "I would start by upgrading your houses\n" +
                    "and you should definitely build some walls.\n\n" +
                    "While the first wave looks low,\nthe water will still damage your walls.";
                roundCounter += 1;
                break;
            case 1:
                storyPopup.SetActive(true);
                storyText.text = "You did well with that first wave.\n\n" +
                    "It looks however like this flood won't end any time soon.\n" +
                    "It actually looks to be getting worse.\n\n" +
                    "Wooden walls will work for now. Make sure the wall is two blocks thick though.\n\n" +
                    "Look to begin upgrading your resource production.\n" +
                    "You'll need Stone and Iron before you know it.";
                roundCounter += 1;
                break;
            case 2:
                storyPopup.SetActive(true);
                storyText.text = "The rise is steady, but it's definitely getting worse.\n\n" +
                    "Good job up until now. Don't let up, you can still save my castle.\n\n" +
                    "You'll be on your own now. Good luck.\n\n" +
                    "My castle is in your hands.\n" +
                    "- Dafydd ap Gruffydd, Prince of Wales";
                roundCounter += 1;
                break;

        }
    }

}
