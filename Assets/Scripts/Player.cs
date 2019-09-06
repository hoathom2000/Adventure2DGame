using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 3, maxjump = 5, jump = 300f, fall = 2.5f;
    public bool grounded = true, water = false, faceright = true, doublejump = false;

    public int health;
    public int maxhealth = 5;

    public Rigidbody2D rigi;
    public Animator anim;
    public GameMaster gm;
    public SoundManager sound;
    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<GameMaster>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Water", water);
        anim.SetFloat("speed", Mathf.Abs(rigi.velocity.x));
        // check jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                rigi.AddForce(Vector2.up * jump);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    rigi.velocity = new Vector2(rigi.velocity.x, 0);
                    rigi.AddForce(Vector2.up * jump);
                }
            }
        }
        if (rigi.velocity.y < 0)
        {
            rigi.velocity += Vector2.up * Physics2D.gravity.y * (fall) * Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigi.AddForce((Vector2.right) * speed * h);
        // limit speed
        if( rigi.velocity.x > maxspeed)
        {
            rigi.velocity = new Vector2(maxspeed, rigi.velocity.y);
        }
        if (rigi.velocity.x < -maxspeed)
        {
            rigi.velocity = new Vector2(-maxspeed, rigi.velocity.y);
        }
        if (rigi.velocity.y > maxjump)
        {
            rigi.velocity = new Vector2(rigi.velocity.x, maxjump);
        }
        if (rigi.velocity.y < -maxjump)
        {
            rigi.velocity = new Vector2(rigi.velocity.x, -maxjump);
        }
        // flip player interface
        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }
        // reduce speed
        if (grounded)
        {
            rigi.velocity = new Vector2(rigi.velocity.x * 0.7f, rigi.velocity.y);
        }

        if (health<=0)
        {
            Death();
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (PlayerPrefs.GetInt("highscore") < gm.points)
            PlayerPrefs.SetInt("highscore", gm.points);
    }

    public void Damage(int damage)
    {
        health -= damage;
        gameObject.GetComponent<Animation>().Play("Redflash");
    }


    public void Knockback(float knockPower, Vector2 knockDir)
    {
        rigi.velocity = new Vector2(0, 0);
        Vector3 Scale;
        Scale = transform.localScale;
        if (Scale.x > 0)
        {
            rigi.AddForce(new Vector2(knockDir.x * -200, knockDir.y + knockPower));
        }
        if (Scale.x < 0)
        {
            rigi.AddForce(new Vector2(knockDir.x * 200, knockDir.y + knockPower));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            sound.Playsound("coins");
            Destroy(col.gameObject);
            gm.points += 1;
        }
        if (col.CompareTag("Shoe"))
        {
            maxspeed = 5;
            speed = 70f;
            StartCoroutine(timecount(5));
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Heart"))
        {
            health = 5;
            Destroy(col.gameObject);
        }
    }
IEnumerator timecount(float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = 3f;
        speed = 50f;
        yield return 0;
    }
}
