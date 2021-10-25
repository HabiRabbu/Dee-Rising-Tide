using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    [SerializeField] float speed = 100f;
    [SerializeField] TurnManager turnManager;

    public Vector3 newPosition;
    public bool shouldMove = false;

    Vector3 resetPos;

    public enum State
    {
        move,
        beginTurn,
        stop,
        reset
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.stop;
        resetPos = new Vector3(transform.position.x, transform.position.y);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.move)
        {
            if (Vector3.Distance(transform.position, newPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            } 
            else
            {
                state = State.beginTurn;
            }

        } 
        else if (state == State.beginTurn)
        {
            turnManager.BeginTurn();
        }
        else if (state == State.reset)
        {
            if (Vector3.Distance(transform.position, resetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, resetPos, speed * Time.deltaTime);
            }
            else
            {
                state = State.stop;
                turnManager.setProgress();
            }
        }
    }

    private void OnMouseDown()
    {

    }

    /*
    public void Stop()
    {
        StopCoroutine(moveWater(newPosition));
    }
    */

    public void Move(Vector3 newPos)
    {
        newPosition = new Vector3(newPos.x, newPos.y, newPos.z);
        state = State.move;
    }

    public void resetWater()
    {
        state = State.reset;
    }
}
