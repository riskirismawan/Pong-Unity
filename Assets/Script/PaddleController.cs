using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public string axis;
    public float UpLine;
    public float DownLine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * speed * Time.deltaTime;
        float nextPosition = transform.position.y + move;
        if (nextPosition > UpLine)
        {
            move = 0;
        }
        if (nextPosition < DownLine)
        {
            move = 0;
        }
        transform.Translate(0, move, 0);
    }
}
