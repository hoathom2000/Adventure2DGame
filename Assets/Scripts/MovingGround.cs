using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public Rigidbody2D rigi;
    public float timedelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D conllision)
    {
        if (conllision.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        rigi.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
