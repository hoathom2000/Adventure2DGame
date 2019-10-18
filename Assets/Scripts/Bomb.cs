using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float lifetime = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("Damage", 1);
            }
            if (col.CompareTag("Enemy"))
            {
                col.SendMessageUpwards("Damage", 100);
            }
            StartCoroutine(timecount(3));
        }

    }

    IEnumerator timecount(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        yield return 0;
    }
}
