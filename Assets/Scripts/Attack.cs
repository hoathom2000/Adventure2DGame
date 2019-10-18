using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public float fireballdeylay = 5f;
    public bool fireattacking = false;
    public bool attacking = false;
    public float fireballspeed = 10;
    public Animator anim;
    public GameObject fireBall;
    public Collider2D trigger;
    public SoundManager sound;
    public Rigidbody2D rigi;
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            sound.Playsound("sword");
        }

        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && !fireattacking)
        {
            fireattacking = true;
            fireballdeylay = 5f;
            Vector3 PlayerPosition = rigi.transform.position;
            Vector3 fireBallPosition = new Vector3(2.0f, 0, 0);
            Vector3 fireBallNegativePosition = new Vector3(-2.0f, 0, 0);
            GameObject fireBallclone;
            if (transform.localScale.x > 0)
            {
                fireBallclone = Instantiate(fireBall, PlayerPosition += fireBallPosition, Quaternion.identity) as GameObject;
                fireBallclone.GetComponent<Rigidbody2D>().velocity = new Vector2(fireballspeed, 0);
            }
            if (transform.localScale.x < 0)
            {            
                fireBallclone = Instantiate(fireBall, PlayerPosition += fireBallNegativePosition, Quaternion.identity) as GameObject;
                Vector3 Scale;
                Scale = fireBallclone.transform.localScale;
                Scale.x *= -1;
                fireBallclone.transform.localScale = Scale;
                fireBallclone.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireballspeed, 0);
            }
        }
        if(fireattacking)
        {
            if(fireballdeylay > 0)
            {
                fireballdeylay -= Time.deltaTime;
            }
            else
            {
                fireattacking = false;
            }
        }
            anim.SetBool("Attacking", attacking);          
    }
}
