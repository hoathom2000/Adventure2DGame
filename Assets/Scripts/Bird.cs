using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour
{
    public int curHealth = 100;
    public float speed;
    public float distance;
    public bool facingRight = true;
    public GameObject effect;
    public Transform target;
    public Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (curHealth <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) < 100)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (target.position.x >= transform.position.x && !facingRight)
            { Flip(); }
            if (target.position.x < transform.position.x && facingRight)
            { Flip(); }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(target.position, Vector2.down, distance);
    }

    public void Flip()
    {
        
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        facingRight = !facingRight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag.Equals("Player"))
        //{
        //    Instantiate(effect, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Water"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }
}
