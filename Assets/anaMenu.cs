using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anaMenu : MonoBehaviour
{
    public Text pointText;

    public Text point;
    void Start()
    {
        int lowerpointscore = PlayerPrefs.GetInt("kayit");
        int pointscore = PlayerPrefs.GetInt("kayitPuan");
        pointText.text = "en yüksek puan= " + lowerpointscore;
        point.text = "Puan= " + pointscore;
    }

    void Update()
    {
        
    }
    public void gameStart()
    {
        SceneManager.LoadScene("1");
    }
    public void gameExit()
    {
        Application.Quit();
    }
}
