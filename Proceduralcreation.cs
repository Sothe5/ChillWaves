using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceduralcreation : MonoBehaviour
{

    public GameObject[] backGrounds;
    public GameObject posEnd;
    public float nextOffset = 28.3879f;
    public SpriteRenderer autumn;
    public GameObject transition1;
    public GameObject transition2;
    public GameObject transition_noche1;
    public GameObject transition_noche2;

    private GameObject boardHolder;
    private GameObject next = null;
    private GameObject nextOfNext = null;

    static int roomGenerated = 0;
    public static int counter = 0;
    public static bool day = false;

    private int size;
    private Color myColor;

    // Use this for initialization
    void Start()
    {
        setDay();
        myColor = autumn.color;
        myColor.a = 0;
        autumn.color = myColor;
        size = backGrounds.Length;
        if (day)
        {
            boardHolder = backGrounds[0];
        }
        else
        {
            boardHolder = backGrounds[size / 2];
        }
        boardHolder = Instantiate(boardHolder, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated = 1;
        counter = 1;
        instNext(next);
        instNextOfNext(nextOfNext);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boardHolder.transform.position.x <= posEnd.transform.position.x)
        {
            updateBoard(boardHolder, next);
            instNextOfNext(nextOfNext);
            setDay();
        }
    }

    private void instNext(GameObject next)
    {
        if (day)
        {
            next = backGrounds[Random.Range(1, size / 8)];
        }
        else
        {
            next = backGrounds[Random.Range(size / 2 + 1, 5 * (size / 8))];
        }
        this.next = Instantiate(next, new Vector3(nextOffset, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated++;
        counter++;
    }
    private void instNextOfNext(GameObject next)
    {
        if (Move.speed < 1f)
        {
            next = check(next, 10);
        }
        else
        {
            next = check(next, 20);
        }
        this.nextOfNext = Instantiate(next, new Vector3(this.next.transform.position.x + nextOffset, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated++;
        counter++;
    }

    private void updateBoard(GameObject boardHolder, GameObject next)
    {
        GameObject.DestroyImmediate(this.boardHolder);
        this.boardHolder = next;
        this.next = nextOfNext;
    }

    private GameObject check(GameObject next, int n)
    {
        if (day.Equals(true))
        {
            next = inDay(next, n);
        }
        else
        {
            next = inNight(next, n);
        }
        return next;
    }

    private void setDay()
    {
        if ((System.DateTime.Now.Hour >= 0 && System.DateTime.Now.Hour < 8) || (System.DateTime.Now.Hour >= 20))
        {
            day = false;
        }
        else
        {
            day = true;
        }
    }

    private GameObject inDay(GameObject next, int n)
    {
        if (roomGenerated == n || roomGenerated == n * 2 || roomGenerated == n * 3 || roomGenerated == n * 4)
        {
            next = transition1;
        }
        else if (roomGenerated == n + 1 || roomGenerated == n * 2 + 1 || roomGenerated == n * 3 + 1 || roomGenerated == n * 4 + 1)
        {
            next = transition2;
        }
        else if (roomGenerated == n + 2)
        {
            next = backGrounds[size / 8];
        }
        else if (roomGenerated == n * 2 + 2)
        {
            myColor = autumn.color;
            myColor.a = 0.5f;
            autumn.color = myColor;
            next = backGrounds[size / 4];
        }
        else if (roomGenerated == n * 3 + 2)
        {
            myColor = autumn.color;
            myColor.a = 0;
            autumn.color = myColor;
            next = backGrounds[3 * (size / 8)];
        }
        else if (roomGenerated == n * 4 + 2)
        {
            roomGenerated = 0;
            next = backGrounds[0];
        }
        else if (roomGenerated < n + 2)
        {
            next = backGrounds[Random.Range(1, size / 8)];
        }
        else if (roomGenerated > n + 2 && roomGenerated < n * 2 + 2)
        {
            next = backGrounds[Random.Range(size / 8 + 1, size / 4)];
        }
        else if (roomGenerated > n * 2 + 2 && roomGenerated < n * 3 + 2)
        {
            next = backGrounds[Random.Range(size / 4 + 1, 3 * (size / 8))];
        }
        else if (roomGenerated > n * 3 + 2 && roomGenerated < n * 4 + 2)
        {
            next = backGrounds[Random.Range(3 * (size / 8) + 1, size / 2)];
        }
        return next;
    }

    private GameObject inNight(GameObject next, int n)
    {
        if (roomGenerated == n || roomGenerated == n * 2 || roomGenerated == n * 3 || roomGenerated == n * 4)
        {
            next = transition_noche1;
        }
        else if (roomGenerated == n + 1 || roomGenerated == n * 2 + 1 || roomGenerated == n * 3 + 1 || roomGenerated == n * 4 + 1)
        {
            next = transition_noche2;
        }
        else if (roomGenerated == n + 2)
        {
            next = backGrounds[5 * (size / 8)];
        }
        else if (roomGenerated == n * 2 + 2)
        {
            myColor = autumn.color;
            myColor.a = 0.5f;
            autumn.color = myColor;
            next = backGrounds[3 * (size / 4)];
        }
        else if (roomGenerated == n * 3 + 2)
        {
            myColor = autumn.color;
            myColor.a = 0;
            autumn.color = myColor;
            next = backGrounds[7 * (size / 8)];
        }
        else if (roomGenerated == n * 4 + 2)
        {
            roomGenerated = 0;
            next = backGrounds[4 * (size / 8)];
        }
        else if (roomGenerated < n + 2)
        {
            next = backGrounds[Random.Range(size / 2 + 1, 5 * (size / 8))];
        }
        else if (roomGenerated > n + 2 && roomGenerated < n * 2 + 2)
        {
            next = backGrounds[Random.Range(5 * (size / 8) + 1, 3 * (size / 4))];
        }
        else if (roomGenerated > n * 2 + 2 && roomGenerated < n * 3 + 2)
        {
            next = backGrounds[Random.Range(3 * (size / 4) + 1, 7 * (size / 8))];
        }
        else if (roomGenerated > n * 3 + 2 && roomGenerated < n * 4 + 2)
        {
            next = backGrounds[Random.Range(7 * (size / 8), size)];
        }
        return next;
    }

}
