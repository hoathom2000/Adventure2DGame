using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobster : MonoBehaviour
{
    public float speed = 0.1f, changeDirection = -1;
    Vector2 Move;
    public Player player;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move.x += speed * Time.timeScale;
        this.transform.position = Move;
    }

    public void Flip()
    {
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground") || col.collider.CompareTag("Lobster"))
        {
            speed *= changeDirection;
            Flip();
        }
        if (col.collider.CompareTag("Player"))
        {
            player.Damage(damage);
        }
    }
}
