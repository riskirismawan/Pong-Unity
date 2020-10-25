using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : BallController
{
    int score;
    Text maxScores;
    // Start is called before the first frame update
    void Start()
    {
        maxScores = GameObject.Find("InputMaxScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        maxScores.text = PlayerPrefs.GetInt("MaxScore") + "";
    }

}
