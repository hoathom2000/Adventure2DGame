using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1 : MonoBehaviour
{
    public int Health = 100;
    public AudioSource audiosrc;
    public AudioClip box;

    private void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Damage(int damage)
    {
        audiosrc.PlayOneShot(box, 1f);
        Health -= damage;
    }
}
