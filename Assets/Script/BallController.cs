using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    TMP_InputField inputMaxScore;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject endPanel;
    GameObject settingPanel;
    Text winnerTx;
    int angleRandom;
    new AudioSource audio;
    public AudioClip hitPaddleSound;
    public AudioClip hitWall;


    // Start is called before the first frame update
    void Start()
    {
        inputMaxScore = GameObject.Find("InputMaxScore").GetComponent<TMP_InputField>();
        inputMaxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();


        endPanel = GameObject.Find("EndPanel");
        endPanel.SetActive(false);
        settingPanel = GameObject.Find("SettingPanel");
        settingPanel.SetActive(false);

        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();


        int random = Random.Range(-2, 2);
        while (random == 0)
        {
            random = Random.Range(-2, 2);
        }

        rigid = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(random, 0).normalized;
        rigid.AddForce(direction * force);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(inputMaxScore.text) != PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", int.Parse(inputMaxScore.text));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(hitWall);
        if (collision.gameObject.name == "GoalP1")
        {
            scoreP2 += 1;
            ScoreDisplay();
            if (scoreP2 == PlayerPrefs.GetInt("MaxScore"))
            {
                endPanel.SetActive(true);
                winnerTx = GameObject.Find("Winner").GetComponent<Text>();
                winnerTx.color = new Color(0, 0, 255, 255);
                winnerTx.text = "Player Blue Winner!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 direction = new Vector2(2, 0).normalized;
            rigid.AddForce(direction * force);
        }
        if (collision.gameObject.name == "GoalP2")
        {
            scoreP1 += 1;
            ScoreDisplay();
            if (scoreP1 == PlayerPrefs.GetInt("MaxScore"))
            {
                endPanel.SetActive(true);
                winnerTx = GameObject.Find("Winner").GetComponent<Text>();
                winnerTx.color = new Color(255, 0, 0, 255);
                winnerTx.text = "Player Red Winner!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 direction = new Vector2(-2, 0).normalized;
            rigid.AddForce(direction * force);
        }
        if (collision.gameObject.name == "PaddleP1" || collision.gameObject.name == "PaddleP2")
        {
            audio.Stop();
            audio.PlayOneShot(hitPaddleSound);
            force += 5;
            if (force == 560)
            {
                force = 200;
            }
            float angle = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rigid.velocity.x, angle).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(direction * force * 2);
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
        Thread.Sleep(1000);
        force = 200;
    }

    void ScoreDisplay()
    {
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}