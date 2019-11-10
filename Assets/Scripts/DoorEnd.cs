using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnd : MonoBehaviour
{
    public GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.guidetext.text = ("It is the end. Thanks you !!!");
        }
    }
}
