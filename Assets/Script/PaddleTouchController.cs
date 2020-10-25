using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTouchController : MonoBehaviour
{
    Vector3 touchPosition;
    Rigidbody2D rigid;
    Vector3 direction;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = touchPosition - transform.position;
            rigid.velocity = new Vector2(direction.x, direction.y) * speed;

            if (touch.phase == TouchPhase.Ended)
            {
                rigid.velocity = Vector2.zero;
            }
        }
    }
}
