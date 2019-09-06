using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;

    public Animator anim;

    public Collider2D trigger;
    public SoundManager sound;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
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

        anim.SetBool("Attacking", attacking);
    }
}
