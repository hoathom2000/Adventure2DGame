using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathIU : MonoBehaviour
{
    public Sprite[] heathSprite;

    public Player player;

    public Image health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health > 5)
            player.health = 5;


        if (player.health < 0)
            player.health = 0;
        // check array out of index
        health.sprite = heathSprite[player.health];
    }
}
