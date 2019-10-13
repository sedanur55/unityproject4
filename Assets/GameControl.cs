using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public GameObject background1;
    public GameObject background2;
    Rigidbody2D pychical1;
    Rigidbody2D pychical2;
    public float backgroundspeed=-1.5f;
    float lenght=0;
    public GameObject obstacle;
    public int obstaclenumber=5;
    GameObject []obstacles;
    float change = 0;
    int sayac = 0;
    bool GameOver = true;

    void Start()
    {
        pychical1 = background1.GetComponent<Rigidbody2D>();
        pychical2 = background2.GetComponent<Rigidbody2D>();
        pychical1.velocity = new Vector2(backgroundspeed, 0);
        pychical2.velocity = new Vector2(backgroundspeed, 0);
        lenght = background1.GetComponent<BoxCollider2D>().size.x;
        obstacles = new GameObject[obstaclenumber];

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i] = Instantiate(obstacle, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D pychicalobstacles = obstacles[i].AddComponent<Rigidbody2D>();
            pychicalobstacles.gravityScale = 0;
            pychicalobstacles.velocity = new Vector2(backgroundspeed, 0);
        }
    }

    
    void Update()
    {
        if (GameOver)
        {
            if (background1.transform.position.x <= -lenght)
            {
                background1.transform.position += new Vector3(lenght * 2, 0);
            }
            if (background2.transform.position.x <= -lenght)
            {
                background2.transform.position += new Vector3(lenght * 2, 0);
            }



            change += Time.deltaTime;
            if (change > 2f)
            {
                change = 0;
                float yekseni = Random.Range(-2.7f, -0.56f);
                obstacles[sayac].transform.position = new Vector3(5, yekseni);
                sayac++;
                if (sayac >= obstacles.Length)
                {
                    sayac = 0;
                }

            }

        }
       


    }
    public void gameOver()
    {

        for(int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            pychical1.velocity = Vector2.zero;
            pychical2.velocity = Vector2.zero;
        }
        GameOver = false;
    }
}
