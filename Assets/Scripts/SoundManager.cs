using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, swords, destroy;

    public AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("Coin");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("Crash");
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                audiosrc.clip = coins;
                audiosrc.PlayOneShot(coins, 1f);
                break;

            case "destroy":
                audiosrc.clip = destroy;
                audiosrc.PlayOneShot(destroy, 1f);
                break;

            case "sword":
                audiosrc.clip = swords;
                audiosrc.PlayOneShot(swords, 1f);
                break;

        }
    }
}
