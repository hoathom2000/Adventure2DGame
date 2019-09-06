using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;
    public WalkingGround walk;

    public Vector3 walkp;
    // Start is called before the first frame update
    void Start()
    {
        walk = GameObject.FindGameObjectWithTag("WalkingGround").GetComponent<WalkingGround>();
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
        if (collision.CompareTag("Water"))
        {
            player.grounded = true;
            player.water = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
        if (collision.CompareTag("Water"))
        {
            player.grounded = true;
            player.water = true;
        }
        if (collision.isTrigger == false && collision.CompareTag("WalkingGround"))
        {
            walkp = player.transform.position;
            walkp.x += walk.speed;
            player.transform.position = walkp;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = false;
        if (collision.CompareTag("Water"))
        {
            player.grounded = false;
            player.water = false;
        }
    }
}
