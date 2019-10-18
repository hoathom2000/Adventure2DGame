using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float lifetime = 5;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }
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
            if (col.CompareTag("Enemy"))
            {
                col.SendMessageUpwards("Damage", 100);
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (col.CompareTag("Bird"))
            {
                col.SendMessageUpwards("Damage", 100);
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (col.CompareTag("Water"))
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
