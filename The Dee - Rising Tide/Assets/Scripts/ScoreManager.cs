using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] Text roundText;
    [SerializeField] Text woodWText;
    [SerializeField] Text stoneWText;
    [SerializeField] Text ironWText;
    [SerializeField] Text lumberText;
    [SerializeField] Text quarryText;
    [SerializeField] Text mineText;
    [SerializeField] Text housesText;

    [SerializeField]  int rounds = 0;
    [SerializeField]  int wood = 0;
    [SerializeField]  int stone = 0;
    [SerializeField]  int iron = 0;
    [SerializeField]  int houses = 0;
    [SerializeField]  int lumber = 0;
    [SerializeField]  int quarry = 0;
    [SerializeField]  int mine = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 2)
        {
            DontDestroyOnLoad(gameObject);
        }
                


    }

    void Start()
    {

    }


    private void FindTextObjects()
    {
        GameObject roundTextObj = GameObject.FindGameObjectWithTag("1");
        roundText = roundTextObj.GetComponent<Text>();
        GameObject woodWTextObj = GameObject.FindGameObjectWithTag("2");
        woodWText = woodWTextObj.GetComponent<Text>();
        GameObject stoneWTextObj = GameObject.FindGameObjectWithTag("3");
        stoneWText = stoneWTextObj.GetComponent<Text>();
        GameObject ironWTextObj = GameObject.FindGameObjectWithTag("4");
        ironWText = ironWTextObj.GetComponent<Text>();
        GameObject housesTextObj = GameObject.FindGameObjectWithTag("5");
        housesText = housesTextObj.GetComponent<Text>();
        GameObject lumberTextObj = GameObject.FindGameObjectWithTag("6");
        lumberText = lumberTextObj.GetComponent<Text>();
        GameObject quarryTextObj = GameObject.FindGameObjectWithTag("7");
        quarryText = quarryTextObj.GetComponent<Text>();
        GameObject mineTextObj = GameObject.FindGameObjectWithTag("8");
        mineText = mineTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 3)
        {
            FindTextObjects();
            roundText.text = "You survived for " + rounds + " rounds.";
            woodWText.text = "You placed " + wood + " wooden wall blocks.";
            stoneWText.text = "You placed " + stone + " stone wall blocks.";
            ironWText.text = "You placed " + iron + " iron wall blocks.";
            housesText.text = "You built " + houses + " houses.";
            lumberText.text = "You upgraded your lumber mill " + lumber + " times.";
            quarryText.text = "You upgraded your stone quarry " + quarry + " times.";
            mineText.text = "You upgraded your iron mine " + mine + " times.";
        }

    }

    public void updateScore(int amount, string whichUpgrade)
    {
        switch (whichUpgrade)
        {
            case "rounds":
                rounds += amount;
                break;
            case "wood":
                wood += amount;
                break;
            case "stone":
                stone += amount;
                break;
            case "iron":
                iron += amount;
                break;
            case "houses":
                houses += amount;
                break;
            case "lumber":
                lumber += amount;
                break;
            case "quarry":
                quarry += amount;
                break;
            case "mine":
                mine += amount;
                break;
        }
    }
}
