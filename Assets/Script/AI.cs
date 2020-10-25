using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject Ball;
    public int speed;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Ball.transform.position.y)
        {
            rigid.velocity = new Vector2(transform.position.x, Ball.transform.position.y - transform.position.y) * speed * Time.deltaTime;
        }
        else if (transform.position.y > Ball.transform.position.y)
        {
            rigid.velocity = new Vector2(transform.position.x, Ball.transform.position.y - transform.position.y) * speed * Time.deltaTime;
        }
        else if (transform.position.y - 1 <= Ball.transform.position.y & transform.position.y + 1 >= Ball.transform.position.y)
        {
            rigid.velocity = new Vector2(transform.position.x, 0) /* speed*/;
        }
    }
}
