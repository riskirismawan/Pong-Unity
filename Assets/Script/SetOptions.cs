using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetOptions : MonoBehaviour
{
    TMP_InputField scoreMax;
    // Start is called before the first frame update
    void Start()
    {
        scoreMax = GameObject.Find("scoreMaxInput").GetComponent<TMP_InputField>();
        scoreMax.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(scoreMax.text) != PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", int.Parse(scoreMax.text));
        }
    }
}
