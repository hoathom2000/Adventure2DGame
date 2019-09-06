using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUpGround : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1, time = 6;
    Vector2 Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move.y += speed * Time.timeScale;
        this.transform.position = Move;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            speed *= changeDirection;
            time = 6;
        }
    }
}
