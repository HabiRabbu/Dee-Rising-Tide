using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallBlock : MonoBehaviour
{
    [SerializeField] GameObject healthPrefab;
    private GameObject newHealth;
    private GameObject newHealthChild;
    [SerializeField] Canvas canvas;

    [SerializeField] Image healthBarImage;
    [SerializeField] Sprite[] blockSprites;
    [SerializeField] GameObject firstBlock;
    [SerializeField] TurnManager turnManager;

    [SerializeField] UpgradeManager upgradeManager;

    [SerializeField] float damageTick = 2f;
    [SerializeField] float damage = 1f;

    public string currentMaterial = "";
    public float health = 0f;
    public float maxHealth = 0f;
    private bool isColliding = false;
    private bool exists = true;
    private bool healthBarActive = false;
    
    private enum State
    {
        first,
        second
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        if (!firstBlock)
        {
            exists = false;
            state = State.second;
        }
        else
        {
            state = State.first;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkFirstBlock();
        checkHealth();

        SetHealthBar();

    }

    private void SetHealthBar()
    {
        if ((health < maxHealth) && (healthBarActive == false))
        {
            healthBarActive = true;
            Debug.Log("I got this far..");
            newHealth = Instantiate<GameObject>(healthPrefab, transform.position, Quaternion.identity, canvas.transform);
            newHealthChild = newHealth.transform.GetChild(0).gameObject;
            healthBarImage = newHealthChild.GetComponent<Image>();

        }

        if (healthBarActive == true)
        {
            Debug.Log("Im working!");
            healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);
        }

        if (maxHealth == 0 && healthBarActive == true)
        {
            if (newHealth != null)
            {
                Destroy(newHealth);
            }
            healthBarActive = false;
        }
    }

    private void checkHealth()
    {
        if (health < 0 && turnManager.inProgress == true && state == State.first)
        {
            turnManager.loadLoseScreen();
        } 
        else if (health <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[3];
            maxHealth = 0;
        }


    }

    private void checkFirstBlock()
    {
        if (exists == true)
        {
            if (firstBlock.GetComponent<WallBlock>().getHealth() >= 0 && turnManager.inProgress == true)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    public float getHealth()
    {
        return health;
    }

    private void OnMouseDown()
    {
        GameObject currentObject = gameObject;
        upgradeManager.createWallPopup(currentMaterial, gameObject.name);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
        StartCoroutine(ApplyCorrosion());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
        StopCoroutine(ApplyCorrosion());
    }


    private IEnumerator ApplyCorrosion()
    {
        while (isColliding)
        {
            health -= turnManager.getDamage();
            Debug.Log("Health is: " + health);
            yield return new WaitForSeconds(damageTick);
        }

    }

    public void updateBlock(string material)
    {
        currentMaterial = material;
        switch (currentMaterial)
        {
            case "Wood":
                health = 5;
                maxHealth = 5;
                gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[0];
                Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.name);
                break;
            case "Stone":
                health = 15;
                maxHealth = 15;
                gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[1];
                Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.name);
                break;
            case "Iron":
                health = 25;
                maxHealth = 25;
                gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[2];
                break;
        }
    }
}
