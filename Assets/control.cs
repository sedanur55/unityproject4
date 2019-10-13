using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    public Text skorpuanText;
    public Image gameoverimage;



    public Sprite[] BirdSprite;
    SpriteRenderer spriteRederer;
    bool backfordcontrol = true;
    int birdsayac = 0;
    int puan = 0;
    float birdanimationtime = 0;
    Rigidbody2D pychical;
    bool gameover = true;
    AudioSource []sounds;
    GameControl gameKontrol;
    int lowerpoint = 0;


    void Start()
    {
        spriteRederer = GetComponent<SpriteRenderer>();
        pychical = GetComponent<Rigidbody2D>();
        gameKontrol = GameObject.FindGameObjectWithTag("gamecontrol").GetComponent<GameControl>();
        sounds = GetComponents<AudioSource>();
        lowerpoint = PlayerPrefs.GetInt("kayit");
        Debug.Log("en yuksek kayıt:" + lowerpoint);
    }

   
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && gameover)
        {
            pychical.velocity = new Vector2(0, 0); //hızı sıfır yaptık
            pychical.AddForce(new Vector2(0, 200)); // kuvvet uyguladık
            sounds[0].Play();
            
            
        }
        if (pychical.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }

        Animasyon();
    }
    void Animasyon()
    {
        birdanimationtime += Time.deltaTime;
        if (birdanimationtime < 1)
        {
            birdanimationtime = 0;
            if (backfordcontrol)
            {
                spriteRederer.sprite = BirdSprite[birdsayac];
                birdsayac++;
                if (birdsayac == BirdSprite.Length)
                {
                    birdsayac--;
                    backfordcontrol = false;
                }
            }
            else
            {
                birdsayac--;
                spriteRederer.sprite = BirdSprite[birdsayac];
                if (birdsayac == 0)
                {
                    birdsayac++;
                    backfordcontrol = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "puan") 
        {
            puan++;
            skorpuanText.text = "Skor=" + puan;
            sounds[1].Play();
            Debug.Log(puan);

        }
        if (col.gameObject.tag == "obstacle")
        {

            gameover = false;
            sounds[2].Play();

            gameKontrol.gameOver();
            GetComponent<CircleCollider2D>().enabled = false;
            if (puan > lowerpoint)
            {
                lowerpoint = puan;
                PlayerPrefs.SetInt("kayit", lowerpoint);
            }
            Invoke("imagegetir",1);
            
            Invoke("anaMenuyeDon", 2);

        }
    }
    void imagegetir()
    {
        gameoverimage.enabled = true;

    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("kayitPuan", puan);
        SceneManager.LoadScene("anaMenu");
    }


}
